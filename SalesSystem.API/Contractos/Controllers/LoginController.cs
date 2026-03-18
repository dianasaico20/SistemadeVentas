

namespace SalesSystem.API.Contractos.Controllers
{
    public static class LoginController
    {
        public static IEndpointRouteBuilder UseLoginEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapPost(LoginEndpointIdentifiers.LoginUsuarioBase,
                async (ILoginInputPort inputPort, LoginRequestDto request) =>
                {
                    var result = await inputPort.LoginAsync(request);

                    if (result.Exito)
                    {
                        return Results.Ok(result);
                    }
                    else
                    {
                        return Results.Unauthorized();
                    }
                })
                .Produces<LoginResponseDto>()
                .Produces(StatusCodes.Status401Unauthorized) 
                .WithTags("Auth")
                .WithName("LoginUser")
                .AllowAnonymous(); 

            return builder;
        }
    }
}