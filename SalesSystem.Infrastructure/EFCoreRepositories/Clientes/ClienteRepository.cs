
namespace SalesSystem.Infrastructure.EFCoreRepositories.Clientes
{
  public  class ClienteRepository(
        VentasDbContext context) : IClienteRepository

    {
        public async Task<IEnumerable<ClienteResponseDto>> GetClienteAllAsync()
        {
            var listaClientes = await context.Clientes
                .AsNoTracking()
                .Select(u => new ClienteResponseDto
                {
                    Id = u.Id,
                    TipoDocumento = u.TipoDocumento,
                    NumeroDocumento = u.NumeroDocumento,
                    NombreCompleto = u.NombreCompleto,
                    Correo = u.Correo,
                    Telefono = u.Telefono,
                    Direccion = u.Direccion,
                    Estado = u.Estado,
                    FechaRegistro = u.FechaRegistro,
                })
                .ToListAsync();

            return listaClientes;
        }

        public async Task<ClienteResponseDto> GetClienteByIdAsync(int clienteId)
        {
            var cliente = await context.Clientes
                .AsNoTracking()
                .Where(c => c.Id == clienteId)
                .Select(c => new ClienteResponseDto
                {
                    Id = c.Id,
                    TipoDocumento = c.TipoDocumento,
                    NumeroDocumento = c.NumeroDocumento,
                    NombreCompleto = c.NombreCompleto,
                    Correo = c.Correo,
                    Telefono = c.Telefono,
                    Direccion = c.Direccion,
                    Estado = c.Estado,
                    FechaRegistro = c.FechaRegistro,
                })
                .FirstOrDefaultAsync();

            return cliente;
        }
    }
}
