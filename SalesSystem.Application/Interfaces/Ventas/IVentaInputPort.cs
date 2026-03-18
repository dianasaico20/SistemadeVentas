namespace SalesSystem.Application.Interfaces.Ventas
{
    public interface IVentaInputPort
    {
        // Crear
        Task<BaseResponse> CreateVentaAsync(VentaCreateDto ventaDto);

        // Actualizar
        Task<BaseResponse> UpdateVentaAsync(VentaCreateDto ventaDto);

        // Eliminar
        Task<BaseResponse> DeleteVentaAsync(int ventaId);

        // Listar por id
        Task<VentaResponseDto> GetVentaByIdAsync(int ventaId);

        // Listar todas las Ventas
        Task<IEnumerable<VentaResponseDto>> GetVentaAllAsync();

        // Listar por cliente
        Task<IEnumerable<VentaResponseDto>> GetVentaByClienteIdAsync(int clienteId);
    }
}
