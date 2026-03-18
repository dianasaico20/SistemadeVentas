namespace SalesSystem.API.Contractos.Endpoints
{
    public static class FormadePagoEndpointIdentifiers
    {
        const string GetFormadePagoByIdFormadePagoBase = "formadepago";
        // GetFormadePagoById/{id} <= Servicio  => expone la Web Api
        // GetFormadePagoById/23 <= Cliente     => consume el BlazorClient
        public const string GetFormadePagoById = $"{GetFormadePagoByIdFormadePagoBase}/{{id}}";
        public static string BuildGetFormadePagoByIdUri(int FormadePagoId) =>
            $"{GetFormadePagoByIdFormadePagoBase}/{FormadePagoId}";

        const string DeleteFormadePagoByIdFormadePagoBase = "formadepago/delete";
        public const string DeleteFormadePagoById = $"{DeleteFormadePagoByIdFormadePagoBase}/{{id}}";
        public static string BuildDeleteFormadePagoByIdUri(int FormadePagoId) =>
            $"{DeleteFormadePagoByIdFormadePagoBase}/{FormadePagoId}";

        public const string CreateFormadePago = "formadepago/create";

        const string EditFormadePagoByIdFormadePagoBase = "formadepago/edit";
        public const string EditFormadePagoById = $"{EditFormadePagoByIdFormadePagoBase}/{{id}}";
        public static string BuildEditFormadePagoByIdUri(int FormadePagoId) =>
            $"{EditFormadePagoByIdFormadePagoBase}/{FormadePagoId}";  //"FormadePago/edit/1"

        const string ViewFormadePagoByIdFormadePagoBase = "formadepago/view";
        public const string ViewFormadePagoById = $"{ViewFormadePagoByIdFormadePagoBase}/{{id}}";
        public static string BuildViewFormadePagoByIdUri(int FormadePagoId) =>
            $"{ViewFormadePagoByIdFormadePagoBase}/{FormadePagoId}";  //"FormadePago/view/1"

        public const string GetFormasDePago = "formasdepago";
    }
}
