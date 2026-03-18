namespace SalesSystem.Application.Interfaces.Categorias
{
    public interface ICategoriaCommandsRepository : IUnidadDeTrabajo
    {
        // Crear
        Task<int> CreateCategoriaAsync(CategoriaCreateDto categoriaDto);

        // Actualizar
        Task UpdateCategoriaAsync(CategoriaCreateDto categoriaDto);

        // Eliminar
        Task DeleteCategoriaAsync(int categoriaId);
    }
}
