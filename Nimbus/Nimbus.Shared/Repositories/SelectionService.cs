using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Repositories
{
    public class SelectionService
    {
        public RouteEntity? selectedRoute { get; set; }
        //public List<Address>? currentStops { get; set; }
        public TruckEntity? selectedTruck { get; set; }
        public List<Address>? orderedStopsForRoute { get; set; }
        
        //public async Task populateOrderedStopsForRoute()
        //{
        //    List<Address> addresses = RouteRepository.GetStopsAsync(selectedRoute.Id);
        //    foreach (Address address in RouteRepository.GetStopsAsync(selectedRoute.Id)
        //    {
        //        orderedStopsForRoute.Add(address);
        //    }
        //}
        public async Task ReorderStopsForRoute(List<Address> newOrder)
        {
            if (selectedRoute != null)
            {
                orderedStopsForRoute = newOrder;
            }
        }
    }

}
