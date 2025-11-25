namespace AppWeb.API.Models.DTOs
{
    public class ArticuloReadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        // opcional: incluir NombreMarca / NombreCategoria si haces joins
    }
}
