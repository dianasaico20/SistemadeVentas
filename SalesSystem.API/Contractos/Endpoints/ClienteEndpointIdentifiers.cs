namespace SalesSystem.API.Contractos.Endpoints
{
    public static  class ClienteEndpointIdentifiers
    {
        const string GetClienteByIdClienteBase = "cliente";
        // GetClienteById/{id} <= Servicio  => expone la Web Api
        // GetClienteById/23 <= Cliente     => consume el BlazorClient
        public const string GetClienteById = $"{GetClienteByIdClienteBase}/{{id}}";
        public static string BuildGetClienteByIdUri(int ClienteId) =>
            $"{GetClienteByIdClienteBase}/{ClienteId}";

        const string DeleteClienteByIdClienteBase = "cliente/delete";
        public const string DeleteClienteById = $"{DeleteClienteByIdClienteBase}/{{id}}";
        public static string BuildDeleteClienteByIdUri(int ClienteId) =>
            $"{DeleteClienteByIdClienteBase}/{ClienteId}";

        public const string CreateCliente = "cliente/create";

        const string EditClienteByIdClienteBase = "cliente/edit";
        public const string EditClienteById = $"{EditClienteByIdClienteBase}/{{id}}";
        public static string BuildEditClienteByIdUri(int ClienteId) =>
            $"{EditClienteByIdClienteBase}/{ClienteId}";  //"Cliente/edit/1"

        const string ViewClienteByIdClienteBase = "Cliente/view";
        public const string ViewClienteById = $"{ViewClienteByIdClienteBase}/{{id}}";
        public static string BuildViewClienteByIdUri(int ClienteId) =>
            $"{ViewClienteByIdClienteBase}/{ClienteId}";  //"Cliente/edit/1"

        public const string GetClientes = "clientes";
    }
}
