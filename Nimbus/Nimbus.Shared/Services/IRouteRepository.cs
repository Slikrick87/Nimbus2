using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Services
{
    public interface IRouteRepository
    {
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public Task AddRouteAsync(RouteEntity route);
        public Task<RouteEntity> CreateNewRouteAsync();
        public Task<List<RouteEntity>> GetAllRoutesAsync();
        public Task<RouteEntity> GetRouteByIdAsync(int id);
        public Task<Address> AddStopAsync(RouteEntity route, Address address);
        public Task<List<Address>> GetStopsAsync(int routeId);
        public Task LinkTruckAsync(int routeId, int truckId);
        public Task DeleteRouteAsync(int id);
    }
}
