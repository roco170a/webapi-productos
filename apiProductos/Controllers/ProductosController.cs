using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiProductos.Data;
using apiProductos.Entities;
using apiProductos.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace apiProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Servicio de backend para Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [SwaggerOperation(Summary = "Obtiene todos los productos",
                      Description = "Devuelve una lista de todos los productos disponibles en el API.")]
        [HttpGet]
        public async Task<IActionResult> GetAll( string? nombre, decimal? precioInicial, decimal? precioFinal)
        {
            if (nombre != null && precioInicial == null && precioFinal == null)
            {
                var ProductosFiltroPrecio = await _productoService.GetFilterAsync(nombre, null, null);
                return Ok(ProductosFiltroPrecio);
            }
            else if (nombre == null && precioInicial != null && precioFinal != null)
            {
                var ProductosFiltroPrecio = await _productoService.GetFilterAsync(null, precioInicial,precioFinal);
                return Ok(ProductosFiltroPrecio);
            }
            else if (nombre == null && precioInicial == null && precioFinal == null)
            {   
                var ProductosTodos = await _productoService.GetAllAsync();
                return Ok(ProductosTodos);
            }
            else {                
                return Problem(
                    statusCode:500, detail: "Los parámetros ingresados no cumplen las condiciones correctas",
                    title:"Parametros incorrectos");
            }

        }

        [SwaggerOperation(Summary = "Obtiene el producto indicado por el parametro",
                      Description = "Devuelve un producto, si es que esta disponible en el API.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [SwaggerOperation(Summary = "Agrega un nuevo producto",
                      Description = "Inserta un producto en el sistema.")]
        [HttpPost]
        public async Task<IActionResult> Add(Producto producto)
        {
            var createdProducto = await _productoService.AddAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = createdProducto.Id }, createdProducto);
        }

        [SwaggerOperation(Summary = "Actualiza un producto",
                      Description = "Actualiza un producto por el Id especificado.")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Producto producto)
        {
            var updatedProducto = await _productoService.UpdateAsync(id, producto);
            if (updatedProducto == null)
            {
                return NotFound();
            }
            return Ok(updatedProducto);
        }

        [SwaggerOperation(Summary = "Elimina un producto",
                      Description = "Borra un producto en el ID especificado.")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productoService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
