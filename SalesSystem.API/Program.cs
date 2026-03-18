var builder = WebApplication.CreateBuilder(args);

//Agregar controladores y Swagger
builder.Services.AddControllers();
//Definir la política de acceso
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// -------------------

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// CONFIGURACIÓN DE JWT 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

//CONEXIÓN E INYECCIÓN DE DEPENDENCIAS
builder.Services.AddVentasRepositories(options =>
{
    // Asegúrate que "CadenaSQL" coincida con tu appsettings.json
    options.ConectionString = builder.Configuration.GetConnectionString("CadenaSQL");
});

var app = builder.Build();





// --- ZONA DE REGISTRO DE ENDPOINTS ---
app.UseUsuarioEndpoints();
app.UseLoginEndpoints();
app.UseClienteEndpoints();
app.UseCategoriaEndpoints();
app.UseProductoEndpoints();
app.UseFormadePagoEndpoints();
app.UseDetalleVentaEndpoints();
app.UseVentaEndpoints();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("BlazorPolicy"); 
app.UseAuthorization();
app.MapControllers();

app.Run();