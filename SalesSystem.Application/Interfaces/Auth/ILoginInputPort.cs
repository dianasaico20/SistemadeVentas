namespace SalesSystem.Application.Interfaces.Auth
{
    public interface ILoginInputPort
    {
        // Método único para iniciar sesión
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
