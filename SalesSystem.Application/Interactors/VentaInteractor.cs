namespace SalesSystem.Application.Interactors
{
    public class VentaInteractor(
        IVentaCommandsRepository commands,
        IVentaRepository repository) : IVentaInputPort
    {
        // CREAR VENTA
        public async Task<BaseResponse> CreateVentaAsync(VentaCreateDto ventaDto)
        {
            try
            {
                var id = await commands.CreateVentaAsync(ventaDto);
                return new BaseResponse
                {
                    StatusType = StatusType.SavedTransaction,
                    StatusCode = 201,
                    Message = "Venta creada satisfactoriamente",
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
                    Message = $"Error al crear venta: {ex.Message} || Detalle: {detalle}"
                };
            }
        }

        // ACTUALIZAR VENTA
        public async Task<BaseResponse> UpdateVentaAsync(VentaCreateDto ventaDto)
        {
            try
            {
                await commands.UpdateVentaAsync(ventaDto);
                return new BaseResponse
                {
                    StatusType = StatusType.UpdateTransaction,
                    StatusCode = 200,
                    Message = "Datos de venta actualizados satisfactoriamente",
                    Data = ventaDto.Id
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al actualizar venta: {ex.Message}"
                };
            }
        }

        // ELIMINAR VENTA
        public async Task<BaseResponse> DeleteVentaAsync(int ventaId)
        {
            try
            {
                await commands.DeleteVentaAsync(ventaId);
                return new BaseResponse
                {
                    StatusType = StatusType.DeletedTransaction,
                    StatusCode = 200,
                    Message = "Venta eliminada satisfactoriamente",
                    Data = ventaId
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al eliminar venta: {ex.Message}"
                };
            }
        }

        // OBTENER POR ID
        public async Task<VentaResponseDto> GetVentaByIdAsync(int ventaId)
        {
            return await repository.GetVentaByIdAsync(ventaId);
        }

        // OBTENER TODAS
        public async Task<IEnumerable<VentaResponseDto>> GetVentaAllAsync()
        {
            return await repository.GetVentaAllAsync();
        }

        // OBTENER POR CLIENTE
        public async Task<IEnumerable<VentaResponseDto>> GetVentaByClienteIdAsync(int clienteId)
        {
            return await repository.GetVentaByClienteIdAsync(clienteId);
        }
    }
}
