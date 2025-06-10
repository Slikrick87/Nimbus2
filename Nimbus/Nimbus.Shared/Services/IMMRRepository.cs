using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Services
{
    public interface IMMRRepository
    {
        public Task AddMMRAsync(MaintenanceEntity maintenance);
        public Task<MaintenanceEntity> CreateNewMMRAsync(int mileage, decimal cost, string description, DateTime date, TruckEntity truck, int truckId);
        public Task<List<MaintenanceEntity>> GetAllMMRsAsync();
        public Task<MaintenanceEntity> GetMMRByIdAsync(int id);
        public Task<List<MaintenanceEntity>> GetMMRsByMonthAsync(int year, int month);
        public Task<List<MaintenanceEntity>> GetMMRsByTruckAsync(int truckId);
        public Task<MaintenanceEntity> UpdateMMRAsync(MaintenanceEntity maintenance);
        public Task DeleteMMRAsync(int id);
    }
}
