using Nimbus.Shared.Entities;
using Nimbus.Shared.Repositories;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Pages
{
    public partial class AddStop
    {
        public int stopsAdded = 0;
        public Address? newAddress;
        public int streetNumber;
        public string streetName;
        public string city;
        public string state;
        public int zipCode;
        private async Task AddNewStopAsync()
        {
            try
            {
                await Task.Run(() => newAddress = AddressRepository.CreateNewAddressWithRouteAsync(streetNumber, streetName, city, state, zipCode, SelectionService.selectedRoute).Result);
                Task taskTwo = Task.Run(() => RouteRepository.AddStopAsync(SelectionService.selectedRoute, newAddress));
                Task taskThree = Task.Run(() => SelectionService.orderedStopsForRoute.Add(newAddress));
                stopsAdded++;
            }
            catch { Console.WriteLine("Error in adding new address"); }

        }

    }
}
