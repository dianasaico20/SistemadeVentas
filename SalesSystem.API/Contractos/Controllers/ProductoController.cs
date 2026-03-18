namespace SalesSystem.API.Contractos.Controllers
{
    public static class ProductoController
    {
        public static IEndpointRouteBuilder UseProductoEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(ProductoEndpointIdentifiers.CreateProducto,
                async (IProductoInputPort inputPort, ProductoCreateDto productoDto) =>
                TypedResults.Ok(await inputPort.CreateProductoAsync(productoDto)))
                .Produces<BaseResponse>();

            builder.MapPut(ProductoEndpointIdentifiers.EditProductoById,
                async (IProductoInputPort inputPort, ProductoCreateDto productoDto) =>
                TypedResults.Ok(await inputPort.UpdateProductoAsync(productoDto)))
                .Produces<BaseResponse>();

            builder.MapDelete(ProductoEndpointIdentifiers.DeleteProductoById,
               async (IProductoInputPort inputPort, int id) =>
               TypedResults.Ok(await inputPort.DeleteProductoAsync(id)))
               .Produces<BaseResponse>();

            builder.MapGet(ProductoEndpointIdentifiers.GetProductoById,
                async (IProductoInputPort inputPort, int id) =>
                TypedResults.Ok(await inputPort.GetProductoByIdAsync(id)))
                .Produces<ProductoResponseDto>();

            builder.MapGet(ProductoEndpointIdentifiers.GetProductos,
                async (IProductoInputPort inputPort) =>
                TypedResults.Ok(await inputPort.GetProductoAllAsync()))
                .Produces<IEnumerable<ProductoResponseDto>>();

            builder.MapGet(ProductoEndpointIdentifiers.GetProductoByCategoriaId,
                async (IProductoInputPort inputPort, int categoriaId) =>
                TypedResults.Ok(await inputPort.GetProductoByCategoriaIdAsync(categoriaId)))
                .Produces<IEnumerable<ProductoResponseDto>>();

            return builder;
        }
    }
}
