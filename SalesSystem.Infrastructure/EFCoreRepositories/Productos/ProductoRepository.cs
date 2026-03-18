namespace SalesSystem.Infrastructure.EFCoreRepositories.Productos
{
    public class ProductoRepository(
        VentasDbContext context) : IProductoRepository
    {
        // LISTAR TODOS LOS PRODUCTOS
        public async Task<IEnumerable<ProductoResponseDto>> GetProductoAllAsync()
        {
            var listaProductos = await context.Productos
                .AsNoTracking()
                .Select(p => new ProductoResponseDto
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    CategoriaId = p.CategoriaId,
                    PrecioVenta = p.PrecioVenta,
                    PrecioCompra = p.PrecioCompra,
                    Stock = p.Stock,
                    ImagenUrl = p.ImagenUrl,
                    Estado = p.Estado,
                })
                .ToListAsync();

            return listaProductos;
        }

        // LISTAR POR ID
        public async Task<ProductoResponseDto> GetProductoByIdAsync(int productoId)
        {
            var producto = await context.Productos
                .AsNoTracking()
                .Where(p => p.Id == productoId)
                .Select(p => new ProductoResponseDto
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    CategoriaId = p.CategoriaId,
                    PrecioVenta = p.PrecioVenta,
                    PrecioCompra = p.PrecioCompra,
                    Stock = p.Stock,
                    ImagenUrl = p.ImagenUrl,
                    Estado = p.Estado,
                })
                .FirstOrDefaultAsync();

            return producto;
        }

        // LISTAR POR CATEGORIA
        public async Task<IEnumerable<ProductoResponseDto>> GetProductoByCategoriaIdAsync(int categoriaId)
        {
            var listaProductos = await context.Productos
                .AsNoTracking()
                .Where(p => p.CategoriaId == categoriaId)
                .Select(p => new ProductoResponseDto
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    CategoriaId = p.CategoriaId,
                    PrecioVenta = p.PrecioVenta,
                    PrecioCompra = p.PrecioCompra,
                    Stock = p.Stock,
                    ImagenUrl = p.ImagenUrl,
                    Estado = p.Estado,
                })
                .ToListAsync();

            return listaProductos;
        }
    }
}
