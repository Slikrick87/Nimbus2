using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus.Shared.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Nimbus.Shared.Services;

namespace Nimbus.Shared.Pages
{
    public partial class Selections
    {
        public async Task ClearSelectionAsync()
        {
            Task taskOne = Task.Run(() => SelectionService.selectedTruck = null);
            await Task.Run(() => SelectionService.selectedRoute = null);
        }
        public void OilChange()
        {
            TruckRepository.ResetMileageAsync(SelectionService.selectedTruck, "oil");
        }
        public void TireFDChange()
        {
            TruckRepository.ResetMileageAsync(SelectionService.selectedTruck, "tireFD");
        }
        public void TireFPChange()
        {
            TruckRepository.ResetMileageAsync(SelectionService.selectedTruck, "tireFP");
        }
        public void TireRDChange()
        {
            TruckRepository.ResetMileageAsync(SelectionService.selectedTruck, "tireRD");
        }
        public void TireRPChange()
        {
            TruckRepository.ResetMileageAsync(SelectionService.selectedTruck, "tireRP");
        }
    }
}
