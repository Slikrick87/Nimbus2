using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Repositories;

namespace Nimbus.Shared.Services
{
    public interface IAddressRepository
    {
        public DbSet<Address> addresses { get; set;  }
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public Task AddStopAsync(Address address);
        public Task<Address> CreateNewAddressAsync(int streetNumber, string streetName, string city, string state, int zip);
        public Task<Address> CreateNewAddressWithRouteAsync(int streetNumber, string streetName, string city, string state, int zip, RouteEntity route);

        public Task<List<Address>> GetAllAddressesAsync();
        public Task<Address> GetAddressByIdAsync(int id);
        public List<Address> GetAddressesByRoute(int routeId);
        public Task ConvertToJSAddressByRoute(int routeId);
        public Task<Address> FindAddressForRouteByIdAsync(int RouteId, int AddressId);
        public Task UpdateAddressAsync(Address address);
        public Task DeleteAddressAsync(int id);
    }
}
