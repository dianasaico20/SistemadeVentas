namespace SalesSystem.Domain.Entities
{// Esta clase representa LA tabla SQL tal cual
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;

        // Propiedad de navegación: Productos que pertenecen a esta categoría
        public List<Producto> Productos { get; set; } = new();
    }
}
