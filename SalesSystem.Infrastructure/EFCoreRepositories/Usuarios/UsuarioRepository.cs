
namespace SalesSystem.Infrastructure.EFCoreRepositories.Usuarios
{
    public class UsuarioRepository(
        VentasDbContext context) : IUsuarioRepository
    {
        // LISTAR TODOS LOS USUARIOS
        public async Task<IEnumerable<UsuarioResponseDto>> GetUsuarioAllAsync()
        {
            var listaUsuarios = await context.Usuarios
                .AsNoTracking() 
                .Select(u => new UsuarioResponseDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Identificacion = u.Identificacion,
                    Rol = u.Rol,
                    Estado = u.Estado,
                    FechaRegistro = u.FechaRegistro,
                })
                .ToListAsync();

            return listaUsuarios;
        }

        //lISTAR POR ID 
        public async Task<UsuarioResponseDto> GetUsuarioByIdAsync(int usuarioId)
        {
            var usuario = await context.Usuarios
                .AsNoTracking()
                .Where(u => u.Id == usuarioId)
                .Select(u => new UsuarioResponseDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Identificacion = u.Identificacion,
                    Rol = u.Rol,
                    Estado = u.Estado,
                    FechaRegistro = u.FechaRegistro,
                })
                .FirstOrDefaultAsync();

            return usuario;
        }

        //OBTENER SOLO EL HASH 
        public async Task<string?> GetUsuarioPasswordHashAsync(int id)
        {
            var hash = await context.Usuarios
                .Where(u => u.Id == id)
                .Select(u => u.Contraseña) // Solo traemos la columna string de la contraseña
                .FirstOrDefaultAsync();

            return hash; // Retornamos  el texto encriptado o null si no existe
        }
        //Listar por email

        public async Task<Usuario?> GetUsuarioByEmailAsync(string email)
        {
            var usuario = await context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            return usuario;
        }
  
    }
}
