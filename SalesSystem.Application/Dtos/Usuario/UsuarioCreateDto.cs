namespace SalesSystem.Application.Dtos.Usuario
{
    public class UsuarioCreateDto

    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public RolesEnum Rol { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

    }
}
