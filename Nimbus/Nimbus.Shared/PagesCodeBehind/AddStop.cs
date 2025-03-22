using Microsoft.AspNetCore.Components;
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
        //[Inject]
        //public SelectionService SelectionService { get; set; }
        //[Inject]
        //public IAddressRepository AddressRepository { get; set; }
        //[Inject]
        //public IRouteRepository RouteRepository { get; set; }
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
                newAddress = await AddressRepository.CreateNewAddressWithRouteAsync(streetNumber, streetName, city, state, zipCode, SelectionService.selectedRoute);
                await RouteRepository.AddStopAsync(SelectionService.selectedRoute, newAddress);
                SelectionService.orderedStopsForRoute.Add(newAddress);
                stopsAdded++;
            }
            catch { Console.WriteLine("Error in adding new address"); }
        }
    }
}
