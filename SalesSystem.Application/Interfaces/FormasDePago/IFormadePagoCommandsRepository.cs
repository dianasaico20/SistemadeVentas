namespace SalesSystem.Application.Interfaces.FormasDePago
{
    public interface IFormadePagoCommandsRepository : IUnidadDeTrabajo
    {
        // Crear
        Task<int> CreateFormadePagoAsync(FormadePagoCreateDto formaPagoDto);

        // Actualizar
        Task UpdateFormadePagoAsync(FormadePagoCreateDto formaPagoDto);

        // Eliminar
        Task DeleteFormadePagoAsync(int formaPagoId);
    }
}
