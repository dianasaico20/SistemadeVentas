namespace SalesSystem.Infrastructure.EFCoreRepositories.DetallesVenta
{
    public class DetalleVentaCommandsRepository(
        VentasDbContext context) : IDetalleVentaCommandsRepository
    {
        // CREAR DETALLE DE VENTA
        public async Task<int> CreateDetalleVentaAsync(DetalleVentaCreateDto detalleVentaDto)
        {
            var detalle = new DetalleVenta
            {
                VentaId = detalleVentaDto.VentaId,
                ProductoId = detalleVentaDto.ProductoId,
                Cantidad = detalleVentaDto.Cantidad,
                PrecioUnitario = detalleVentaDto.PrecioUnitario,
                SubTotal = detalleVentaDto.SubTotal,
            };

            context.Add(detalle);
            await context.SaveChangesAsync();
            return detalle.Id;
        }

        // ACTUALIZAR DETALLE DE VENTA
        public async Task UpdateDetalleVentaAsync(DetalleVentaCreateDto detalleVentaDto)
        {
            var detalle = await context.DetalleVentas.FindAsync(detalleVentaDto.Id);

            if (detalle != null)
            {
                detalle.VentaId = detalleVentaDto.VentaId;
                detalle.ProductoId = detalleVentaDto.ProductoId;
                detalle.Cantidad = detalleVentaDto.Cantidad;
                detalle.PrecioUnitario = detalleVentaDto.PrecioUnitario;
                detalle.SubTotal = detalleVentaDto.SubTotal;
                await context.SaveChangesAsync();
            }
        }

        // ELIMINAR DETALLE DE VENTA
        public async Task DeleteDetalleVentaAsync(int detalleVentaId)
        {
            var detalle = await context.DetalleVentas.FindAsync(detalleVentaId);

            if (detalle != null)
            {
                // Aquí SÍ usamos Remove porque es una entidad débil/temporal
                context.Remove(detalle);
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
