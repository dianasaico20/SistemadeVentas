
namespace SalesSystem.Domain.Entities;
// Esta clase representa LA tabla SQL tal cual
public class Cliente
{
    public int Id { get; set; }

    // Sirve para clasificar si usa Cédula, RUC, Pasaporte o es Consumidor Final
    public string TipoDocumento { get; set; } = string.Empty;
    public string NumeroDocumento { get; set; } = string.Empty;

    // Al unir Nombre y Apellido en un solo campo (o usar Razon Social), 
    // evitas el problema de que una empresa no tiene "Apellido".
    public string NombreCompleto { get; set; } = string.Empty;

    // Datos de contacto estándar para cualquier CRM
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }

    public bool Estado { get; set; } = true;
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
}
