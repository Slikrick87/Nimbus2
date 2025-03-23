using Microsoft.AspNetCore.Components;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Repositories;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Nimbus.Shared.Pages
{
   
partial class ViewRoute
    {
        public int routeId;
        public bool editAddress = false;
        public bool deleteAddress = false;
        Address? address;
        List<Address> allStops = new List<Address>();

        protected override async Task OnInitializedAsync()
        {
            if (SelectionService.selectedRoute != null)
            {
                allStops = await RouteRepository.GetStopsAsync(SelectionService.selectedRoute.Id);
            }
        }

        public async Task DeleteAddressFinal()
        {
            
                await AddressRepository.DeleteAddressAsync(address.id);
                deleteAddress = false;
            
        }

        public async Task EditAddress(int id)
        {
            editAddress = true;
            address = await AddressRepository.FindAddressForRouteByIdAsync(SelectionService.selectedRoute.Id, id);
        }

        public async Task SaveAddressAsync()
        {
            if (address != null) // Check for null reference
            {
                await AddressRepository.UpdateAddressAsync(address);
                editAddress = false;
            }
        }

        public async Task DeleteAddress(int id)
        {
            deleteAddress = true;
            address = await AddressRepository.FindAddressForRouteByIdAsync(SelectionService.selectedRoute.Id, id);
            //await DeleteAddressFinal();
        }

        private void CloseEditModal()
        {
            editAddress = false;
        }

        private void CloseDeleteModal()
        {
            deleteAddress = false;
        }
    }
}
