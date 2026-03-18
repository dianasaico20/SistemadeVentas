namespace SalesSystem.Application.Interactors
{
    public class FormadePagoInteractor(
        IFormadePagoCommandsRepository commands,
        IFormadePagoRepository repository) : IFormadePagoInputPort
    {
        // CREAR FORMA DE PAGO
        public async Task<BaseResponse> CreateFormadePagoAsync(FormadePagoCreateDto formaPagoDto)
        {
            try
            {
                var id = await commands.CreateFormadePagoAsync(formaPagoDto);
                return new BaseResponse
                {
                    StatusType = StatusType.SavedTransaction,
                    StatusCode = 201,
                    Message = "Forma de pago creada satisfactoriamente",
                    Data = id
                };
            }
            catch (Exception ex)
            {
                var detalle = ex.InnerException?.Message ?? "Sin detalles";
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al crear forma de pago: {ex.Message} || Detalle: {detalle}"
                };
            }
        }

        // ACTUALIZAR FORMA DE PAGO
        public async Task<BaseResponse> UpdateFormadePagoAsync(FormadePagoCreateDto formaPagoDto)
        {
            try
            {
                await commands.UpdateFormadePagoAsync(formaPagoDto);
                return new BaseResponse
                {
                    StatusType = StatusType.UpdateTransaction,
                    StatusCode = 200,
                    Message = "Datos de forma de pago actualizados satisfactoriamente",
                    Data = formaPagoDto.Id
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al actualizar forma de pago: {ex.Message}"
                };
            }
        }

        // ELIMINAR FORMA DE PAGO
        public async Task<BaseResponse> DeleteFormadePagoAsync(int formaPagoId)
        {
            try
            {
                await commands.DeleteFormadePagoAsync(formaPagoId);
                return new BaseResponse
                {
                    StatusType = StatusType.DeletedTransaction,
                    StatusCode = 200,
                    Message = "Forma de pago eliminada satisfactoriamente",
                    Data = formaPagoId
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al eliminar forma de pago: {ex.Message}"
                };
            }
        }

        // OBTENER POR ID
        public async Task<FormadePagoResponseDto> GetFormadePagoByIdAsync(int formaPagoId)
        {
            return await repository.GetFormadePagoByIdAsync(formaPagoId);
        }

        // OBTENER TODAS
        public async Task<IEnumerable<FormadePagoResponseDto>> GetFormadePagoAllAsync()
        {
            return await repository.GetFormadePagoAllAsync();
        }
    }
}
