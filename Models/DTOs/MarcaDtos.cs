namespace AppWeb.API.Models.DTOs
{
    public class MarcaReadDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class MarcaCreateDto
    {
        public string Descripcion { get; set; }
    }

    public class MarcaUpdateDto
    {
        public string Descripcion { get; set; }
    }
}
