namespace SalesSystem.Application.Interfaces.Categorias
{
    public interface ICategoriaRepository
    {
        // Listar por id
        Task<CategoriaResponseDto> GetCategoriaByIdAsync(int categoriaId);

        // Listar todas las Categorias
        Task<IEnumerable<CategoriaResponseDto>> GetCategoriaAllAsync();
    }
}
