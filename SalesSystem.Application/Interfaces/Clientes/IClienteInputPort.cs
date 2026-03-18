namespace SalesSystem.Application.Interfaces.Clientes
{
    public interface IClienteInputPort
    {
        //  Crear
        Task<BaseResponse> CreateClienteAsync(ClienteCreateDto clienteDto);

        // Actualizar
        Task<BaseResponse> UpdateClienteAsync(ClienteCreateDto clienteDto);

        // Eliminar
        Task<BaseResponse> DeleteClienteAsync(int clienteId);

        // Listar por id
        Task<ClienteResponseDto> GetClienteByIdAsync(int clienteId);

        // Listar todos los Clientes
        Task<IEnumerable<ClienteResponseDto>> GetClienteAllAsync();
    }
}
