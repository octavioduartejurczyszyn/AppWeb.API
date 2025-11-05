using System.ComponentModel;

namespace AppWeb.API.Models
{
    public class Marca
    {
        public int Id { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
