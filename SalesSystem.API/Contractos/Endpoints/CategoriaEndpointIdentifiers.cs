namespace SalesSystem.API.Contractos.Endpoints
{
    public static class CategoriaEndpointIdentifiers
    {
        const string GetCategoriaByIdCategoriaBase = "categoria";
        // GetCategoriaById/{id} <= Servicio  => expone la Web Api
        // GetCategoriaById/23 <= Cliente     => consume el BlazorClient
        public const string GetCategoriaById = $"{GetCategoriaByIdCategoriaBase}/{{id}}";
        public static string BuildGetCategoriaByIdUri(int CategoriaId) =>
            $"{GetCategoriaByIdCategoriaBase}/{CategoriaId}";

        const string DeleteCategoriaByIdCategoriaBase = "categoria/delete";
        public const string DeleteCategoriaById = $"{DeleteCategoriaByIdCategoriaBase}/{{id}}";
        public static string BuildDeleteCategoriaByIdUri(int CategoriaId) =>
            $"{DeleteCategoriaByIdCategoriaBase}/{CategoriaId}";

        public const string CreateCategoria = "categoria/create";

        const string EditCategoriaByIdCategoriaBase = "categoria/edit";
        public const string EditCategoriaById = $"{EditCategoriaByIdCategoriaBase}/{{id}}";
        public static string BuildEditCategoriaByIdUri(int CategoriaId) =>
            $"{EditCategoriaByIdCategoriaBase}/{CategoriaId}";  //"Categoria/edit/1"

        const string ViewCategoriaByIdCategoriaBase = "categoria/view";
        public const string ViewCategoriaById = $"{ViewCategoriaByIdCategoriaBase}/{{id}}";
        public static string BuildViewCategoriaByIdUri(int CategoriaId) =>
            $"{ViewCategoriaByIdCategoriaBase}/{CategoriaId}";  //"Categoria/view/1"

        public const string GetCategorias = "categorias";
    }
}
