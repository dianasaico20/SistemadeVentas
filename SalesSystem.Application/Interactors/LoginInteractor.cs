namespace SalesSystem.Application.Interactors
{
    public class LoginInteractor(
        IUsuarioRepository repository,
        IConfiguration configuration) : ILoginInputPort
    {
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            try
            {
                // 1. BUSCAR USUARIO POR EMAIL
                // Usamos el método que agregamos al repositorio de lectura
                var usuario = await repository.GetUsuarioByEmailAsync(request.Email);

                // Validación: Si no existe el usuario
                if (usuario == null)
                {
                    return new LoginResponseDto
                    {
                        Exito = false,
                        Mensaje = "Usuario no encontrado",
                        Token = ""
                    };
                }

                // 2. VERIFICAR CONTRASEÑA
                // Comparamos la contraseña plana que llega (request) con el Hash de la BD (usuario.Contraseña)
                bool passwordValido = BCrypt.Net.BCrypt.Verify(request.Contraseña, usuario.Contraseña);

                if (!passwordValido)
                {
                    return new LoginResponseDto
                    {
                        Exito = false,
                        Mensaje = "Contraseña incorrecta",
                        Token = ""
                    };
                }

                // 3. GENERAR EL TOKEN
                // Si llegamos aquí, las credenciales son válidas. Generamos el pase VIP.
                string token = GenerarTokenJwt(usuario);

                return new LoginResponseDto
                {
                    Exito = true,
                    Token = token,
                    Mensaje = "Login exitoso"
                };
            }
            catch (Exception ex)
            {
                return new LoginResponseDto
                {
                    Exito = false,
                    Mensaje = $"Error en el servidor: {ex.Message}",
                    Token = ""
                };
            }
        }

        // Método privado auxiliar para crear el token (Lógica de JWT)
        private string GenerarTokenJwt(Usuario usuario)
        {
            // A. CREAR LOS "CLAIMS" (La info que va incrustada en el token)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                // Convertimos el Rol (1 o 2) a String para guardarlo en el token
                new Claim(ClaimTypes.Role, usuario.Rol.ToString())
            };

            // B. OBTENER LA CLAVE SECRETA
            // IMPORTANTE: Esto debe estar en tu appsettings.json bajo "Jwt:Key"
            // Por seguridad, si no existe, usamos una por defecto (SOLO PARA DESARROLLO)
            var keyString = configuration["Jwt:Key"] ?? "MI_CLAVE_SUPER_SECRETA_Y_LARGA_PARA_FIRMAR_TOKENS_123456";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // C. CONFIGURAR EL TOKEN
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8), // El token expira en 8 horas
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

