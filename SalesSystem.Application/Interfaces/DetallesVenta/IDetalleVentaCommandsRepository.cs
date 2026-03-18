namespace SalesSystem.Application.Interfaces.DetallesVenta
{
    public interface IDetalleVentaCommandsRepository : IUnidadDeTrabajo
    {
        // Crear
        Task<int> CreateDetalleVentaAsync(DetalleVentaCreateDto detalleVentaDto);

        // Actualizar
        Task UpdateDetalleVentaAsync(DetalleVentaCreateDto detalleVentaDto);

        // Eliminar
        Task DeleteDetalleVentaAsync(int detalleVentaId);
    }
}
