using AppWeb.API.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppWeb.API.Services
{
    public interface IArticuloService
    {
        Task<IEnumerable<ArticuloReadDto>> GetAllAsync();
        Task<ArticuloReadDto> GetByIdAsync(int id);
        Task<ArticuloReadDto> CreateAsync(ArticuloCreateDto dto);
        Task<ArticuloReadDto?> UpdateAsync(int id, ArticuloUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
