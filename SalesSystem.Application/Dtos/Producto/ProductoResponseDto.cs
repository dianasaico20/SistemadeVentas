namespace SalesSystem.Application.Dtos.Producto
{
    public class ProductoResponseDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Stock { get; set; }
        public string? ImagenUrl { get; set; }
        public bool Estado { get; set; }
    }
}
