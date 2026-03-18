namespace SalesSystem.API.Contractos.Controllers
{
    public static class UsuarioController
    {
        public static IEndpointRouteBuilder UseUsuarioEndpoints(
      this IEndpointRouteBuilder builder)
        {
            builder.MapPost(UsuarioEndpointIdentifiers.CreateUsuario,
                async (IUsuarioInputPort inputPort, UsuarioCreateDto usuarioDto) =>
                TypedResults.Ok(await inputPort.CreateUsuarioAsync(usuarioDto)))
                .Produces<BaseResponse>();

            builder.MapPut(UsuarioEndpointIdentifiers.EditUsuarioById,
                async (IUsuarioInputPort inputPort, UsuarioCreateDto usuarioDto) =>
                TypedResults.Ok(await inputPort.UpdateUsuarioAsync(usuarioDto)))
                .Produces<BaseResponse>();

            builder.MapDelete(UsuarioEndpointIdentifiers.DeleteUsuarioById,
               async (IUsuarioInputPort inputPort, int id) =>
               TypedResults.Ok(await inputPort.DeleteUsuarioAsync(id)))
               .Produces<BaseResponse>();

            builder.MapGet(UsuarioEndpointIdentifiers.GetUsuarioById,
                async (IUsuarioInputPort inputPort, int id) =>
                TypedResults.Ok(await inputPort.GetUsuarioByIdAsync(id)))
                .Produces<UsuarioResponseDto>();

            builder.MapGet(UsuarioEndpointIdentifiers.GetUsuarios,
                async (IUsuarioInputPort inputPort) =>
                TypedResults.Ok(await inputPort.GetUsuarioAllAsync()))
                .Produces<IEnumerable<UsuarioResponseDto>>();

            return builder;
        }
    }
}
