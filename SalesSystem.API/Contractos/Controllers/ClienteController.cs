namespace SalesSystem.API.Contractos.Controllers
{
    public static class ClienteController
    {
        public static IEndpointRouteBuilder UseClienteEndpoints(
     this IEndpointRouteBuilder builder)
        {
            builder.MapPost(ClienteEndpointIdentifiers.CreateCliente,
                async (IClienteInputPort inputPort, ClienteCreateDto ClienteDto) =>
                TypedResults.Ok(await inputPort.CreateClienteAsync(ClienteDto)))
                .Produces<BaseResponse>();

            builder.MapPut(ClienteEndpointIdentifiers.EditClienteById,
                async (IClienteInputPort inputPort, ClienteCreateDto ClienteDto) =>
                TypedResults.Ok(await inputPort.UpdateClienteAsync(ClienteDto)))
                .Produces<BaseResponse>();

            builder.MapDelete(ClienteEndpointIdentifiers.DeleteClienteById,
               async (IClienteInputPort inputPort, int id) =>
               TypedResults.Ok(await inputPort.DeleteClienteAsync(id)))
               .Produces<BaseResponse>();

            builder.MapGet(ClienteEndpointIdentifiers.GetClienteById,
                async (IClienteInputPort inputPort, int id) =>
                TypedResults.Ok(await inputPort.GetClienteByIdAsync(id)))
                .Produces<ClienteResponseDto>();

            builder.MapGet(ClienteEndpointIdentifiers.GetClientes,
                async (IClienteInputPort inputPort) =>
                TypedResults.Ok(await inputPort.GetClienteAllAsync()))
                .Produces<IEnumerable<ClienteResponseDto>>();

            return builder;
        }
    }
}
