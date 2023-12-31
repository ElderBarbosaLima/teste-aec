﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAec.DbContexts;

#nullable disable

namespace TestAec.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20230904031637_Database_v1")]
    partial class Database_v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestAec.Models.Errors.ErrorMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Error");
                });

            modelBuilder.Entity("TestAec.Models.Weather.WeatherAirportResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtmosphericPressure")
                        .HasColumnType("int");

                    b.Property<string>("ConditionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConditionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ICAOCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Moisture")
                        .HasColumnType("int");

                    b.Property<int?>("Temperature")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdateOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Visibility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Wind")
                        .HasColumnType("int");

                    b.Property<int?>("WindDirection")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeatherAirportResponse");
                });

            modelBuilder.Entity("TestAec.Models.Weather.WeatherCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConditionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConditionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float?>("MaxTemperature")
                        .HasColumnType("real");

                    b.Property<float?>("MinTemperature")
                        .HasColumnType("real");

                    b.Property<float?>("UvIndex")
                        .HasColumnType("real");

                    b.Property<int?>("WeatherCityResponseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeatherCityResponseId");

                    b.ToTable("WeatherCity");
                });

            modelBuilder.Entity("TestAec.Models.Weather.WeatherCityResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdateOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("WeatherCityResponse");
                });

            modelBuilder.Entity("TestAec.Models.Weather.WeatherCity", b =>
                {
                    b.HasOne("TestAec.Models.Weather.WeatherCityResponse", null)
                        .WithMany("Weather")
                        .HasForeignKey("WeatherCityResponseId");
                });

            modelBuilder.Entity("TestAec.Models.Weather.WeatherCityResponse", b =>
                {
                    b.Navigation("Weather");
                });
#pragma warning restore 612, 618
        }
    }
}
