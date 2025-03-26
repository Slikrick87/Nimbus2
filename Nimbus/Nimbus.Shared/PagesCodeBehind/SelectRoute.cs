using Microsoft.AspNetCore.Components;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Repositories;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Pages
{
    partial class SelectRoute
    {
        bool isLoading = false;
        public RouteEntity? route;
        public TruckEntity? truck;
        public List<RouteEntity> routes = new List<RouteEntity>();
        public async Task ChooseRoute(int id)
        {
            SelectionService.selectedRoute = RouteRepository.GetRouteByIdAsync(id).Result;
            //await Task.Yield(); // Ensure the selected route is set before proceeding
        }
        public async Task LinkTruckAndRouteAsync()
        {
            bool isLoading = true;
            try
            {
                Task taskOne = RouteRepository.LinkTruckAsync(SelectionService.selectedRoute.Id, SelectionService.selectedTruck.id);
                Task taskTwo = TruckRepository.LinkRouteAsync(SelectionService.selectedTruck.id, SelectionService.selectedRoute.Id);
                Task<List<Address>> taskThree = RouteRepository.GetStopsAsync(SelectionService.selectedRoute.Id);
                SelectionService.orderedStopsForRoute = await taskThree;
                await Task.WhenAll(taskOne, taskTwo, taskThree);
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
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
