using InventarioAPI.Models;
using InventarioAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductosController(ProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Producto>> ObtenerTodos()
        {
            return Ok(_service.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerPorId(int id)
        {
            var producto = _service.ObtenerPorId(id);
            if (producto == null)
                return NotFound(new { mensaje = "Producto no encontrado" });
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Crear([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevo = _service.Crear(producto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public ActionResult<Producto> Actualizar(int id, [FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _service.Actualizar(id, producto);
            if (actualizado == null)
                return NotFound(new { mensaje = "Producto no encontrado" });
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var eliminado = _service.Eliminar(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Producto no encontrado" });
            return NoContent();
        }
    }
}