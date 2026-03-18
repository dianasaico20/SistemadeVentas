namespace SalesSystem.Application.Interfaces.Ventas
{
    public interface IVentaRepository
    {
        // Listar por id
        Task<VentaResponseDto> GetVentaByIdAsync(int ventaId);

        // Listar todas las Ventas
        Task<IEnumerable<VentaResponseDto>> GetVentaAllAsync();

        // Listar por cliente
        Task<IEnumerable<VentaResponseDto>> GetVentaByClienteIdAsync(int clienteId);
    }
}
