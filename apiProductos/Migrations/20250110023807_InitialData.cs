using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apiProductos.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadEnStock = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CantidadEnStock", "Descripcion", "FechaCreacion", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 50, "Laptop de alta gama", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop", 1200.99m },
                    { 2, 200, "Mouse inalámbrico", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mouse", 25.50m },
                    { 3, 100, "Teclado RGB mecánico", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teclado Mecánico", 75.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
