﻿using Microsoft.AspNetCore.Components;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Repositories;

namespace Nimbus.Shared.Pages
{
    public partial class Home
    {
        public int updatedMileage;
        //private string factor => FormFactor.GetFormFactor();
        //private string platform => FormFactor.GetPlatform();
        public RouteEntity route;
        public TruckEntity truck;
        public void OnCheckboxChange(ChangeEventArgs e, TruckEntity truck)
        {
            if ((bool)e.Value)
            {
                SelectionService.selectedTruck = truck;
            }
            else
            {
                SelectionService.selectedTruck = null;
            }
        }
        protected override Task OnInitializedAsync()
        {
            try
            {
                Task taskOne = Task.Run(() => truck = SelectionService.selectedTruck);
                Task taskTwo = Task.Run(() => route = SelectionService.selectedRoute);
                return Task.WhenAll(taskOne, taskTwo);
            }
            catch
            {
                return Task.CompletedTask;
            }
        }
        public async Task UpdateMileageAsync()
        {
            Task taskOne = Task.Run(() => TruckRepository.AdjustMileageAsync(SelectionService.selectedTruck.id, updatedMileage));
        }
    }
}
