namespace SalesSystem.Domain.Entities
{
   public class DetalleVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public Venta Venta { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public decimal Cantidad { get; set; }

        // OJO: Este campo es vital. Si mañana subes el precio del producto en el catálogo, 
        // las ventas pasadas no deben modificarse. Se guarda el precio al que se vendió ese día.
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }

    }
}
