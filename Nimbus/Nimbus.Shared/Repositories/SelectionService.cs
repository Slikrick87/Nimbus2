//using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
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
        public TruckEntity? selectedTruck { get; set; }
        public List<Address>? orderedStopsForRoute { get; set; }

        public Task ReorderStopsForRoute(List<Address> newOrder)
        {
            orderedStopsForRoute = newOrder;

            return Task.CompletedTask;
        }
    }

}
