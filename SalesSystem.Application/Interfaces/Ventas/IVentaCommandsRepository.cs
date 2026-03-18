namespace SalesSystem.Application.Interfaces.Ventas
{
    public interface IVentaCommandsRepository : IUnidadDeTrabajo
    {
        // Crear
        Task<int> CreateVentaAsync(VentaCreateDto ventaDto);

        // Actualizar
        Task UpdateVentaAsync(VentaCreateDto ventaDto);

        // Eliminar
        Task DeleteVentaAsync(int ventaId);
    }
}
