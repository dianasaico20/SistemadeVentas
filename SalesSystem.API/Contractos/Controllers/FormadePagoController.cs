namespace SalesSystem.API.Contractos.Controllers
{
    public static class FormadePagoController
    {
        public static IEndpointRouteBuilder UseFormadePagoEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(FormadePagoEndpointIdentifiers.CreateFormadePago,
                async (IFormadePagoInputPort inputPort, FormadePagoCreateDto formaPagoDto) =>
                TypedResults.Ok(await inputPort.CreateFormadePagoAsync(formaPagoDto)))
                .Produces<BaseResponse>();

            builder.MapPut(FormadePagoEndpointIdentifiers.EditFormadePagoById,
                async (IFormadePagoInputPort inputPort, FormadePagoCreateDto formaPagoDto) =>
                TypedResults.Ok(await inputPort.UpdateFormadePagoAsync(formaPagoDto)))
                .Produces<BaseResponse>();

            builder.MapDelete(FormadePagoEndpointIdentifiers.DeleteFormadePagoById,
               async (IFormadePagoInputPort inputPort, int id) =>
               TypedResults.Ok(await inputPort.DeleteFormadePagoAsync(id)))
               .Produces<BaseResponse>();

            builder.MapGet(FormadePagoEndpointIdentifiers.GetFormadePagoById,
                async (IFormadePagoInputPort inputPort, int id) =>
                TypedResults.Ok(await inputPort.GetFormadePagoByIdAsync(id)))
                .Produces<FormadePagoResponseDto>();

            builder.MapGet(FormadePagoEndpointIdentifiers.GetFormasDePago,
                async (IFormadePagoInputPort inputPort) =>
                TypedResults.Ok(await inputPort.GetFormadePagoAllAsync()))
                .Produces<IEnumerable<FormadePagoResponseDto>>();

            return builder;
        }
    }
}
