namespace SalesSystem.Application.Interfaces.Usuarios
{
    public interface IUsuarioInputPort
    {

        //  Crear
        Task<BaseResponse> CreateUsuarioAsync(UsuarioCreateDto usuarioDto);

        // Actualizar
        Task<BaseResponse> UpdateUsuarioAsync(UsuarioCreateDto usuarioDto);
        // Actualizar contraseña 
        Task<BaseResponse> UpdateUsuarioPasswordAsync(UsuarioChangePasswordDto dto);
        // Eliminar
        Task<BaseResponse> DeleteUsuarioAsync(int usuarioId);

        // Listar por id
        Task<UsuarioResponseDto> GetUsuarioByIdAsync(int usuarioId);

        // Listar todos los usuarios
        Task<IEnumerable<UsuarioResponseDto>> GetUsuarioAllAsync();


    }
}
