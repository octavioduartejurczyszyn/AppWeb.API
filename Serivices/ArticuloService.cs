using AppWeb.API.Data;
using AppWeb.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppWeb.API.Business
{
    public class ArticuloService
    {
        private readonly AppDbContext _context;
        public ArticuloService(AppDbContext context)
        {
            _context = context;
        }
        // Podemos observar que ya no hace falta crear un objeto. Simplemente EF crea un objeto de tipo List<Articulo> y luego el método retorna ese objeto.
        public List<Articulo> Listar()
        {
            try
            {
                return _context.Articulos
                               .Include(a => a.Marca)
                               .Include(a => a.Categoria)
                               .ToList();
            }
            catch (Exception ex)
            {
                // Aquí podrías loguear el error en un log
                throw new Exception("Error al listar artículos", ex);
            }
        }
        public void Agregar(Articulo nuevo)
        {
            _context.Articulos.Add(nuevo);
            _context.SaveChanges();
        }

        public void Modificar(int id, Articulo nuevo)
        {
            var existente = _context.Articulos.Find(id);
            if (existente == null)
                throw new Exception("Artículo no encontrado.");

            existente.Nombre = nuevo.Nombre;
            existente.Descripcion = nuevo.Descripcion;
            existente.Precio = nuevo.Precio;
            existente.ImagenUrl = nuevo.ImagenUrl;
            existente.Marca = nuevo.Marca;
            existente.Categoria = nuevo.Categoria;

            _context.SaveChanges();
        }


        public void Eliminar(int id)
        {
            var articulo = _context.Articulos.Find(id);
            if (articulo == null)
                throw new Exception("Artículo no encontrado.");

            _context.Articulos.Remove(articulo);
            _context.SaveChanges();
        }
        public List<Articulo> Filtrar(string campo, string criterio, string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return new List<Articulo>();

            var query = _context.Articulos
                                .Include(a => a.Marca)
                                .Include(a => a.Categoria)
                                .AsQueryable();

            if (campo == "Categoría")
            {
                query = criterio switch
                {
                    "Comienza con" => query.Where(a => a.Categoria.Descripcion.StartsWith(filtro)),
                    "Termina con" => query.Where(a => a.Categoria.Descripcion.EndsWith(filtro)),
                    _ => query.Where(a => a.Categoria.Descripcion.Contains(filtro))
                };
            }
            else if (campo == "Marca")
            {
                query = criterio switch
                {
                    "Comienza con" => query.Where(a => a.Marca.Descripcion.StartsWith(filtro)),
                    "Termina con" => query.Where(a => a.Marca.Descripcion.EndsWith(filtro)),
                    _ => query.Where(a => a.Marca.Descripcion.Contains(filtro))
                };
            }
            else if (campo == "Precio")
            {
                if (decimal.TryParse(filtro, out decimal precioFiltro))
                {
                    query = criterio switch
                    {
                        "Mayor a" => query.Where(a => a.Precio > precioFiltro),
                        "Menor a" => query.Where(a => a.Precio < precioFiltro),
                        _ => query.Where(a => a.Precio == precioFiltro)
                    };
                }
            }

            return query.ToList();
        }

    }
}
