using apiProductos.Data;
using apiProductos.Entities;
using Microsoft.EntityFrameworkCore;

namespace apiProductos.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Set<Producto>().ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Set<Producto>().FindAsync(id);
        }

        public async Task<Producto> AddAsync(Producto producto)
        {
            _context.Set<Producto>().Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto?> UpdateAsync(int id, Producto producto)
        {
            var existingProducto = await _context.Set<Producto>().FindAsync(id);
            if (existingProducto == null)
            {
                return null;
            }

            existingProducto.Nombre = producto.Nombre;
            existingProducto.Descripcion = producto.Descripcion;
            existingProducto.Precio = producto.Precio;
            existingProducto.CantidadEnStock = producto.CantidadEnStock;

            await _context.SaveChangesAsync();
            return existingProducto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Set<Producto>().FindAsync(id);
            if (producto == null)
            {
                return false;
            }

            _context.Set<Producto>().Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Producto>> GetFilterAsync(string? nombre, decimal? precioInicial, decimal? precioFinal)
        {
            if (nombre != null && precioInicial == null && precioFinal == null)
            {                
                return await _context.Set<Producto>().Where(r => r.Nombre.ToUpper().Contains(nombre.ToUpper())).ToListAsync();
            }
            else if (nombre == null && precioInicial != null && precioFinal != null)
            {
                return await _context.Set<Producto>().Where(r => r.Precio >= precioInicial && r.Precio <= precioFinal).ToListAsync();                
            }            
            else
            {
                throw new Exception("Parametros incorrectos");
            }
        }
    }


}
