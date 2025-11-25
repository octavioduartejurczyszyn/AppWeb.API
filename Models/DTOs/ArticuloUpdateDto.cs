using System.ComponentModel.DataAnnotations;

namespace AppWeb.API.Models.DTOs
{
    public class ArticuloUpdateDto
    {
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [StringLength(1000)]
        public string? Descripcion { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }

        [Required]
        public int IdMarca { get; set; }

        [Required]
        public int IdCategoria { get; set; }
    }
}
