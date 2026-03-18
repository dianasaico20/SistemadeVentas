namespace SalesSystem.Infrastructure.EFCoreRepositories.Categorias
{
    public class CategoriaCommandsRepository(
        VentasDbContext context) : ICategoriaCommandsRepository
    {
        // CREAR CATEGORIA
        public async Task<int> CreateCategoriaAsync(CategoriaCreateDto categoriaDto)
        {
            var categoria = new Categoria
            {
                Nombre = categoriaDto.Nombre,
                Descripcion = categoriaDto.Descripcion,
                Estado = categoriaDto.Estado,
            };

            context.Add(categoria);
            await context.SaveChangesAsync();
            return categoria.Id;
        }

        // ACTUALIZAR CATEGORIA
        public async Task UpdateCategoriaAsync(CategoriaCreateDto categoriaDto)
        {
            var categoria = await context.Categorias.FindAsync(categoriaDto.Id);

            if (categoria != null)
            {
                categoria.Nombre = categoriaDto.Nombre;
                categoria.Descripcion = categoriaDto.Descripcion;
                categoria.Estado = categoriaDto.Estado;
                await context.SaveChangesAsync();
            }
        }

        // ELIMINAR CATEGORIA
        public async Task DeleteCategoriaAsync(int categoriaId)
        {
            var categoria = await context.Categorias.FindAsync(categoriaId);

            if (categoria != null)
            {
                categoria.Estado = false;
                await context.SaveChangesAsync();
            }
        }

        // IMPLEMENTACIÓN DE IUnidadDeTrabajo
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
