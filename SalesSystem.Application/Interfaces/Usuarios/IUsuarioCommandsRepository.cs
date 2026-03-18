namespace SalesSystem.Application.Interfaces.Usuarios
{
    public interface IUsuarioCommandsRepository : IUnidadDeTrabajo
    {
        //  Crear
        Task<int> CreateUsuarioAsync(UsuarioCreateDto usuario);

        // Actualizar
        Task UpdateUsuarioAsync(UsuarioCreateDto usuario);

        // Método específico para cambiar contraseña
        Task UpdateUsuarioPasswordAsync(int usuarioId, string passwordHash);
        // Eliminar
        Task DeleteUsuarioAsync(int usuarioId);


    }
}
