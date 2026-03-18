namespace SalesSystem.Application.Interactors
{
    public class ClienteInteractor(
           IClienteCommandsRepository commands,
           IClienteRepository repository) : IClienteInputPort

    {
        public  async Task<BaseResponse> CreateClienteAsync(ClienteCreateDto clienteDto)
        {
            try
            {
                // El repositorio se encarga de encriptar la contraseña inicial
                var id = await commands.CreateClienteAsync(clienteDto);
                return new BaseResponse
                {
                    StatusType = StatusType.SavedTransaction,
                    StatusCode = 201,
                    Message = "Cliente creado satisfactoriamente",
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
                    Message = $"Error al crear cliente: {ex.Message} || Detalle: {detalle}"
                };
            }
        }

        public async Task<BaseResponse> DeleteClienteAsync(int clienteId)
        {

            try
            {
                await commands.DeleteClienteAsync(clienteId);
                return new BaseResponse
                {
                    StatusType = StatusType.DeletedTransaction,
                    StatusCode = 200,
                    Message = "Cliente eliminado satisfactoriamente",
                    Data = clienteId
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al eliminar cliente: {ex.Message}"
                };
            }
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetClienteAllAsync()
        {
            return await repository.GetClienteAllAsync();
        }

        public async Task<ClienteResponseDto> GetClienteByIdAsync(int clienteId)
        {
            return await repository.GetClienteByIdAsync(clienteId);

        }

        public async Task<BaseResponse> UpdateClienteAsync(ClienteCreateDto clienteDto)
        {
            try
            {
                await commands.UpdateClienteAsync(clienteDto);

                return new BaseResponse
                {
                    StatusType = StatusType.UpdateTransaction,
                    StatusCode = 200,
                    Message = "Datos de cliente actualizados satisfactoriamente",
                    Data = clienteDto.Id
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al actualizar cliente: {ex.Message}"
                };
            }
        }
    }
}
