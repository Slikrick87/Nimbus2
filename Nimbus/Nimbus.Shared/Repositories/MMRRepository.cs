using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Repositories
{
    public class MMRRepository : IMMRRepository
    {
        private readonly DataContext _context;
        public DbSet<TruckEntity> truck;
        public DbSet<MaintenanceEntity> MMRs;

        // Constructor to initialize the non-nullable field '_context'
        public MMRRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            truck = _context.Trucks;
        }
        public async Task AddMMRAsync(MaintenanceEntity maintenance)
        {
            await Task.Run(() => _context.MMRs.Add(maintenance));
            await Task.Run(() => _context.SaveChangesAsync());
        }
        public async Task<MaintenanceEntity> CreateNewMMRAsync(int mileage, decimal cost, string description, DateTime date, TruckEntity truck, int truckId)
        {
            MaintenanceEntity maintenance = await Task.Run(() =>
                maintenance = new MaintenanceEntity(mileage, cost, description, date, truck, truckId));
            return maintenance;
        }
        public async Task<List<MaintenanceEntity>> GetAllMMRsAsync()
        {
            return await _context.MMRs.ToListAsync();
        }
        public async Task<MaintenanceEntity> GetMMRByIdAsync(int id)
        {
            try
            {
                return await _context.MMRs.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<MaintenanceEntity>> GetMMRsByMonthAsync(int year, int month)
        {
            try
            {
                return await _context.MMRs
                    .Where(m => m.Date.Year == year && m.Date.Month == month)
                    .ToListAsync();
            }
            catch
            {
                return new List<MaintenanceEntity>();
            }
        }
        public async Task<List<MaintenanceEntity>> GetMMRsByTruckAsync(int truckId)
        {
            try
            {
                return await _context.MMRs
                    .Where(m => m.TruckId == truckId)
                    .ToListAsync();
            }
            catch
            {
                return new List<MaintenanceEntity>();
            }
        }
        public async Task<MaintenanceEntity> UpdateMMRAsync(MaintenanceEntity maintenance)
        {
            try
            {
                _context.MMRs.Update(maintenance);
                await _context.SaveChangesAsync();
                return maintenance;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                return null;
            }
        }
        public async Task DeleteMMRAsync(int id)
        {
            MaintenanceEntity maintenance = await GetMMRByIdAsync(id);
            await Task.Run(() => _context.MMRs.Remove(maintenance));
            await _context.SaveChangesAsync();
        }
    }
}
