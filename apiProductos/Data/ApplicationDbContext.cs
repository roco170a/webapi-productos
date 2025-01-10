using Microsoft.EntityFrameworkCore;

using apiProductos.Entities;
using System.Collections.Generic;

namespace apiProductos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Data Seeding
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Laptop",
                    Descripcion = "Laptop de alta gama",
                    Precio = 1200.99m,
                    CantidadEnStock = 50,
                    FechaCreacion = new DateTime(2025, 01, 01)
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Mouse",
                    Descripcion = "Mouse inalámbrico",
                    Precio = 25.50m,
                    CantidadEnStock = 200,
                    FechaCreacion = new DateTime(2025, 01, 01)
                },
                new Producto
                {
                    Id = 3,
                    Nombre = "Teclado Mecánico",
                    Descripcion = "Teclado RGB mecánico",
                    Precio = 75.00m,
                    CantidadEnStock = 100,
                    FechaCreacion = new DateTime(2025,01,01)
                }
            );
        }
    }
}
