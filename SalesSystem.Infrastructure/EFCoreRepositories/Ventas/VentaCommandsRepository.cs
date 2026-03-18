namespace SalesSystem.Infrastructure.EFCoreRepositories.Ventas
{
    public class VentaCommandsRepository(
        VentasDbContext context) : IVentaCommandsRepository
    {
        // CREAR VENTA (incluye sus detalles)
        public async Task<int> CreateVentaAsync(VentaCreateDto ventaDto)
        {
            var venta = new Venta
            {
                FechaVenta = ventaDto.FechaVenta,
                NumeroComprobante = ventaDto.NumeroComprobante,
                ClienteId = ventaDto.ClienteId,
                UsuarioId = ventaDto.UsuarioId,
                SubTotal = ventaDto.SubTotal,
                Descuento = ventaDto.Descuento,
                ImpuestoTotal = ventaDto.ImpuestoTotal,
                Total = ventaDto.Total,
                FormadePagoId = ventaDto.FormadePagoId,
                Estado = ventaDto.Estado,
                DetallesVenta = ventaDto.DetallesVenta.Select(d => new DetalleVenta
                {
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    SubTotal = d.SubTotal,
                }).ToList(),
            };

            context.Add(venta);
            await context.SaveChangesAsync();
            return venta.Id;
        }

        // ACTUALIZAR VENTA
        public async Task UpdateVentaAsync(VentaCreateDto ventaDto)
        {
            var venta = await context.Ventas.FindAsync(ventaDto.Id);

            if (venta != null)
            {
                venta.FechaVenta = ventaDto.FechaVenta;
                venta.NumeroComprobante = ventaDto.NumeroComprobante;
                venta.ClienteId = ventaDto.ClienteId;
                venta.UsuarioId = ventaDto.UsuarioId;
                venta.SubTotal = ventaDto.SubTotal;
                venta.Descuento = ventaDto.Descuento;
                venta.ImpuestoTotal = ventaDto.ImpuestoTotal;
                venta.Total = ventaDto.Total;
                venta.FormadePagoId = ventaDto.FormadePagoId;
                venta.Estado = ventaDto.Estado;
                await context.SaveChangesAsync();
            }
        }

        // ELIMINAR VENTA
        public async Task DeleteVentaAsync(int ventaId)
        {
            var venta = await context.Ventas.FindAsync(ventaId);

            if (venta != null)
            {
                context.Remove(venta);
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
