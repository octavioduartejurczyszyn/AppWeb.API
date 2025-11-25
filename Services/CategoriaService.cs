using AppWeb.API.Data;
using AppWeb.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace AppWeb.API.Business
{
    public class CategoriaService
    {
        private readonly AppDbContext _context;
        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }
        public List<Categoria> listaCategoria()
        {
            List<Categoria> lista = new List<Categoria>();
            lista = _context.Categorias.ToList();
            return lista;  
        }
    }
}
