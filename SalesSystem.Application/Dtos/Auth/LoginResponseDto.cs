namespace SalesSystem.Application.Dtos.Auth
{
    public class LoginResponseDto
    {
        public bool Exito { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
    }
}
