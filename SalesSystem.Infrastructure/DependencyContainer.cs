namespace SalesSystem.Infrastructure
{
 public static class DependencyContainer
    {
        public static IServiceCollection AddVentasRepositories(this IServiceCollection services,
        Action<VentasDbOptions> configureTourismDbOptions)
        {
            VentasDbOptions Options = new();
            configureTourismDbOptions(Options);

            Action<DbContextOptionsBuilder> ConfigureOptions = options =>
                    options.UseSqlServer(Options.ConectionString);

            services.AddVentasRepositories(ConfigureOptions);

            return services;
        }


        public static IServiceCollection AddVentasRepositories(this IServiceCollection services,
       Action<DbContextOptionsBuilder> configureOptions)
        {
            services.AddDbContext<VentasDbContext>(configureOptions);

            //Usuarios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioCommandsRepository, UsuarioCommandsRepository>();
            services.AddScoped<IUsuarioInputPort, UsuarioInteractor>();
            //Auth
            services.AddScoped<ILoginInputPort, LoginInteractor>();
            //Clientes
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteCommandsRepository, ClienteCommandsRepository>();
            services.AddScoped<IClienteInputPort, ClienteInteractor>();
            //Categorias
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaCommandsRepository, CategoriaCommandsRepository>();
            services.AddScoped<ICategoriaInputPort, CategoriaInteractor>();
            //Productos
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IProductoCommandsRepository, ProductoCommandsRepository>();
            services.AddScoped<IProductoInputPort, ProductoInteractor>();
            //FormasDePago
            services.AddScoped<IFormadePagoRepository, FormadePagoRepository>();
            services.AddScoped<IFormadePagoCommandsRepository, FormadePagoCommandsRepository>();
            services.AddScoped<IFormadePagoInputPort, FormadePagoInteractor>();
            //DetallesVenta
            services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();
            services.AddScoped<IDetalleVentaCommandsRepository, DetalleVentaCommandsRepository>();
            services.AddScoped<IDetalleVentaInputPort, DetalleVentaInteractor>();
            //Ventas
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IVentaCommandsRepository, VentaCommandsRepository>();
            services.AddScoped<IVentaInputPort, VentaInteractor>();

            return services;
        }


    }
}
