namespace SalesSystem.Application.Interactors
{
    public class DetalleVentaInteractor(
        IDetalleVentaCommandsRepository commands,
        IDetalleVentaRepository repository) : IDetalleVentaInputPort
    {
        // CREAR DETALLE DE VENTA
        public async Task<BaseResponse> CreateDetalleVentaAsync(DetalleVentaCreateDto detalleVentaDto)
        {
            try
            {
                var id = await commands.CreateDetalleVentaAsync(detalleVentaDto);
                return new BaseResponse
                {
                    StatusType = StatusType.SavedTransaction,
                    StatusCode = 201,
                    Message = "Detalle de venta creado satisfactoriamente",
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
                    Message = $"Error al crear detalle de venta: {ex.Message} || Detalle: {detalle}"
                };
            }
        }

        // ACTUALIZAR DETALLE DE VENTA
        public async Task<BaseResponse> UpdateDetalleVentaAsync(DetalleVentaCreateDto detalleVentaDto)
        {
            try
            {
                await commands.UpdateDetalleVentaAsync(detalleVentaDto);
                return new BaseResponse
                {
                    StatusType = StatusType.UpdateTransaction,
                    StatusCode = 200,
                    Message = "Detalle de venta actualizado satisfactoriamente",
                    Data = detalleVentaDto.Id
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al actualizar detalle de venta: {ex.Message}"
                };
            }
        }

        // ELIMINAR DETALLE DE VENTA
        public async Task<BaseResponse> DeleteDetalleVentaAsync(int detalleVentaId)
        {
            try
            {
                await commands.DeleteDetalleVentaAsync(detalleVentaId);
                return new BaseResponse
                {
                    StatusType = StatusType.DeletedTransaction,
                    StatusCode = 200,
                    Message = "Detalle de venta eliminado satisfactoriamente",
                    Data = detalleVentaId
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al eliminar detalle de venta: {ex.Message}"
                };
            }
        }

        // OBTENER POR ID
        public async Task<DetalleVentaResponseDto> GetDetalleVentaByIdAsync(int detalleVentaId)
        {
            return await repository.GetDetalleVentaByIdAsync(detalleVentaId);
        }

        // OBTENER TODOS
        public async Task<IEnumerable<DetalleVentaResponseDto>> GetDetalleVentaAllAsync()
        {
            return await repository.GetDetalleVentaAllAsync();
        }

        // OBTENER POR VENTA
        public async Task<IEnumerable<DetalleVentaResponseDto>> GetDetalleVentaByVentaIdAsync(int ventaId)
        {
            return await repository.GetDetalleVentaByVentaIdAsync(ventaId);
        }
    }
}
