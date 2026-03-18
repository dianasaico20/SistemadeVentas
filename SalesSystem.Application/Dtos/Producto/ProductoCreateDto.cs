namespace SalesSystem.Application.Dtos.Producto
{
    public class ProductoCreateDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Stock { get; set; }
        // Ruta local o URL de almacenamiento en la nube (nunca el archivo binario)
        public string? ImagenUrl { get; set; }
        public bool Estado { get; set; } = true;
    }
}
