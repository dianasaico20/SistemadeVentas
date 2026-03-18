namespace SalesSystem.Application.Interfaces.Clientes
{
    public interface IClienteCommandsRepository : IUnidadDeTrabajo
    {
        //  Crear
        Task<int> CreateClienteAsync(ClienteCreateDto clienteDto);

        // Actualizar
        Task UpdateClienteAsync(ClienteCreateDto clienteDto);

        // Eliminar
        Task DeleteClienteAsync(int clienteId);


    }
}
