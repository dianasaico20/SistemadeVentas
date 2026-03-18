namespace SalesSystem.API.Contractos.Controllers
{
    public static class VentaController
    {
        public static IEndpointRouteBuilder UseVentaEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(VentaEndpointIdentifiers.CreateVenta,
                async (IVentaInputPort inputPort, VentaCreateDto ventaDto) =>
                TypedResults.Ok(await inputPort.CreateVentaAsync(ventaDto)))
                .Produces<BaseResponse>();

            builder.MapPut(VentaEndpointIdentifiers.EditVentaById,
                async (IVentaInputPort inputPort, VentaCreateDto ventaDto) =>
                TypedResults.Ok(await inputPort.UpdateVentaAsync(ventaDto)))
                .Produces<BaseResponse>();

            builder.MapDelete(VentaEndpointIdentifiers.DeleteVentaById,
               async (IVentaInputPort inputPort, int id) =>
               TypedResults.Ok(await inputPort.DeleteVentaAsync(id)))
               .Produces<BaseResponse>();

            builder.MapGet(VentaEndpointIdentifiers.GetVentaById,
                async (IVentaInputPort inputPort, int id) =>
                TypedResults.Ok(await inputPort.GetVentaByIdAsync(id)))
                .Produces<VentaResponseDto>();

            builder.MapGet(VentaEndpointIdentifiers.GetVentas,
                async (IVentaInputPort inputPort) =>
                TypedResults.Ok(await inputPort.GetVentaAllAsync()))
                .Produces<IEnumerable<VentaResponseDto>>();

            builder.MapGet(VentaEndpointIdentifiers.GetVentaByClienteId,
                async (IVentaInputPort inputPort, int clienteId) =>
                TypedResults.Ok(await inputPort.GetVentaByClienteIdAsync(clienteId)))
                .Produces<IEnumerable<VentaResponseDto>>();

            return builder;
        }
    }
}
