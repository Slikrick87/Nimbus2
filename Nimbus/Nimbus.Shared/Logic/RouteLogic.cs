using Nimbus.Shared.Entities;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Logic
{
    public class RouteLogic
    {
        public RouteEntity CreateNewRoute(int truckId, ICollection<Address> stops)
        {
            return new RouteEntity
            {
                //truckId = truckId,
                stops = stops
            };
        }
    }
}
