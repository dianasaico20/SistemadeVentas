namespace SalesSystem.Application.Interfaces.Productos
{
    public interface IProductoCommandsRepository : IUnidadDeTrabajo
    {
        // Crear
        Task<int> CreateProductoAsync(ProductoCreateDto productoDto);

        // Actualizar
        Task UpdateProductoAsync(ProductoCreateDto productoDto);

        // Eliminar
        Task DeleteProductoAsync(int productoId);
    }
}
