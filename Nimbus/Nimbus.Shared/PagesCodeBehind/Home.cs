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
        //private bool isUpdateButtonDisabled = true;
        public RouteEntity? route;
        public TruckEntity? truck;
        public TruckEntity? truckCheck;
        public RouteEntity? routeCheck;
        public bool isDbEmpty = false;
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

        protected override async Task OnInitializedAsync()
        {
            try
            {
                truckCheck = await TruckRepository.GetTruckByIdAsync(1);
                routeCheck = await RouteRepository.GetRouteByIdAsync(1);
            }
            catch 
            {
                truckCheck = null;
                routeCheck = null;
            }

            if (SelectionService.selectedTruck == null || SelectionService.selectedRoute == null)
            {
                return;
            }
            else
            {
                try
                {
                    truck = SelectionService.selectedTruck;
                    route = SelectionService.selectedRoute;
                    currentMileage = truck?.mileage ?? 0;
                }
                catch
                {
                    // Handle exceptions
                }
            }
        }
        //private void ValidateMileage(ChangeEventArgs e)
        //{
        //    if (int.TryParse(e.Value.ToString(), out int newMileage))
        //    {
        //        updatedMileage = newMileage;
        //        isUpdateButtonDisabled = newMileage > currentMileage;
        //    }
        //    else
        //    {
        //        isUpdateButtonDisabled = true;
        //    }
        //}
        public async Task UpdateMileageAsync()
        {
            if (SelectionService.selectedTruck != null)
            {
                currentMileage = updatedMileage;
                TruckRepository.AdjustMileageAsync(SelectionService.selectedTruck.id, updatedMileage);
            }
        }
        //Just for Doods and dudettes to test out the DB more easily.
        public async Task AddToDBForTesting()
        {
            var truck1 = new TruckEntity(11111, 0, 270, 25, 300, 100);
            var truck2 = new TruckEntity(222, 150, 300, 40, 178, 67);
            var truck3 = new TruckEntity(27840, 10, 187, 25, 176, 99);
            var truck4 = new TruckEntity(101560, 5, 87, 77, 690, 1200);
            var truck5 = new TruckEntity(87, 51, 27, 254, 30, 2100);
            await TruckRepository.AddTruckAsync(truck1);
            await TruckRepository.AddTruckAsync(truck2);
            await TruckRepository.AddTruckAsync(truck3);
            await TruckRepository.AddTruckAsync(truck4);
            await TruckRepository.AddTruckAsync(truck5);
            var Route1 = new RouteEntity("Paintsville");
            var Route2 = new RouteEntity("Hazel Green");
            var Route3 = new RouteEntity("West Liberty");
            var Route4 = new RouteEntity("Hazard");
            var Route5 = new RouteEntity("Jackson");
            
            var address1 = new Address(625, "Main St", "Paintsville", "KY", 41240, Route1);
            var address2 = new Address(470, "N Mayo Trail", "Paintsville", "KY", 41240, Route1);
            var address3 = new Address(789, "6th St", "Paintsville", "KY", 41240, Route1);
            var address4 = new Address(209, "Pine St", "Paintsville", "KY", 41240, Route1);
            var address5 = new Address(5408, "KY-191", "Campton", "KY", 41301, Route2);
            var address6 = new Address(90, "Washington St", "Campton", "KY", 41301, Route2);
            var address7 = new Address(3333, "Ky-203", "Hazel Green", "KY", 41332, Route2);
            var address8 = new Address(431, "Ky-1010", "Hazel Green", "KY", 41332, Route2);
            var address9 = new Address(120, "Turner st", "Hazard", "KY", 41701, Route4);
            var address10 = new Address(330, "High St", "Hazard", "KY", 41701, Route4);
            var address11 = new Address(121, "Redbud Lane", "Hazard", "KY", 41701, Route4);
            var address12 = new Address(401, "Birch St", "Hazard", "KY", 41701, Route4);
            var address13 = new Address(1010, "Main St", "West Liberty", "KY", 41472, Route3);
            var address14 = new Address(111, "Prestonsburg St", "West Liberty", "KY", 41472, Route3);
            var address15 = new Address(1212, "Highway 172", "West Liberty", "KY", 41472, Route3);
            var address16 = new Address(339, "Riverside Dr", "West Liberty", "KY", 41472, Route3);
            var address17 = new Address(1200, "Main St", "Jackson", "KY", 41339, Route5);
            var address18 = new Address(929, "Highland Ave", "Jackson", "KY", 41339, Route5);
            var address19 = new Address(360, "Panbowl Rd", "Jackson", "KY", 41339, Route5);
            var address20 = new Address(409, "Lakeside Dr", "Jackson", "KY", 41339, Route5);

            await RouteRepository.AddRouteAsync(Route1);
            await RouteRepository.AddRouteAsync(Route2);
            await RouteRepository.AddRouteAsync(Route3);
            await RouteRepository.AddRouteAsync(Route4);
            await RouteRepository.AddRouteAsync(Route5);

            await RouteRepository.AddStopToRouteAsync(Route1, address1);
            await RouteRepository.AddStopToRouteAsync(Route1, address2);
            await RouteRepository.AddStopToRouteAsync(Route1, address3);
            await RouteRepository.AddStopToRouteAsync(Route1, address4);
            await RouteRepository.AddStopToRouteAsync(Route2, address5);
            await RouteRepository.AddStopToRouteAsync(Route2, address6);
            await RouteRepository.AddStopToRouteAsync(Route2, address7);
            await RouteRepository.AddStopToRouteAsync(Route2, address8);
            await RouteRepository.AddStopToRouteAsync(Route4, address9);
            await RouteRepository.AddStopToRouteAsync(Route4, address10);
            await RouteRepository.AddStopToRouteAsync(Route4, address11);
            await RouteRepository.AddStopToRouteAsync(Route4, address12);
            await RouteRepository.AddStopToRouteAsync(Route3, address13);
            await RouteRepository.AddStopToRouteAsync(Route3, address14);
            await RouteRepository.AddStopToRouteAsync(Route3, address15);
            await RouteRepository.AddStopToRouteAsync(Route3, address16);
            await RouteRepository.AddStopToRouteAsync(Route5, address17);
            await RouteRepository.AddStopToRouteAsync(Route5, address18);
            await RouteRepository.AddStopToRouteAsync(Route5, address19);
            await RouteRepository.AddStopToRouteAsync(Route5, address20);

            //await RouteRepository.AddRouteAsync(Route1);
            //await RouteRepository.AddRouteAsync(Route2);
            //await RouteRepository.AddRouteAsync(Route3);
            //await RouteRepository.AddRouteAsync(Route4);
            //await RouteRepository.AddRouteAsync(Route5);
        }
    }
}
