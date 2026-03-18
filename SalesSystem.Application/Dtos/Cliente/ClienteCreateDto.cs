namespace SalesSystem.Application.Dtos.Cliente
{
    public class ClienteCreateDto
    {
        public int Id { get; set; }
        // Cédula, RUC, Pasaporte o Consumidor Final
        public string TipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
