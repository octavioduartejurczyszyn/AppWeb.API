using AppWeb.API.Models.DTOs;
using AppWeb.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _service.GetByIdAsync(id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoriaUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
