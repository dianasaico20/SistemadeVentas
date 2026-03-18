namespace SalesSystem.Application.Interfaces.Categorias
{
    public interface ICategoriaInputPort
    {
        // Crear
        Task<BaseResponse> CreateCategoriaAsync(CategoriaCreateDto categoriaDto);

        // Actualizar
        Task<BaseResponse> UpdateCategoriaAsync(CategoriaCreateDto categoriaDto);

        // Eliminar
        Task<BaseResponse> DeleteCategoriaAsync(int categoriaId);

        // Listar por id
        Task<CategoriaResponseDto> GetCategoriaByIdAsync(int categoriaId);

        // Listar todas las Categorias
        Task<IEnumerable<CategoriaResponseDto>> GetCategoriaAllAsync();
    }
}
