namespace SalesSystem.API.Contractos.Endpoints
{
    public static class UsuarioEndpointIdentifiers
    {
        const string GetUsuarioByIdUsuarioBase = "usuario";
        // GetUsuarioById/{id} <= Servicio  => expone la Web Api
        // GetUsuarioById/23 <= Cliente     => consume el BlazorClient
        public const string GetUsuarioById = $"{GetUsuarioByIdUsuarioBase}/{{id}}";
        public static string BuildGetUsuarioByIdUri(int UsuarioId) =>
            $"{GetUsuarioByIdUsuarioBase}/{UsuarioId}";

        const string DeleteUsuarioByIdUsuarioBase = "usuario/delete";
        public const string DeleteUsuarioById = $"{DeleteUsuarioByIdUsuarioBase}/{{id}}";
        public static string BuildDeleteUsuarioByIdUri(int UsuarioId) =>
            $"{DeleteUsuarioByIdUsuarioBase}/{UsuarioId}";

        public const string CreateUsuario = "usuario/create";

        const string EditUsuarioByIdUsuarioBase = "usuario/edit";
        public const string EditUsuarioById = $"{EditUsuarioByIdUsuarioBase}/{{id}}";
        public static string BuildEditUsuarioByIdUri(int UsuarioId) =>
            $"{EditUsuarioByIdUsuarioBase}/{UsuarioId}";  //"Usuario/edit/1"

        const string ViewUsuarioByIdUsuarioBase = "usuario/view";
        public const string ViewUsuarioById = $"{ViewUsuarioByIdUsuarioBase}/{{id}}";
        public static string BuildViewUsuarioByIdUri(int UsuarioId) =>
            $"{ViewUsuarioByIdUsuarioBase}/{UsuarioId}";  //"Usuario/edit/1"

        public const string GetUsuarios = "usuarios";

    }
}
