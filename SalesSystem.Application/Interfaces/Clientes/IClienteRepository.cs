namespace SalesSystem.Application.Interfaces.Clientes
{
    public interface IClienteRepository
    {
        // Listar por id
        Task<ClienteResponseDto> GetClienteByIdAsync(int clienteId);

        // Listar todos los Clientes
        Task<IEnumerable<ClienteResponseDto>> GetClienteAllAsync();
    }
}
