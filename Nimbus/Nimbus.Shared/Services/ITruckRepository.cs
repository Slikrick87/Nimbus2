using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus.Shared.Logic;

namespace Nimbus.Shared.Services
{
    public interface ITruckRepository
    {
        //public TruckEntity selectedTruck { get; set; }
        public DbSet<Address> addresses {  get; set; }
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        //public void SetselectedTruck(TruckEntity truck);
        public Task AddTruckAsync(TruckEntity truck);
        public Task<TruckEntity> CreateNewTruckAsync(int id, int mileage, int tireFD, int tireRD, int tireFP, int tireRP, int oil);
        public Task<List<TruckEntity>> GetAllTrucksAsync();
        public Task<TruckEntity> GetTruckByIdAsync(int id);
        public Task AdjustMileageAsync(int truckId, int mileage);
	    public Task LinkRouteAsync(int truckId, int routeId);
        public Task ResetMileageAsync(TruckEntity truck, String choice);
        public Task DeleteTruckAsync(int id);
    }
}
