namespace SalesSystem.API.Contractos.Endpoints
{
    public static class VentaEndpointIdentifiers
    {
        const string GetVentaByIdVentaBase = "venta";
        // GetVentaById/{id} <= Servicio  => expone la Web Api
        // GetVentaById/23 <= Cliente     => consume el BlazorClient
        public const string GetVentaById = $"{GetVentaByIdVentaBase}/{{id}}";
        public static string BuildGetVentaByIdUri(int VentaId) =>
            $"{GetVentaByIdVentaBase}/{VentaId}";

        const string DeleteVentaByIdVentaBase = "venta/delete";
        public const string DeleteVentaById = $"{DeleteVentaByIdVentaBase}/{{id}}";
        public static string BuildDeleteVentaByIdUri(int VentaId) =>
            $"{DeleteVentaByIdVentaBase}/{VentaId}";

        public const string CreateVenta = "venta/create";

        const string EditVentaByIdVentaBase = "venta/edit";
        public const string EditVentaById = $"{EditVentaByIdVentaBase}/{{id}}";
        public static string BuildEditVentaByIdUri(int VentaId) =>
            $"{EditVentaByIdVentaBase}/{VentaId}";  //"Venta/edit/1"

        const string ViewVentaByIdVentaBase = "venta/view";
        public const string ViewVentaById = $"{ViewVentaByIdVentaBase}/{{id}}";
        public static string BuildViewVentaByIdUri(int VentaId) =>
            $"{ViewVentaByIdVentaBase}/{VentaId}";  //"Venta/view/1"

        public const string GetVentas = "ventas";

        const string GetVentaByClienteIdBase = "venta/cliente";
        public const string GetVentaByClienteId = $"{GetVentaByClienteIdBase}/{{clienteId}}";
        public static string BuildGetVentaByClienteIdUri(int ClienteId) =>
            $"{GetVentaByClienteIdBase}/{ClienteId}";
    }
}
