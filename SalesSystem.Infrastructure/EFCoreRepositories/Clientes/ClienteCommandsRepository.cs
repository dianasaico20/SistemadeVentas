
namespace SalesSystem.Infrastructure.EFCoreRepositories.Clientes
{
    public class ClienteCommandsRepository(
            VentasDbContext context) : IClienteCommandsRepository
    {
        public async Task<int> CreateClienteAsync(ClienteCreateDto clienteDto)
        {
            var cliente = new Cliente
            {
                TipoDocumento = clienteDto.TipoDocumento,
                NumeroDocumento = clienteDto.NumeroDocumento,
                NombreCompleto = clienteDto.NombreCompleto,
                Correo = clienteDto.Correo,
                Telefono = clienteDto.Telefono,
                Direccion = clienteDto.Direccion,
                Estado = clienteDto.Estado,
                FechaRegistro = DateTime.UtcNow,
            };

            context.Add(cliente);
            await context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task DeleteClienteAsync(int clienteId)
        {
            var cliente = await context.Clientes.FindAsync(clienteId);

            if (cliente != null)
            {
                // Eliminado lógico: solo cambiamos el estado a false (inactivo)
                cliente.Estado = false;

                // Guardamos los cambios. EF Core hará un UPDATE en lugar de un DELETE
                await context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(ClienteCreateDto clienteDto)
        {
            var cliente = await context.Clientes.FindAsync(clienteDto.Id);

            if (cliente != null)
            {
                cliente.TipoDocumento = clienteDto.TipoDocumento;
                cliente.NumeroDocumento = clienteDto.NumeroDocumento;
                cliente.NombreCompleto = clienteDto.NombreCompleto;
                cliente.Correo = clienteDto.Correo;
                cliente.Telefono = clienteDto.Telefono;
                cliente.Direccion = clienteDto.Direccion;
                cliente.Estado = clienteDto.Estado;
                await context.SaveChangesAsync();
            }
        }
    }
}
