using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly DataContext _context;
        public DbSet<Address> addresses { get; set; }
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public RouteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddRouteAsync(RouteEntity route)
        {

            await Task.Run(() => _context.Routes.Add(route));
            await Task.Run(() => _context.SaveChanges());
        }
        public async Task<RouteEntity> CreateNewRouteAsync()
        {
            RouteEntity route = await Task.Run(() => new RouteEntity());
            return route;
        }
        public async Task<List<RouteEntity>> GetAllRoutesAsync()
        {
            return await _context.Routes.ToListAsync();
        }
        public async Task<RouteEntity> GetRouteByIdAsync(int id)
        {
            try { return await _context.Routes.FindAsync(id); }
            catch { return null; }
        }
        public async Task<Address> AddStopAsync(RouteEntity route, Address address)
        {
            await Task.Run(() => _context.Addresses.Add(address));
            Task taskOne = Task.Run(() => _context.SaveChangesAsync());
            
            return address;
        }
        public async Task<List<Address>> GetStopsAsync(int routeId)
        {
            return await _context.Addresses.Where(a => a.routeId == routeId).ToListAsync();
        }
        public async Task LinkTruckAsync(int routeId, int truckId)
        {
            TruckRepository truckRepository = new TruckRepository(_context);
            RouteEntity route = await GetRouteByIdAsync(routeId);
            TruckEntity truck = await truckRepository.GetTruckByIdAsync(truckId);
            route.truck = truck;
            _context.SaveChanges();
        }
        public async Task<List<Address>> GetAddressesByRoute(int routeId)
        {
            List<Address> addresses = await Task.Run(() => _context.Addresses.Where(a => a.routeId == routeId).ToList());
            return addresses;
        }
        public async Task DeleteRouteAsync(int id)
        {
            RouteEntity route = await GetRouteByIdAsync(id);
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
        }
    }
}
