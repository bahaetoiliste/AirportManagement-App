﻿// <auto-generated />
using System;
using AirportManagement.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirportManagement.Migrations
{
    [DbContext(typeof(MainDB))]
    [Migration("20221115212223_sqlAirportdb")]
    partial class sqlAirportdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirportManagement.Domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("effectiveArrival")
                        .HasColumnType("datetime2");

                    b.Property<int>("estimatedDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("flightDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("planeId")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("planeId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirportManagement.Domain.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("emailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("passportNumber")
                        .HasColumnType("int");

                    b.Property<int>("telNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Passengers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Passenger");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AirportManagement.Domain.Plane", b =>
                {
                    b.Property<int>("planeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("planeId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("manufactureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("planeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("planeId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("passengerflightsFlightId")
                        .HasColumnType("int");

                    b.Property<int>("passengersId")
                        .HasColumnType("int");

                    b.HasKey("passengerflightsFlightId", "passengersId");

                    b.HasIndex("passengersId");

                    b.ToTable("FlightPassenger");
                });

            modelBuilder.Entity("AirportManagement.Domain.Staff", b =>
                {
                    b.HasBaseType("AirportManagement.Domain.Passenger");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<DateTime>("employementDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("AirportManagement.Domain.Traveller", b =>
                {
                    b.HasBaseType("AirportManagement.Domain.Passenger");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("healthInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Traveller");
                });

            modelBuilder.Entity("AirportManagement.Domain.Flight", b =>
                {
                    b.HasOne("AirportManagement.Domain.Plane", "plane")
                        .WithMany("planeflights")
                        .HasForeignKey("planeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plane");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("AirportManagement.Domain.Flight", null)
                        .WithMany()
                        .HasForeignKey("passengerflightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportManagement.Domain.Passenger", null)
                        .WithMany()
                        .HasForeignKey("passengersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirportManagement.Domain.Plane", b =>
                {
                    b.Navigation("planeflights");
                });
#pragma warning restore 612, 618
        }
    }
}
