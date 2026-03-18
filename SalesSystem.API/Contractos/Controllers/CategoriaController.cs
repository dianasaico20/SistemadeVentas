namespace SalesSystem.API.Contractos.Controllers
{
    public static class CategoriaController
    {
        public static IEndpointRouteBuilder UseCategoriaEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(CategoriaEndpointIdentifiers.CreateCategoria,
                async (ICategoriaInputPort inputPort, CategoriaCreateDto categoriaDto) =>
                TypedResults.Ok(await inputPort.CreateCategoriaAsync(categoriaDto)))
                .Produces<BaseResponse>();

            builder.MapPut(CategoriaEndpointIdentifiers.EditCategoriaById,
                async (ICategoriaInputPort inputPort, CategoriaCreateDto categoriaDto) =>
                TypedResults.Ok(await inputPort.UpdateCategoriaAsync(categoriaDto)))
                .Produces<BaseResponse>();

            builder.MapDelete(CategoriaEndpointIdentifiers.DeleteCategoriaById,
               async (ICategoriaInputPort inputPort, int id) =>
               TypedResults.Ok(await inputPort.DeleteCategoriaAsync(id)))
               .Produces<BaseResponse>();

            builder.MapGet(CategoriaEndpointIdentifiers.GetCategoriaById,
                async (ICategoriaInputPort inputPort, int id) =>
                TypedResults.Ok(await inputPort.GetCategoriaByIdAsync(id)))
                .Produces<CategoriaResponseDto>();

            builder.MapGet(CategoriaEndpointIdentifiers.GetCategorias,
                async (ICategoriaInputPort inputPort) =>
                TypedResults.Ok(await inputPort.GetCategoriaAllAsync()))
                .Produces<IEnumerable<CategoriaResponseDto>>();

            return builder;
        }
    }
}
