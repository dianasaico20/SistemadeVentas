namespace SalesSystem.Application.Interfaces.DetallesVenta
{
    public interface IDetalleVentaInputPort
    {
        // Crear
        Task<BaseResponse> CreateDetalleVentaAsync(DetalleVentaCreateDto detalleVentaDto);

        // Actualizar
        Task<BaseResponse> UpdateDetalleVentaAsync(DetalleVentaCreateDto detalleVentaDto);

        // Eliminar
        Task<BaseResponse> DeleteDetalleVentaAsync(int detalleVentaId);

        // Listar por id
        Task<DetalleVentaResponseDto> GetDetalleVentaByIdAsync(int detalleVentaId);

        // Listar todos los Detalles de Venta
        Task<IEnumerable<DetalleVentaResponseDto>> GetDetalleVentaAllAsync();

        // Listar por venta
        Task<IEnumerable<DetalleVentaResponseDto>> GetDetalleVentaByVentaIdAsync(int ventaId);
    }
}
