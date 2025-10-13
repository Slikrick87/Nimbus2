let map;

async function geocodeAddress(address) {
  return new Promise((resolve, reject) => {
    const geocoder = new google.maps.Geocoder();
    geocoder.geocode({ address: address }, (results, status) => {
      if (status === 'OK') {
        const location = {
          lat: results[0].geometry.location.lat(),
          lng: results[0].geometry.location.lng()
        };
        resolve(JSON.stringify(location)); // This returns the coordinates as a JSON string
      } else {
        reject(status);
      }
    });
  });
}

async function initMap(locationsJson) {
  // The location of Uluru
  const position = { lat: -25.344, lng: 131.031 };
  // Request needed libraries.
  //@ts-ignore
  const { Map } = await google.maps.importLibrary("maps");
  const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");


  // Parse throught the incoming locations on manifest
  const locations = JSON.parse(locationsJson);
  console.log(locations);
  // The map, centered at Uluru
  map = new Map(document.getElementById("map"), {
    zoom: 4,
    center: position,
    mapId: "DEMO_MAP_ID",
  });

  // Add a marker for each location
  locations.forEach((location, index) => {
    new AdvancedMarkerElement({
      map: map,
      position: { lat: location.lat, lng: location.lng },
      title: `Stop ${index + 1}`,
    });
  });
}




