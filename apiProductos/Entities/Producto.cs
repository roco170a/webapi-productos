using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiProductos.Entities
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre no puede ser menor a 3 carateres o mayor a 100 caracteres")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La cantidad en stock es requerida")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en stock debe ser mayor o igual a 0")]
        public int CantidadEnStock { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Constructor
        public Producto()
        {
            FechaCreacion = DateTime.Now;
        }

        // Constructor con parámetros
        public Producto(string nombre, decimal precio, int cantidadEnStock, string? descripcion = null)
        {
            Nombre = nombre;
            Precio = precio;
            CantidadEnStock = cantidadEnStock;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
        }
    }
}





