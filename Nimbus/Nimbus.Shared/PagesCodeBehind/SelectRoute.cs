using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Repositories;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Pages
{
    partial class SelectRoute : ComponentBase
    {
        bool isLoading = false;
        public RouteEntity? route;
        public TruckEntity? truck;
        public List<RouteEntity> routes = new List<RouteEntity>();
        public async Task ChooseRoute(int id)
        {
            SelectionService.selectedRoute = await RouteRepository.GetRouteByIdAsync(id);
        }
        public async Task LinkTruckAndRouteAsync()
        {
            bool isLoading = true;
            try
            {
                Task taskOne = Task.Run(() => RouteRepository.LinkTruckAsync(SelectionService.selectedTruck!.id, SelectionService.selectedRoute!.Id));
                Task taskTwo = Task.Run(() => TruckRepository.LinkRouteAsync(SelectionService.selectedRoute.Id, SelectionService.selectedTruck.id));
                Task<List<Address>> taskThree = Task.Run(() => RouteRepository.GetStopsAsync(SelectionService.selectedRoute.Id));
                SelectionService.orderedStopsForRoute = await taskThree;
                await Task.WhenAll(taskOne, taskTwo, taskThree);
            }
            finally
            {
                isLoading = false;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            routes = await RouteRepository.GetAllRoutesAsync();
        }
    }
}
