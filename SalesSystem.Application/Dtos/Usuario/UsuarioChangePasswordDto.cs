namespace SalesSystem.Application.Dtos.Usuario
{
    public class UsuarioChangePasswordDto
    {

        public int Id { get; set; } // De quién es la cuenta
        public string PasswordActual { get; set; } //  verificar que es él
        public string NuevoPassword { get; set; } // La nueva clave
        public string ConfirmarPassword { get; set; } // Para validaciones

    }
}
