using SalesSystem.Application.Dtos.DetalleVenta;

namespace SalesSystem.Application.Dtos.Venta
{
    public class VentaResponseDto

    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public string NumeroComprobante { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal ImpuestoTotal { get; set; }
        public decimal Total { get; set; }
        public int FormadePagoId { get; set; }
        public bool Estado { get; set; }
        public List<DetalleVentaResponseDto> DetallesVenta { get; set; } = new List<DetalleVentaResponseDto>();

    }
}
