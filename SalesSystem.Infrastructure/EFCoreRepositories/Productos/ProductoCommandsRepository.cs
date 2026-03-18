namespace SalesSystem.Infrastructure.EFCoreRepositories.Productos
{
    public class ProductoCommandsRepository(
        VentasDbContext context) : IProductoCommandsRepository
    {
        // CREAR PRODUCTO
        public async Task<int> CreateProductoAsync(ProductoCreateDto productoDto)
        {
            var producto = new Producto
            {
                Codigo = productoDto.Codigo,
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                CategoriaId = productoDto.CategoriaId,
                PrecioVenta = productoDto.PrecioVenta,
                PrecioCompra = productoDto.PrecioCompra,
                Stock = productoDto.Stock,
                ImagenUrl = productoDto.ImagenUrl,
                Estado = productoDto.Estado,
            };

            context.Add(producto);
            await context.SaveChangesAsync();
            return producto.Id;
        }

        // ACTUALIZAR PRODUCTO
        public async Task UpdateProductoAsync(ProductoCreateDto productoDto)
        {
            var producto = await context.Productos.FindAsync(productoDto.Id);

            if (producto != null)
            {
                producto.Codigo = productoDto.Codigo;
                producto.Nombre = productoDto.Nombre;
                producto.Descripcion = productoDto.Descripcion;
                producto.CategoriaId = productoDto.CategoriaId;
                producto.PrecioVenta = productoDto.PrecioVenta;
                producto.PrecioCompra = productoDto.PrecioCompra;
                producto.Stock = productoDto.Stock;
                producto.ImagenUrl = productoDto.ImagenUrl;
                producto.Estado = productoDto.Estado;
                await context.SaveChangesAsync();
            }
        }

        // ELIMINAR PRODUCTO
        public async Task DeleteProductoAsync(int productoId)
        {
            var producto = await context.Productos.FindAsync(productoId);

            if (producto != null)
            {
                producto.Estado = false;
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
