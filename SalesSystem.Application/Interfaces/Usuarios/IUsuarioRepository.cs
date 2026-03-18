namespace SalesSystem.Application.Interfaces.Usuarios
{
    public interface IUsuarioRepository
    {
        // Listar por id
        Task<UsuarioResponseDto> GetUsuarioByIdAsync(int usuarioId);
  
        // Listar todos los usuarios
        Task<IEnumerable<UsuarioResponseDto>> GetUsuarioAllAsync();
        // Obtener el hash de la contraseña de un usuario por su ID
        Task<string?> GetUsuarioPasswordHashAsync(int id);
        Task<Usuario?> GetUsuarioByEmailAsync(string email);


    }
}
