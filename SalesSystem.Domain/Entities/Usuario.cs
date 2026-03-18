namespace SalesSystem.Domain.Entities;
// Esta clase representa LA tabla SQL tal cual
public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;

    // Cambiado para ser universal y coincidir con Cliente
    public string Identificacion { get; set; } = string.Empty;

    public string Contraseña { get; set; } = string.Empty;
    public RolesEnum Rol { get; set; }
    public bool Estado { get; set; } = true;

    // Estandarizado sin la "de"
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

    // Propiedad de navegación: Ventas que ha realizado este usuario
    public List<Venta> Ventas { get; set; } = new();


}
