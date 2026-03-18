
namespace SalesSystem.Application.Interactors
{
    public class UsuarioInteractor(
       IUsuarioCommandsRepository commands,
       IUsuarioRepository repository) : IUsuarioInputPort
    {
        //CREAR USUARIO
        public async Task<BaseResponse> CreateUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            try
            {
                // El repositorio se encarga de encriptar la contraseña inicial
                var id = await commands.CreateUsuarioAsync(usuarioDto);
                return new BaseResponse
                {
                    StatusType = StatusType.SavedTransaction,
                    StatusCode = 201,
                    Message = "Usuario creado satisfactoriamente",
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
                    Message = $"Error al crear usuario: {ex.Message} || Detalle: {detalle}"
                };
            }
        }

        // ELIMINAR USUARIO
        public async Task<BaseResponse> DeleteUsuarioAsync(int usuarioId)
        {
            try
            {
                await commands.DeleteUsuarioAsync(usuarioId);
                return new BaseResponse
                {
                    StatusType = StatusType.DeletedTransaction,
                    StatusCode = 200,
                    Message = "Usuario eliminado satisfactoriamente",
                    Data = usuarioId
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al eliminar usuario: {ex.Message}"
                };
            }
        }

        // OBTENER TODOS 
        public async Task<IEnumerable<UsuarioResponseDto>> GetUsuarioAllAsync()
        {
            return await repository.GetUsuarioAllAsync();
        }

        // OBTENER POR ID 
        public async Task<UsuarioResponseDto> GetUsuarioByIdAsync(int usuarioId)
        {
            return await repository.GetUsuarioByIdAsync(usuarioId);
        }

        // ACTUALIZAR DATOS BÁSICOS
        public async Task<BaseResponse> UpdateUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            try
            {
                await commands.UpdateUsuarioAsync(usuarioDto);

                return new BaseResponse
                {
                    StatusType = StatusType.UpdateTransaction,
                    StatusCode = 200,
                    Message = "Datos de usuario actualizados satisfactoriamente",
                    Data = usuarioDto.Id
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al actualizar usuario: {ex.Message}"
                };
            }
        }

        // ACTUALIZAR CONTRASEÑA
        // Este método valida la anterior y encripta la nueva
        public async Task<BaseResponse> UpdateUsuarioPasswordAsync(UsuarioChangePasswordDto userchanpassDto)
        {
            try
            {
                // PASO 1: Traer el hash actual de la BD
                string? hashActualEnBD = await repository.GetUsuarioPasswordHashAsync(userchanpassDto.Id);

                if (string.IsNullOrEmpty(hashActualEnBD))
                {
                    return new BaseResponse
                    {
                        StatusType = StatusType.Error,
                        StatusCode = 404,
                        Message = "Usuario no encontrado."
                    };
                }

                // PASO 2: Validar que la contraseña actual sea correcta
                bool esCorrecta = BCrypt.Net.BCrypt.Verify(userchanpassDto.PasswordActual, hashActualEnBD);

                if (!esCorrecta)
                {
                    return new BaseResponse
                    {
                        StatusType = StatusType.Error,
                        StatusCode = 400,
                        Message = "La contraseña actual es incorrecta."
                    };
                }

                // PASO 3: Encriptar la NUEVA contraseña
                string nuevoHash = BCrypt.Net.BCrypt.HashPassword(userchanpassDto.NuevoPassword);

                // PASO 4: Guardar
                await commands.UpdateUsuarioPasswordAsync(userchanpassDto.Id, nuevoHash);

                return new BaseResponse
                {
                    StatusType = StatusType.UpdateTransaction,
                    StatusCode = 200,
                    Message = "Contraseña actualizada satisfactoriamente"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    StatusType = StatusType.Error,
                    StatusCode = 500,
                    Message = $"Error al cambiar contraseña: {ex.Message}"
                };
            }
        }
    }
}
