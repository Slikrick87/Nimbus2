using Nimbus.Shared.Entities;
using Nimbus.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Pages
{
    public partial class AddRoute
    {
        public string nickName;
        public RouteEntity route;
        public void AddNewRoute()
        {
            route = new RouteEntity(nickName);
            RouteRepository.AddRouteAsync(route);
        }
    }
}
