//using Nimbus.Shared.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace Nimbus.Shared.PagesCodeBehind
//{
//    public partial class Map
//    {
//        public class GeoCodeResult
//        {
//            public double Lat { get; set; }
//            public double Lng { get; set; }
//        }
        //List<GeoCodeResult> locationsGeoCode = new List<GeoCodeResult>();
        //List<String> locationsJson = new List<String>();
        //List<LocationObject> enrichedLocationsJson = new List<LocationObject>();

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    try
        //    {
        //        await GetAddressesAndGeocode();
        //        var serializedLocations = JsonSerializer.Serialize(locationsGeoCode);
        //        await JS.InvokeVoidAsync("initMap", serializedLocations);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error initializing map: {ex.Message}");
        //    }
        //}

        //public async Task GetAddressesAndGeocode()
        //{
        //    if (SelectionService.selectedRoute != null)
        //    {
        //        var addresses = await AddressRepository.GetAddressesByRoute(SelectionService.selectedRoute.Id);
        //        var addressStrings = addresses.Select(a => $"{a.streetNumber} {a.streetName}, {a.city}, {a.state} {a.zipCode}").ToList();


        //        foreach (var address in addressStrings)
        //        {

        //            var json = await JS.InvokeAsync<string>("geocodeAddress", address);
        //            var location = JsonSerializer.Deserialize<GeoCodeResult>(json);


        //            locationsGeoCode.Add(location);
        //        }
        //        Console.WriteLine("Locations List:", JsonSerializer.Serialize(locationsJson));
        //    }
        //}
    //    private async Task MoveUp(int key)
    //    {
    //        try
    //        {
    //            var stops = SelectionService.selectedRoute.stops.ToList();
    //            var temp = stops[key];
    //            stops[key] = stops[key - 1];
    //            stops[key - 1] = temp;
    //            SelectionService.ReorderStopsForRoute(stops);
    //            StateHasChanged();
    //            await UpdateMap();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error moving stop up: {ex.Message}");
    //        }
    //    }
    //    private async Task MoveDown(int key)
    //    {
    //        try
    //        {
    //            var stops = SelectionService.orderedStopsForRoute.ToList();
    //            var temp = stops[key];
    //            stops[key] = stops[key + 1];
    //            stops[key + 1] = temp;
    //            SelectionService.ReorderStopsForRoute(stops);
    //            StateHasChanged();
    //            await UpdateMap();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error moving stop up: {ex.Message}");
    //        }
    //    }
    //    private async Task UpdateMap()
    //    {
    //        await GetAddressesAndGeocode();
    //        var serializedLocations = JsonSerializer.Serialize(locationsGeoCode);
    //        await JS.InvokeVoidAsync("initMap", serializedLocations);
    //    }
    //}
//}
