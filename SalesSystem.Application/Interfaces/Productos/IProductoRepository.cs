namespace SalesSystem.Application.Interfaces.Productos
{
    public interface IProductoRepository
    {
        // Listar por id
        Task<ProductoResponseDto> GetProductoByIdAsync(int productoId);

        // Listar todos los Productos
        Task<IEnumerable<ProductoResponseDto>> GetProductoAllAsync();

        // Listar por categoria
        Task<IEnumerable<ProductoResponseDto>> GetProductoByCategoriaIdAsync(int categoriaId);
    }
}
