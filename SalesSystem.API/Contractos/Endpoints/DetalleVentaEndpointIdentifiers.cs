namespace SalesSystem.API.Contractos.Endpoints
{
    public static class DetalleVentaEndpointIdentifiers
    {
        const string GetDetalleVentaByIdDetalleVentaBase = "detalleventa";
        // GetDetalleVentaById/{id} <= Servicio  => expone la Web Api
        // GetDetalleVentaById/23 <= Cliente     => consume el BlazorClient
        public const string GetDetalleVentaById = $"{GetDetalleVentaByIdDetalleVentaBase}/{{id}}";
        public static string BuildGetDetalleVentaByIdUri(int DetalleVentaId) =>
            $"{GetDetalleVentaByIdDetalleVentaBase}/{DetalleVentaId}";

        const string DeleteDetalleVentaByIdDetalleVentaBase = "detalleventa/delete";
        public const string DeleteDetalleVentaById = $"{DeleteDetalleVentaByIdDetalleVentaBase}/{{id}}";
        public static string BuildDeleteDetalleVentaByIdUri(int DetalleVentaId) =>
            $"{DeleteDetalleVentaByIdDetalleVentaBase}/{DetalleVentaId}";

        public const string CreateDetalleVenta = "detalleventa/create";

        const string EditDetalleVentaByIdDetalleVentaBase = "detalleventa/edit";
        public const string EditDetalleVentaById = $"{EditDetalleVentaByIdDetalleVentaBase}/{{id}}";
        public static string BuildEditDetalleVentaByIdUri(int DetalleVentaId) =>
            $"{EditDetalleVentaByIdDetalleVentaBase}/{DetalleVentaId}";  //"DetalleVenta/edit/1"

        const string ViewDetalleVentaByIdDetalleVentaBase = "detalleventa/view";
        public const string ViewDetalleVentaById = $"{ViewDetalleVentaByIdDetalleVentaBase}/{{id}}";
        public static string BuildViewDetalleVentaByIdUri(int DetalleVentaId) =>
            $"{ViewDetalleVentaByIdDetalleVentaBase}/{DetalleVentaId}";  //"DetalleVenta/view/1"

        public const string GetDetallesVenta = "detallesventa";

        const string GetDetalleVentaByVentaIdBase = "detalleventa/venta";
        public const string GetDetalleVentaByVentaId = $"{GetDetalleVentaByVentaIdBase}/{{ventaId}}";
        public static string BuildGetDetalleVentaByVentaIdUri(int VentaId) =>
            $"{GetDetalleVentaByVentaIdBase}/{VentaId}";
    }
}
