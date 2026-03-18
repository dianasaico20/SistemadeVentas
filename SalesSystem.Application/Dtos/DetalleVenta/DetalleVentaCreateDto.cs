namespace SalesSystem.Application.Dtos.DetalleVenta
{
    public class DetalleVentaCreateDto

    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }

    }
}
