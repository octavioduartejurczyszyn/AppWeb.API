using AppWeb.API.Models.DTOs;
using AppWeb.API.Services; 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloService _service;

        public ArticulosController(IArticuloService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articulos = await _service.GetAllAsync();
            return Ok(articulos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var articulo = await _service.GetByIdAsync(id);
            if (articulo == null)
                return NotFound(new { message = $"No existe artículo con id {id}" });
            return Ok(articulo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticuloCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);

            // CreatedAtAction devuelve 201 con la ruta al recurso creado
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ArticuloUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound(new { message = $"No existe artículo con id {id}" });

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = $"No existe artículo con id {id}" });

            return NoContent(); // 204
        }
    }
}
