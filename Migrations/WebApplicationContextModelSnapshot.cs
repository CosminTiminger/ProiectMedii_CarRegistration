﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Data;

namespace WebApplication.Migrations
{
    [DbContext(typeof(WebApplicationContext))]
    partial class WebApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication.Models.Book", b =>
                {
                    b.Property<int>("Phone_No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Car_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("License_Id")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Phone_No");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("WebApplication.Models.Cars", b =>
                {
                    b.Property<int>("Car_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookPhone_No")
                        .HasColumnType("int");

                    b.Property<int?>("CarsCar_Id")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Car_Id");

                    b.HasIndex("BookPhone_No");

                    b.HasIndex("CarsCar_Id");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("WebApplication.Models.Driver_Detailss", b =>
                {
                    b.Property<int>("License_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birth_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Driver_DetailssLicense_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("License_Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone_No")
                        .HasColumnType("int");

                    b.Property<int>("Post_Code")
                        .HasColumnType("int");

                    b.HasKey("License_Id");

                    b.HasIndex("Driver_DetailssLicense_Id");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("WebApplication.Models.Cars", b =>
                {
                    b.HasOne("WebApplication.Models.Book", null)
                        .WithMany("Car")
                        .HasForeignKey("BookPhone_No");

                    b.HasOne("WebApplication.Models.Cars", null)
                        .WithMany("Car")
                        .HasForeignKey("CarsCar_Id");
                });

            modelBuilder.Entity("WebApplication.Models.Driver_Detailss", b =>
                {
                    b.HasOne("WebApplication.Models.Driver_Detailss", null)
                        .WithMany("Drivers")
                        .HasForeignKey("Driver_DetailssLicense_Id");
                });

            modelBuilder.Entity("WebApplication.Models.Book", b =>
                {
                    b.Navigation("Car");
                });

            modelBuilder.Entity("WebApplication.Models.Cars", b =>
                {
                    b.Navigation("Car");
                });

            modelBuilder.Entity("WebApplication.Models.Driver_Detailss", b =>
                {
                    b.Navigation("Drivers");
                });
#pragma warning restore 612, 618
        }
    }
}