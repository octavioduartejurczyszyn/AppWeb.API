using AppWeb.API.Models.DTOs;
using AppWeb.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService _service;

        public MarcasController(IMarcaService service)
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
            var marca = await _service.GetByIdAsync(id);

            if (marca == null)
                return NotFound();

            return Ok(marca);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MarcaCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MarcaUpdateDto dto)
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
