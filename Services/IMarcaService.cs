using AppWeb.API.Models.DTOs;

namespace AppWeb.API.Services
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaReadDto>> GetAllAsync();
        Task<MarcaReadDto?> GetByIdAsync(int id);
        Task<MarcaReadDto> CreateAsync(MarcaCreateDto dto);
        Task<bool> UpdateAsync(int id, MarcaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
