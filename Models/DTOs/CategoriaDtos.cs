namespace AppWeb.API.Models.DTOs
{
    public class CategoriaReadDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class CategoriaCreateDto
    {
        public string Descripcion { get; set; }
    }

    public class CategoriaUpdateDto
    {
        public string Descripcion { get; set; }
    }
}
