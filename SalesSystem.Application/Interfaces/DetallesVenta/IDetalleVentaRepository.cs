namespace SalesSystem.Application.Interfaces.DetallesVenta
{
    public interface IDetalleVentaRepository
    {
        // Listar por id
        Task<DetalleVentaResponseDto> GetDetalleVentaByIdAsync(int detalleVentaId);

        // Listar todos los Detalles de Venta
        Task<IEnumerable<DetalleVentaResponseDto>> GetDetalleVentaAllAsync();

        // Listar por venta
        Task<IEnumerable<DetalleVentaResponseDto>> GetDetalleVentaByVentaIdAsync(int ventaId);
    }
}
