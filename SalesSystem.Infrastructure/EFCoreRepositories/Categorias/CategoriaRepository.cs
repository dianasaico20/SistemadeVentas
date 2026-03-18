namespace SalesSystem.Infrastructure.EFCoreRepositories.Categorias
{
    public class CategoriaRepository(
        VentasDbContext context) : ICategoriaRepository
    {
        // LISTAR TODAS LAS CATEGORIAS
        public async Task<IEnumerable<CategoriaResponseDto>> GetCategoriaAllAsync()
        {
            var listaCategorias = await context.Categorias
                .AsNoTracking()
                .Select(c => new CategoriaResponseDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                })
                .ToListAsync();

            return listaCategorias;
        }

        // LISTAR POR ID
        public async Task<CategoriaResponseDto> GetCategoriaByIdAsync(int categoriaId)
        {
            var categoria = await context.Categorias
                .AsNoTracking()
                .Where(c => c.Id == categoriaId)
                .Select(c => new CategoriaResponseDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                })
                .FirstOrDefaultAsync();

            return categoria;
        }
    }
}
