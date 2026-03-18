namespace SalesSystem.Domain.Entities
{// Esta clase representa LA tabla SQL tal cual
    public class Producto
    {
        public int Id { get; set; }

        // Código de barras o SKU interno. Universal para cualquier tienda.
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }

        // El precio al que lo vendes
        public decimal PrecioVenta { get; set; }

        // OPCIONAL PERO RECOMENDADO: El costo te permite calcular la ganancia real
        public decimal PrecioCompra { get; set; }

        // Usar decimal en lugar de int permite vender "1.5 kilos" o "1 unidad"
        public decimal Stock { get; set; }

        // Relaciones genéricas
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        // Guarda la ruta local o la URL de la nube, NUNCA el archivo pesado
        public string? ImagenUrl { get; set; }

        public bool Estado { get; set; } = true;

    }
}
