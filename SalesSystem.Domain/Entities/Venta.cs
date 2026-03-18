namespace SalesSystem.Domain.Entities
{
    // Esta clase representa LA tabla SQL tal cual
    public class Venta
    {
        public int Id { get; set; }
        public string NumeroComprobante { get; set; } = string.Empty;
        public DateTime FechaVenta { get; set; } = DateTime.UtcNow;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int UsuarioId { get; set; } // El vendedor
        public Usuario Usuario { get; set; }

        public int FormadePagoId { get; set; }
        public FormadePago FormadePago { get; set; }

        // Totales estandarizados
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; } // Un sistema estándar siempre permite descuentos
        public decimal ImpuestoTotal { get; set; }
        public decimal Total { get; set; }

        public bool Estado { get; set; } = true; // true = Completada, false = Anulada

        public List<DetalleVenta> DetallesVenta { get; set; } = new();

    }
}
