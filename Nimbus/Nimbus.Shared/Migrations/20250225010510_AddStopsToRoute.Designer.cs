﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nimbus.Shared;

#nullable disable

namespace Nimbus.Shared.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250225010510_AddStopsToRoute")]
    partial class AddStopsToRoute
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Nimbus.Shared.Entities.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("City");

                    b.Property<int?>("routeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("State");

                    b.Property<string>("streetName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Street Name");

                    b.Property<int>("streetNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Street Number");

                    b.Property<int>("zipCode")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Zip Code");

                    b.HasKey("id");

                    b.HasIndex("routeId");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Nimbus.Shared.Entities.RouteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nickName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("truckId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("truckId")
                        .IsUnique();

                    b.ToTable("Routes", (string)null);
                });

            modelBuilder.Entity("Nimbus.Shared.Entities.TruckEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("mileage")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("routeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tireFD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tireFP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tireRD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tireRP")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("routeId")
                        .IsUnique();

                    b.ToTable("Trucks", (string)null);
                });

            modelBuilder.Entity("Nimbus.Shared.Entities.Address", b =>
                {
                    b.HasOne("Nimbus.Shared.Entities.RouteEntity", "route")
                        .WithMany("stops")
                        .HasForeignKey("routeId");

                    b.Navigation("route");
                });

            modelBuilder.Entity("Nimbus.Shared.Entities.RouteEntity", b =>
                {
                    b.HasOne("Nimbus.Shared.Entities.TruckEntity", "truck")
                        .WithOne()
                        .HasForeignKey("Nimbus.Shared.Entities.RouteEntity", "truckId");

                    b.Navigation("truck");
                });

            modelBuilder.Entity("Nimbus.Shared.Entities.TruckEntity", b =>
                {
                    b.HasOne("Nimbus.Shared.Entities.RouteEntity", "route")
                        .WithOne()
                        .HasForeignKey("Nimbus.Shared.Entities.TruckEntity", "routeId");

                    b.Navigation("route");
                });

            modelBuilder.Entity("Nimbus.Shared.Entities.RouteEntity", b =>
                {
                    b.Navigation("stops");
                });
#pragma warning restore 612, 618
        }
    }
}
