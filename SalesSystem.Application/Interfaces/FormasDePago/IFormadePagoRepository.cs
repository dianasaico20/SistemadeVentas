namespace SalesSystem.Application.Interfaces.FormasDePago
{
    public interface IFormadePagoRepository
    {
        // Listar por id
        Task<FormadePagoResponseDto> GetFormadePagoByIdAsync(int formaPagoId);

        // Listar todas las Formas de Pago
        Task<IEnumerable<FormadePagoResponseDto>> GetFormadePagoAllAsync();
    }
}
