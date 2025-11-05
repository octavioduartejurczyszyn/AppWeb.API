using Microsoft.AspNetCore.Mvc;
using AppWeb.API.Business;
using AppWeb.API.Models;

namespace AppWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloService _articuloService;

        public ArticulosController(ArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        // GET: api/articulos

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var lista = _articuloService.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener artículos: {ex.Message}");
            }
        }

        // GET: api/articulos/filtrar?campo=Marca&criterio=Comienza%20con&filtro=Sam

        [HttpGet("filtrar")]
        public IActionResult Filtrar(string campo, string criterio, string filtro)
        {
            try
            {
                var resultado = _articuloService.Filtrar(campo, criterio, filtro);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al filtrar artículos: {ex.Message}");
            }
        }

        // POST: api/articulos

        [HttpPost]
        public IActionResult Post([FromBody] Articulo articulo)
        {
            if (articulo == null)
                return BadRequest("El artículo no puede ser nulo.");

            try
            {
                _articuloService.Agregar(articulo);
                return Ok("Artículo agregado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar artículo: {ex.Message}");
            }
        }

        // PUT: api/articulos/{id}

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Articulo articulo)
        {
            if (articulo == null)
                return BadRequest("El artículo no puede ser nulo.");

            try
            {
                _articuloService.Modificar(id, articulo);
                return Ok("Artículo modificado correctamente.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró un artículo con el ID {id}.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al modificar artículo: {ex.Message}");
            }
        }

        // DELETE: api/articulos/{id}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _articuloService.Eliminar(id);
                return Ok("Artículo eliminado correctamente.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró un artículo con el ID {id}.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar artículo: {ex.Message}");
            }
        }

    }
}
