using apiProductos.Entities;

namespace apiProductos.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<IEnumerable<Producto>> GetFilterAsync(string? nombre, decimal? precioInicial, decimal? precioFinal);
        Task<Producto?> GetByIdAsync(int id);
        Task<Producto> AddAsync(Producto producto);
        Task<Producto?> UpdateAsync(int id, Producto producto);
        Task<bool> DeleteAsync(int id);
    }
}
