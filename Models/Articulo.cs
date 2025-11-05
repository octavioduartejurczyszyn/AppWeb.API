namespace AppWeb.API.Models
{
    public class Articulo
    {
            
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        // Claves foráneas
        public int MarcaId { get; set; }
        public int CategoriaId { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        // Propiedades de navegación
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
    }
}

