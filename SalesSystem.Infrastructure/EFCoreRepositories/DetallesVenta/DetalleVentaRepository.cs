namespace SalesSystem.Infrastructure.EFCoreRepositories.DetallesVenta
{
    public class DetalleVentaRepository(
        VentasDbContext context) : IDetalleVentaRepository
    {
        // LISTAR TODOS LOS DETALLES DE VENTA
        public async Task<IEnumerable<DetalleVentaResponseDto>> GetDetalleVentaAllAsync()
        {
            var listaDetalles = await context.DetalleVentas
                .AsNoTracking()
                .Select(d => new DetalleVentaResponseDto
                {
                    Id = d.Id,
                    VentaId = d.VentaId,
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    SubTotal = d.SubTotal,
                })
                .ToListAsync();

            return listaDetalles;
        }

        // LISTAR POR ID
        public async Task<DetalleVentaResponseDto> GetDetalleVentaByIdAsync(int detalleVentaId)
        {
            var detalle = await context.DetalleVentas
                .AsNoTracking()
                .Where(d => d.Id == detalleVentaId)
                .Select(d => new DetalleVentaResponseDto
                {
                    Id = d.Id,
                    VentaId = d.VentaId,
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    SubTotal = d.SubTotal,
                })
                .FirstOrDefaultAsync();

            return detalle;
        }

        // LISTAR POR VENTA
        public async Task<IEnumerable<DetalleVentaResponseDto>> GetDetalleVentaByVentaIdAsync(int ventaId)
        {
            var listaDetalles = await context.DetalleVentas
                .AsNoTracking()
                .Where(d => d.VentaId == ventaId)
                .Select(d => new DetalleVentaResponseDto
                {
                    Id = d.Id,
                    VentaId = d.VentaId,
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    SubTotal = d.SubTotal,
                })
                .ToListAsync();

            return listaDetalles;
        }
    }
}
