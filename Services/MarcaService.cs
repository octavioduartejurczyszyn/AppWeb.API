using AppWeb.API.Data;
using AppWeb.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppWeb.API.Business
{
    public class MarcaService
    {
        private readonly AppDbContext _context;
        public MarcaService(AppDbContext context)
        {
            _context = context;
        }
        public List<Marca> ListaMarca()
        {
            List<Marca> lista = new List<Marca>();
            lista = _context.Marcas.ToList();
            return lista;
        }
    }
}
