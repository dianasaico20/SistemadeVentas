namespace SalesSystem.Application.Dtos.Categoria
{
    public class CategoriaCreateDto

    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;

    }
}
