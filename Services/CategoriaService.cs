using AppWeb.API.Data;
using AppWeb.API.Models;
using AppWeb.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaReadDto>> GetAllAsync()
        {
            return await _context.Categorias
                .Select(c => new CategoriaReadDto
                {
                    Id = c.Id,
                    Descripcion = c.Descripcion
                })
                .ToListAsync();
        }

        public async Task<CategoriaReadDto?> GetByIdAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return null;

            return new CategoriaReadDto
            {
                Id = categoria.Id,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task<CategoriaReadDto> CreateAsync(CategoriaCreateDto dto)
        {
            var categoria = new Categoria
            {
                Descripcion = dto.Descripcion
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return new CategoriaReadDto
            {
                Id = categoria.Id,
                Descripcion = categoria.Descripcion
            };
        }

        public async Task<bool> UpdateAsync(int id, CategoriaUpdateDto dto)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return false;

            categoria.Descripcion = dto.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
