using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Services;
using Nimbus.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly DataContext _context;
        public DbSet<Address> addresses { get; set; }
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public TruckRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddTruckAsync(TruckEntity truck)
        {

            await Task.Run(() => _context.Trucks.Add(truck));
            await Task.Run(() => _context.SaveChanges());
        }
        //public void SetselectedTruck(TruckEntity truck)
        //{
        //    selectedTruck = truck;
        //}
        public async Task<TruckEntity> CreateNewTruckAsync(int id, int mileage, int tireFD, int tireRD, int tireFP, int tireRP, int oil)
        {
            TruckEntity truck = await Task.Run(() => 
                new TruckEntity(id, mileage, tireFD, tireRD, tireFP, tireRP, oil));
            return truck;
        }
        //public async Task<TruckEntity> CreateNewTruckWithIdAsync(int id, int mileage, int tireFD, int tireRD, int tireFP, int tireRP, int oil)
        //{
        //    TruckEntity truck = await Task.Run(() =>
        //        new TruckEntity(mileage, tireFD, tireRD, tireFP, tireRP, oil));
        //    return truck;
        //}
        public async Task<List<TruckEntity>> GetAllTrucksAsync()
        {
            return await _context.Trucks.ToListAsync();
        }
        public async Task<TruckEntity> GetTruckByIdAsync(int id)
        {
            try { return await _context.Trucks.FindAsync(id); }
            catch { return null; }
        }
        public async Task AdjustMileageAsync(int id, int mileage)
        {
            TruckEntity truck = await GetTruckByIdAsync(id);
            int difference = 0;
            await Task.Run(() =>
            {
                difference = mileage - truck.mileage;
            });
            await Task.Run(() =>
            { 
            truck.tireFD += difference;
            truck.tireRD += difference;
            truck.tireFP += difference;
            truck.tireRP += difference;
            truck.oilChange += difference;
            truck.mileage = mileage;
            });
            await _context.SaveChangesAsync();
        }
        public async Task LinkRouteAsync(int truckId, int routeId)
        {
            TruckEntity truck = await GetTruckByIdAsync(truckId);
            RouteEntity? route = await _context.Routes.FindAsync(routeId);
            await Task.Run(() => truck.route = route);
            await _context.SaveChangesAsync();
        }
        public async Task ResetMileageAsync(TruckEntity truck, String choice)
        {
            switch (choice)
            {
                case "oil":
                    truck.oilChange = 0;
                    break;
                case "tireFD":
                    truck.tireFD = 0;
                    break;
                case "tireRD":
                    truck.tireRD = 0;
                    break;
                case "tireFP":
                    truck.tireFP = 0;
                    break;
                case "tireRP":
                    truck.tireRP = 0;
                    break;
                case "all":
                    truck.oilChange = 0;
                    truck.tireFD = 0;
                    truck.tireRD = 0;
                    truck.tireFP = 0;
                    truck.tireRP = 0;
                    break;
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTruckAsync(int id)
        {
            TruckEntity truck = await GetTruckByIdAsync(id);
            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();
        }
    }
}
