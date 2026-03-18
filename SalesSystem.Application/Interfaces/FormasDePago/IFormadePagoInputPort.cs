namespace SalesSystem.Application.Interfaces.FormasDePago
{
    public interface IFormadePagoInputPort
    {
        // Crear
        Task<BaseResponse> CreateFormadePagoAsync(FormadePagoCreateDto formaPagoDto);

        // Actualizar
        Task<BaseResponse> UpdateFormadePagoAsync(FormadePagoCreateDto formaPagoDto);

        // Eliminar
        Task<BaseResponse> DeleteFormadePagoAsync(int formaPagoId);

        // Listar por id
        Task<FormadePagoResponseDto> GetFormadePagoByIdAsync(int formaPagoId);

        // Listar todas las Formas de Pago
        Task<IEnumerable<FormadePagoResponseDto>> GetFormadePagoAllAsync();
    }
}
