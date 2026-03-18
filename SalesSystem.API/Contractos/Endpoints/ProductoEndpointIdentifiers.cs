namespace SalesSystem.API.Contractos.Endpoints
{
    public static class ProductoEndpointIdentifiers
    {
        const string GetProductoByIdProductoBase = "producto";
        // GetProductoById/{id} <= Servicio  => expone la Web Api
        // GetProductoById/23 <= Cliente     => consume el BlazorClient
        public const string GetProductoById = $"{GetProductoByIdProductoBase}/{{id}}";
        public static string BuildGetProductoByIdUri(int ProductoId) =>
            $"{GetProductoByIdProductoBase}/{ProductoId}";

        const string DeleteProductoByIdProductoBase = "producto/delete";
        public const string DeleteProductoById = $"{DeleteProductoByIdProductoBase}/{{id}}";
        public static string BuildDeleteProductoByIdUri(int ProductoId) =>
            $"{DeleteProductoByIdProductoBase}/{ProductoId}";

        public const string CreateProducto = "producto/create";

        const string EditProductoByIdProductoBase = "producto/edit";
        public const string EditProductoById = $"{EditProductoByIdProductoBase}/{{id}}";
        public static string BuildEditProductoByIdUri(int ProductoId) =>
            $"{EditProductoByIdProductoBase}/{ProductoId}";  //"Producto/edit/1"

        const string ViewProductoByIdProductoBase = "producto/view";
        public const string ViewProductoById = $"{ViewProductoByIdProductoBase}/{{id}}";
        public static string BuildViewProductoByIdUri(int ProductoId) =>
            $"{ViewProductoByIdProductoBase}/{ProductoId}";  //"Producto/view/1"

        public const string GetProductos = "productos";

        const string GetProductoByCategoriaIdBase = "producto/categoria";
        public const string GetProductoByCategoriaId = $"{GetProductoByCategoriaIdBase}/{{categoriaId}}";
        public static string BuildGetProductoByCategoriaIdUri(int CategoriaId) =>
            $"{GetProductoByCategoriaIdBase}/{CategoriaId}";
    }
}
