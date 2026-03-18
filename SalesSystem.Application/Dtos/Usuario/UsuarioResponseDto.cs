namespace SalesSystem.Application.Dtos.Usuario
{
    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public RolesEnum Rol { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
