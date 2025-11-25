using AppWeb.API.Data;
using AppWeb.API.Models;
using AppWeb.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.API.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly AppDbContext _context;

        public ArticuloService(AppDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // GET ALL
        // =====================================================
        public async Task<IEnumerable<ArticuloReadDto>> GetAllAsync()
        {
            var articulos = await _context.Articulos
                .AsNoTracking()
                .ToListAsync();

            return articulos.Select(a => new ArticuloReadDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion,
                Precio = a.Precio,
                IdMarca = a.IdMarca,
                IdCategoria = a.IdCategoria
            }).ToList();
        }

        // =====================================================
        // GET BY ID
        // =====================================================
        public async Task<ArticuloReadDto> GetByIdAsync(int id)
        {
            var articulo = await _context.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (articulo == null)
                return null;

            return new ArticuloReadDto
            {
                Id = articulo.Id,
                Nombre = articulo.Nombre,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio,
                IdMarca = articulo.IdMarca,
                IdCategoria = articulo.IdCategoria
            };
        }

        // =====================================================
        // CREATE
        // =====================================================
        public async Task<ArticuloReadDto> CreateAsync(ArticuloCreateDto dto)
        {
            var articulo = new Articulo
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                IdMarca = dto.IdMarca,
                IdCategoria = dto.IdCategoria
            };

            await _context.Articulos.AddAsync(articulo);
            await _context.SaveChangesAsync();

            return new ArticuloReadDto
            {
                Id = articulo.Id,
                Nombre = articulo.Nombre,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio,
                IdMarca = articulo.IdMarca,
                IdCategoria = articulo.IdCategoria
            };
        }

        // =====================================================
        // UPDATE
        // =====================================================
        public async Task<ArticuloReadDto> UpdateAsync(int id, ArticuloUpdateDto dto)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
                return null;

            articulo.Nombre = dto.Nombre;
            articulo.Descripcion = dto.Descripcion;
            articulo.Precio = dto.Precio;
            articulo.IdMarca = dto.IdMarca;
            articulo.IdCategoria = dto.IdCategoria;

            _context.Articulos.Update(articulo);
            await _context.SaveChangesAsync();

            return new ArticuloReadDto
            {
                Id = articulo.Id,
                Nombre = articulo.Nombre,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio,
                IdMarca = articulo.IdMarca,
                IdCategoria = articulo.IdCategoria
            };
        }

        // =====================================================
        // DELETE
        // =====================================================
        public async Task<bool> DeleteAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
                return false;

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
