namespace SalesSystem.Application.Interfaces.Productos
{
    public interface IProductoInputPort
    {
        // Crear
        Task<BaseResponse> CreateProductoAsync(ProductoCreateDto productoDto);

        // Actualizar
        Task<BaseResponse> UpdateProductoAsync(ProductoCreateDto productoDto);

        // Eliminar
        Task<BaseResponse> DeleteProductoAsync(int productoId);

        // Listar por id
        Task<ProductoResponseDto> GetProductoByIdAsync(int productoId);

        // Listar todos los Productos
        Task<IEnumerable<ProductoResponseDto>> GetProductoAllAsync();

        // Listar por categoria
        Task<IEnumerable<ProductoResponseDto>> GetProductoByCategoriaIdAsync(int categoriaId);
    }
}
