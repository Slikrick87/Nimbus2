//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Nimbus.Shared.Entities;

//namespace Nimbus
//{
//    public class TruckContext : DbContext
//    {
//        public DbSet<TruckEntity> Trucks { get; set; }
//        public DbSet<Route> Routes { get; set; }
//        public DbSet<Address> Addresses { get; set; }
//        public string DbPath { get; }
//        public TruckContext()
//        {
//            var folder = Environment.SpecialFolder.LocalApplicationData;
//            var path = Environment.GetFolderPath(folder);
//            DbPath = System.IO.Path.Join(path, "Data.db");
//        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlite("Data Source={DbPath}");
//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            modelBuilder.Entity<TruckEntity>().ToTable("Trucks");
//            modelBuilder.Entity<Route>().ToTable("Routes");
//            modelBuilder.Entity<Address>().ToTable("Addresses");
//        }
//    }
//}
