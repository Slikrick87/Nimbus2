using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nimbus.Shared.Entities;

namespace Nimbus.Shared
{
    public class DataContext : DbContext
    {
        public DbSet<TruckEntity> Trucks { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public string DbPath { get; }
        public DataContext()
        {
#if windows 
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder.path
            
            DbPath = System.IO.Path.Join(folder, "Data.db");
#endif
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Data.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TruckEntity>()
                .HasKey(t => t.id);
            modelBuilder.Entity<TruckEntity>()
                .Property(t => t.mileage)
                .IsRequired();
            modelBuilder.Entity<TruckEntity>()
                .Property(t => t.tireFD)
                .IsRequired();
            modelBuilder.Entity<TruckEntity>()
                .Property(t => t.tireRD)
                .IsRequired();
            modelBuilder.Entity<TruckEntity>()
                .Property(t => t.tireFP)
                .IsRequired();
            modelBuilder.Entity<TruckEntity>()
                .Property(t => t.tireRP)
                .IsRequired();
            modelBuilder.Entity<TruckEntity>()
                .Property(t => t.oilChange)
                .IsRequired();
            modelBuilder.Entity<TruckEntity>()
                .HasOne(t => t.route)
                .WithOne()
                .HasForeignKey<TruckEntity>(t => t.routeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TruckEntity>()
                .ToTable("Trucks");


            modelBuilder.Entity<RouteEntity>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<RouteEntity>()
                .Property(r => r.nickName)
                .IsRequired(false);
            modelBuilder.Entity<RouteEntity>()
                .HasMany(r => r.stops)
                .WithOne(a => a.route)
                .HasForeignKey(a => a.routeId);
                
            modelBuilder.Entity<RouteEntity>()
                .ToTable("Routes");
            modelBuilder.Entity<RouteEntity>()
                .HasOne(r => r.truck)
                .WithOne()
                .HasForeignKey<RouteEntity>(r => r.truckId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);


            //Hey update relationships like this ^^^^^^




            //modelBuilder.Entity<RouteEntity>()
            //    .HasMany(r => r.stops);
            //modelBuilder.Entity<RouteEntity>()
            //    .ToTable("Routes");

            modelBuilder.Entity<Address>()
                .HasKey(a => a.id);
            modelBuilder.Entity<Address>()
                .Property(a => a.streetNumber)
                .HasColumnName("Street Number");
            modelBuilder.Entity<Address>()
                .Property(a => a.streetName)
                .HasColumnName("Street Name");
            modelBuilder.Entity<Address>()
                .Property(a => a.city)
                .HasColumnName("City");
            modelBuilder.Entity<Address>()
                .Property(a => a.state)
                .HasColumnName("State");
            modelBuilder.Entity<Address>()
                .Property(a => a.zipCode)
                .HasColumnName("Zip Code");
            modelBuilder.Entity<Address>()
                .ToTable("Addresses");
            modelBuilder.Entity<Address>()
                .HasOne(a => a.route)
                .WithMany(r => r.stops)
                .HasForeignKey(a => a.routeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Address>(entity =>
            //{
            //    entity.HasKey(e => new { e.streetNumber, e.streetName, e.city, e.state, e.zipCode });

            //    entity.Property(e => e.streetNumber).IsRequired();
            //    entity.Property(e => e.streetName).IsRequired();
            //    entity.Property(e => e.city).IsRequired();
            //    entity.Property(e => e.state).IsRequired();
            //    entity.Property(e => e.zipCode).IsRequired();

            //});
        }
    }
}
