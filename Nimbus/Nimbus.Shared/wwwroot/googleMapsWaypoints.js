
// copius amount of help from ai here!!
window.mapsWaypoints = (function () {
function _ensureCss() {
    if (document.getElementById('maps-waypoints-styles')) return;
    const style = document.createElement('style');
    style.id = 'maps-waypoints-styles';
    style.textContent = `
      .map-number-marker img { display:block; width:40px; height:40px; }
      .map-number-marker { width:40px; height:40px; display:inline-block; }
    `;
    document.head.appendChild(style);
}

function _svgDataUrl(number, fillColor, strokeColor = '#2447FF', textColor = '#ffffff', strokeWidth = 5, fontSize = 26, size = 72) {
    // Build a centered circular marker SVG with configurable stroke width and font size.
    const half = size / 2;
    // radius such that stroke stays inside viewbox nicely:
    const radius = Math.max(6, half - strokeWidth - 6);
    const svg = `<svg xmlns="http://www.w3.org/2000/svg" width="${size}" height="${size}" viewBox="0 0 ${size} ${size}">
      <circle cx="${half}" cy="${half}" r="${radius}" fill="${fillColor}" stroke="${strokeColor}" stroke-width="${strokeWidth}"/>
      <text x="${half}" y="${half + (fontSize * 0.12)}" font-family="Arial, Helvetica, sans-serif" font-size="${fontSize}" fill="${textColor}" font-weight="700" text-anchor="middle" dominant-baseline="middle">${number}</text>
    </svg>`;
    return 'data:image/svg+xml;base64,' + btoa(unescape(encodeURIComponent(svg)));
}

async function geocodeAddress(address) {
    return new Promise((resolve, reject) => {
        if (!window.google || !google.maps) {
            reject('Google Maps not loaded');
            return;
        }
        const geocoder = new google.maps.Geocoder();
        geocoder.geocode({ address: address }, (results, status) => {
            if (status === 'OK' && results[0]) {
                const location = {
                    lat: results[0].geometry.location.lat(),
                    lng: results[0].geometry.location.lng()
                };
                resolve(JSON.stringify(location));
            } else {
                reject(status || 'no-result');
            }
        });
    });
}

async function initMap(elementId, locationsJson, options) {
    _ensureCss();
    const optionsObj = options || {};
    // fallback colors
    let primaryColor = '#D98A4A'; // royal blue (stroke)
    let secondaryColor = '#2447FF'; // dull orange (fill)
    try {
        const cs = getComputedStyle(document.documentElement);
        const pVar = optionsObj.primaryVar || '--app-accent';
        const sVar = optionsObj.secondaryVar || '--app-accent-2';
        const pVal = cs.getPropertyValue(pVar).trim();
        const sVal = cs.getPropertyValue(sVar).trim();
        if (pVal) primaryColor = pVal;
        if (sVal) secondaryColor = sVal;
    } catch { /* ignore */ }

    // optional overrides
    const strokeWidth = Number(optionsObj.borderWidth ?? 5);
    const fontSize = Number(optionsObj.fontSize ?? 26);
    const imgSize = Number(optionsObj.iconSize ?? 40);
    const svgSize = Math.max(48, imgSize * 2); // keep SVG canvas larger than image for stroke

    let locations;
    try {
        locations = typeof locationsJson === 'string' ? JSON.parse(locationsJson) : locationsJson;
    } catch {
        console.error('mapsWaypoints: invalid locations JSON');
        locations = [];
    }
    if (!locations || locations.length === 0) {
        console.warn('mapsWaypoints: no locations provided');
        return;
    }

    // Map constructors (modern importLibrary or fallback)
    let MapConstructor = null;
    let AdvancedMarkerElementConstructor = null;
    if (google.maps && typeof google.maps.importLibrary === 'function') {
        try {
            const libs = await google.maps.importLibrary('maps');
            MapConstructor = libs.Map;
        } catch { MapConstructor = null; }
        try {
            const markerLib = await google.maps.importLibrary('marker');
            AdvancedMarkerElementConstructor = markerLib.AdvancedMarkerElement;
        } catch { AdvancedMarkerElementConstructor = null; }
    }

    const el = document.getElementById(elementId);
    if (!el) {
        console.error('mapsWaypoints: element not found:', elementId);
        return;
    }

    const center = { lat: locations[0].lat, lng: locations[0].lng };
    const mapOptions = { zoom: optionsObj.zoom || 12, center, mapId: optionsObj.mapId || undefined };
    const map = MapConstructor ? new MapConstructor(el, mapOptions) : new google.maps.Map(el, mapOptions);

    if (map.__mapsWaypointsMarkers) {
        map.__mapsWaypointsMarkers.forEach(m => {
            try { m.map = null; } catch { /* ignore */ }
            try { if (m.__dom) m.__dom.remove(); } catch { }
        });
    }
    map.__mapsWaypointsMarkers = [];

    const bounds = new google.maps.LatLngBounds();

    locations.forEach((loc, idx) => {
        const pos = { lat: Number(loc.lat), lng: Number(loc.lng) };
        bounds.extend(pos);

        const number = (typeof loc.index !== 'undefined') ? (loc.index + 1) : (idx + 1);
        const label = loc.label || `Stop ${number}`;

        // default behavior: fill is dull orange, stroke is royal blue
        // if options.alternateFill === true then alternate fills (keeps previous behavior)
        let fillColor = secondaryColor;
        let strokeColor = primaryColor;
        if (optionsObj.alternateFill) {
            fillColor = (idx % 2 === 0) ? secondaryColor : primaryColor;
            strokeColor = primaryColor;
        }

        const svgUrl = _svgDataUrl(number, fillColor, strokeColor, '#ffffff', strokeWidth, fontSize, svgSize);

        if (AdvancedMarkerElementConstructor) {
            const div = document.createElement('div');
            div.className = 'map-number-marker';
            const img = document.createElement('img');
            img.src = svgUrl;
            img.alt = label;
            img.style.width = `${imgSize}px`;
            img.style.height = `${imgSize}px`;
            div.appendChild(img);

            const marker = new AdvancedMarkerElementConstructor({
                map,
                position: pos,
                title: label,
                content: div,
                zIndex: idx
            });

            marker.__dom = div;
            map.__mapsWaypointsMarkers.push(marker);

            div.addEventListener('click', () => {
                const ev = new CustomEvent('mapsWaypoints:click', { detail: { index: idx, location: loc } });
                window.dispatchEvent(ev);
            });
        } else {
            const marker = new google.maps.Marker({
                position: pos,
                map,
                title: label,
                icon: {
                    url: svgUrl,
                    scaledSize: new google.maps.Size(imgSize, imgSize)
                },
                zIndex: idx
            });
            map.__mapsWaypointsMarkers.push(marker);
            marker.addListener('click', () => {
                const ev = new CustomEvent('mapsWaypoints:click', { detail: { index: idx, location: loc } });
                window.dispatchEvent(ev);
            });
        }
    });

    if (!bounds.isEmpty()) {
        map.fitBounds(bounds);
    }

    return true;
}

return {
    initMap,
    geocodeAddress
};
}) ();

// compatibility no-op initMap so callback param won't error
try {
    if (typeof window !== 'undefined' && !window.initMap) {
        window.initMap = function () { /* no-op */ };
    }
} catch (e) {
    console.error('mapsWaypoints: failed to set window.initMap', e);
}



