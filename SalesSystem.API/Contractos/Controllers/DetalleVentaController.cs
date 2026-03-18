namespace SalesSystem.API.Contractos.Controllers
{
    public static class DetalleVentaController
    {
        public static IEndpointRouteBuilder UseDetalleVentaEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(DetalleVentaEndpointIdentifiers.CreateDetalleVenta,
                async (IDetalleVentaInputPort inputPort, DetalleVentaCreateDto detalleVentaDto) =>
                TypedResults.Ok(await inputPort.CreateDetalleVentaAsync(detalleVentaDto)))
                .Produces<BaseResponse>();

            builder.MapPut(DetalleVentaEndpointIdentifiers.EditDetalleVentaById,
                async (IDetalleVentaInputPort inputPort, DetalleVentaCreateDto detalleVentaDto) =>
                TypedResults.Ok(await inputPort.UpdateDetalleVentaAsync(detalleVentaDto)))
                .Produces<BaseResponse>();

            builder.MapDelete(DetalleVentaEndpointIdentifiers.DeleteDetalleVentaById,
               async (IDetalleVentaInputPort inputPort, int id) =>
               TypedResults.Ok(await inputPort.DeleteDetalleVentaAsync(id)))
               .Produces<BaseResponse>();

            builder.MapGet(DetalleVentaEndpointIdentifiers.GetDetalleVentaById,
                async (IDetalleVentaInputPort inputPort, int id) =>
                TypedResults.Ok(await inputPort.GetDetalleVentaByIdAsync(id)))
                .Produces<DetalleVentaResponseDto>();

            builder.MapGet(DetalleVentaEndpointIdentifiers.GetDetallesVenta,
                async (IDetalleVentaInputPort inputPort) =>
                TypedResults.Ok(await inputPort.GetDetalleVentaAllAsync()))
                .Produces<IEnumerable<DetalleVentaResponseDto>>();

            builder.MapGet(DetalleVentaEndpointIdentifiers.GetDetalleVentaByVentaId,
                async (IDetalleVentaInputPort inputPort, int ventaId) =>
                TypedResults.Ok(await inputPort.GetDetalleVentaByVentaIdAsync(ventaId)))
                .Produces<IEnumerable<DetalleVentaResponseDto>>();

            return builder;
        }
    }
}
