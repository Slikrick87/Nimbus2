using Microsoft.AspNetCore.Components;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Repositories;
using Nimbus.Shared.Services;

namespace Nimbus.Shared.Pages
{
    public partial class Home
    {
        public int updatedMileage;
        private int currentMileage;
        private bool isUpdateButtonDisabled = true;
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
                Task taskThree = Task.Run(() => currentMileage = truck.mileage);
                return Task.WhenAll(taskOne, taskTwo, taskThree);
            }
            catch
            {
                return Task.CompletedTask;
            }
        }
        private void ValidateMileage(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int newMileage))
            {
                updatedMileage = newMileage;
                isUpdateButtonDisabled = newMileage > currentMileage;
            }
            else
            {
                isUpdateButtonDisabled = true;
            }
        }
        public async Task UpdateMileageAsync()
        {
            if (SelectionService.selectedTruck != null && updatedMileage>= currentMileage)
            {
                TruckRepository.AdjustMileageAsync(SelectionService.selectedTruck.id, updatedMileage);
            }
        }
    }
}
