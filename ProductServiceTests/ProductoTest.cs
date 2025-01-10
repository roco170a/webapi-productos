using apiProductos.Entities;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace ProductServiceTests;


public class ProductoTests
{
    [Fact]
    public void CrearProducto_ConPrecioNegativo_DeberiaFallar()
    {
        // Arrange
        var producto = new Producto
        {
            Nombre = "Producto Inválido",
            Precio = -10.00m,
            CantidadEnStock = 5
        };

        // Act
        var context = new ValidationContext(producto);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(producto, context, results, true);

        // Assert
        isValid.Should().BeFalse();
        results.Should().ContainSingle(result =>
            result.ErrorMessage.Contains("El precio debe ser mayor a 0"));
    }

    [Fact]
    public void CrearProducto_ConNombreInvalido_DeberiaFallar()
    {
        // Arrange
        var producto = new Producto
        {
            Nombre = "AB", // Nombre demasiado corto
            Precio = 10.00m,
            CantidadEnStock = 5
        };

        // Act
        var context = new ValidationContext(producto);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(producto, context, results, true);

        // Assert
        isValid.Should().BeFalse();
        results.Should().ContainSingle(result =>
                result.ErrorMessage.Contains("El nombre no puede ser menor a 3 carateres o mayor a 100 caracteres"));
                
    }
}