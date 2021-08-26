﻿// <auto-generated />
using System;
using Device.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Device.DataAccessLayer.Migrations
{
    [DbContext(typeof(DeviceDatabaseContext))]
    partial class DeviceDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Device.DataAccessLayer.Entity.Tel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WarrantyStarting")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Tels");
                });

            modelBuilder.Entity("Device.DataAccessLayer.Entity.Tv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<double>("Size")
                        .HasColumnType("double");

                    b.Property<DateTime>("WarrantyStarting")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Tvs");
                });
#pragma warning restore 612, 618
        }
    }
}
