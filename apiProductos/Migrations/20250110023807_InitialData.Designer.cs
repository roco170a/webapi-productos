﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiProductos.Data;

#nullable disable

namespace apiProductos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250110023807_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("apiProductos.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadEnStock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CantidadEnStock = 50,
                            Descripcion = "Laptop de alta gama",
                            FechaCreacion = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Laptop",
                            Precio = 1200.99m
                        },
                        new
                        {
                            Id = 2,
                            CantidadEnStock = 200,
                            Descripcion = "Mouse inalámbrico",
                            FechaCreacion = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Mouse",
                            Precio = 25.50m
                        },
                        new
                        {
                            Id = 3,
                            CantidadEnStock = 100,
                            Descripcion = "Teclado RGB mecánico",
                            FechaCreacion = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Teclado Mecánico",
                            Precio = 75.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
