using AppWeb.API.Data;
using AppWeb.API.Models;
using AppWeb.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.API.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly AppDbContext _context;

        public MarcaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MarcaReadDto>> GetAllAsync()
        {
            return await _context.Marcas
                .Select(m => new MarcaReadDto
                {
                    Id = m.Id,
                    Descripcion = m.Descripcion
                })
                .ToListAsync();
        }

        public async Task<MarcaReadDto?> GetByIdAsync(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
                return null;

            return new MarcaReadDto
            {
                Id = marca.Id,
                Descripcion = marca.Descripcion
            };
        }

        public async Task<MarcaReadDto> CreateAsync(MarcaCreateDto dto)
        {
            var marca = new Marca
            {
                Descripcion = dto.Descripcion
            };

            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return new MarcaReadDto
            {
                Id = marca.Id,
                Descripcion = marca.Descripcion
            };
        }

        public async Task<bool> UpdateAsync(int id, MarcaUpdateDto dto)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
                return false;

            marca.Descripcion = dto.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
                return false;

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
