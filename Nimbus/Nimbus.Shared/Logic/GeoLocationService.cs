using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;
using Nimbus.Shared.Services;

namespace Nimbus.Shared.Logic
{
    public class GeoLocationService : IGeoLocationService
    {
        public async Task<Location> GetLocationAsync()
        {
            try
            {
                Location? location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
                return location;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
