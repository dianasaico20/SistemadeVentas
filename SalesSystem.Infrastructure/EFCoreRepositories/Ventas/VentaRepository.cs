namespace SalesSystem.Infrastructure.EFCoreRepositories.Ventas
{
    public class VentaRepository(
        VentasDbContext context) : IVentaRepository
    {
        // LISTAR TODAS LAS VENTAS
        public async Task<IEnumerable<VentaResponseDto>> GetVentaAllAsync()
        {
            var listaVentas = await context.Ventas
                .AsNoTracking()
                .Select(v => new VentaResponseDto
                {
                    Id = v.Id,
                    FechaVenta = v.FechaVenta,
                    NumeroComprobante = v.NumeroComprobante,
                    ClienteId = v.ClienteId,
                    UsuarioId = v.UsuarioId,
                    SubTotal = v.SubTotal,
                    Descuento = v.Descuento,
                    ImpuestoTotal = v.ImpuestoTotal,
                    Total = v.Total,
                    FormadePagoId = v.FormadePagoId,
                    Estado = v.Estado,
                    DetallesVenta = v.DetallesVenta.Select(d => new DetalleVentaResponseDto
                    {
                        Id = d.Id,
                        VentaId = d.VentaId,
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        SubTotal = d.SubTotal,
                    }).ToList(),
                })
                .ToListAsync();

            return listaVentas;
        }

        // LISTAR POR ID
        public async Task<VentaResponseDto> GetVentaByIdAsync(int ventaId)
        {
            var venta = await context.Ventas
                .AsNoTracking()
                .Where(v => v.Id == ventaId)
                .Select(v => new VentaResponseDto
                {
                    Id = v.Id,
                    FechaVenta = v.FechaVenta,
                    NumeroComprobante = v.NumeroComprobante,
                    ClienteId = v.ClienteId,
                    UsuarioId = v.UsuarioId,
                    SubTotal = v.SubTotal,
                    Descuento = v.Descuento,
                    ImpuestoTotal = v.ImpuestoTotal,
                    Total = v.Total,
                    FormadePagoId = v.FormadePagoId,
                    Estado = v.Estado,
                    DetallesVenta = v.DetallesVenta.Select(d => new DetalleVentaResponseDto
                    {
                        Id = d.Id,
                        VentaId = d.VentaId,
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        SubTotal = d.SubTotal,
                    }).ToList(),
                })
                .FirstOrDefaultAsync();

            return venta;
        }

        // LISTAR POR CLIENTE
        public async Task<IEnumerable<VentaResponseDto>> GetVentaByClienteIdAsync(int clienteId)
        {
            var listaVentas = await context.Ventas
                .AsNoTracking()
                .Where(v => v.ClienteId == clienteId)
                .Select(v => new VentaResponseDto
                {
                    Id = v.Id,
                    FechaVenta = v.FechaVenta,
                    NumeroComprobante = v.NumeroComprobante,
                    ClienteId = v.ClienteId,
                    UsuarioId = v.UsuarioId,
                    SubTotal = v.SubTotal,
                    Descuento = v.Descuento,
                    ImpuestoTotal = v.ImpuestoTotal,
                    Total = v.Total,
                    FormadePagoId = v.FormadePagoId,
                    Estado = v.Estado,
                    DetallesVenta = v.DetallesVenta.Select(d => new DetalleVentaResponseDto
                    {
                        Id = d.Id,
                        VentaId = d.VentaId,
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        SubTotal = d.SubTotal,
                    }).ToList(),
                })
                .ToListAsync();

            return listaVentas;
        }
    }
}
