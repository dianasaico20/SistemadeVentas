namespace SalesSystem.Infrastructure.EFCoreRepositories.Usuarios
{
    public class UsuarioCommandsRepository(
      VentasDbContext context) : IUsuarioCommandsRepository
    {
        //CREAR USUARIO
        public async Task<int> CreateUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Email = usuarioDto.Email,
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Identificacion = usuarioDto.Identificacion,
                // Encriptamos la contraseña aquí al crear
                Contraseña = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Contraseña),
                Rol = usuarioDto.Rol,
                Estado = usuarioDto.Estado,
                FechaRegistro = DateTime.UtcNow
            };

            context.Add(usuario);
            await context.SaveChangesAsync();
            return usuario.Id;
        }

        // ELIMINAR USUARIO
        public async Task DeleteUsuarioAsync(int usuarioId)
        {
            var usuario = await context.Usuarios.FindAsync(usuarioId);

            if (usuario != null)
            {
                usuario.Estado = false;
                await context.SaveChangesAsync();
            }
        }

        //IMPLEMENTACIÓN DE IUnidadDeTrabajo
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        // ACTUALIZAR DATOS BÁSICOS (PERFIL)
        public async Task UpdateUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            var usuario = await context.Usuarios.FindAsync(usuarioDto.Id);

            if (usuario != null)
            {
                usuario.Email = usuarioDto.Email;
                usuario.Rol = usuarioDto.Rol;
                usuario.Estado = usuarioDto.Estado;
                usuario.Nombre = usuarioDto.Nombre;
                usuario.Apellido = usuarioDto.Apellido;
                usuario.Identificacion = usuarioDto.Identificacion;
                await context.SaveChangesAsync();
            }
        }

        //ACTUALIZAR SOLO CONTRASEÑA
        public async Task UpdateUsuarioPasswordAsync(int usuarioId, string passwordHash)
        {
            var usuario = await context.Usuarios.FindAsync(usuarioId);

            if (usuario != null)
            {
                usuario.Contraseña = passwordHash;
                // Entity Framework detecta que solo cambió este campo y genera un UPDATE optimizado
                await context.SaveChangesAsync();
            }
        }
    }
}
