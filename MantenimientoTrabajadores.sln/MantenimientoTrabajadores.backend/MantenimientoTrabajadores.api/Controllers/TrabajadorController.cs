using MantenimientoTrabajadores.api.Entity;
using MantenimientoTrabajadores.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MantenimientoTrabajadores.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : Controller
    {
        private readonly ITrabajadorService _trabajadorService;

        public TrabajadorController(ITrabajadorService trabajadorService)
        {
            _trabajadorService = trabajadorService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> Get()
        {
            var trabajadores = await _trabajadorService.GetTrabajadores();
            return Ok(trabajadores);
        }

        [HttpGet("listaFiltro")]
        public async Task<IActionResult> Get([FromQuery] string sexo)
        {

            var hero = await _trabajadorService.GetTrabajadoresFiltro(sexo);
            return Ok(hero);

        }

        [HttpPost("agregar")]
        public async Task<IActionResult> Post(AddUpdateTrabajador trabajadorObject)
        {
            var hero = await _trabajadorService.AddTrabajador(trabajadorObject);

            if (!hero)
            {
                return BadRequest(new
                {
                    message = "El trabajador no ha sido registrado"
                });
            }

            return Ok(new
            {
                message = "El trabajador ha sido registrado exitosamente."
            });
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] AddUpdateTrabajador trabajadorObject)
        {
            var hero = await _trabajadorService.UpdateTrabajador(id, trabajadorObject);
            if (!hero)
            {
                return NotFound(new
                {
                    message = "No se ha actualizado al trabajador"
                });
            }

            return Ok(new
            {
                    message = "Se ha actualizado al trabajador"
            });
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (!await _trabajadorService.DeleteTrabajador(id))
            {
                return NotFound(new
                {
                    message = "El trabajador ha sido eliminado"
                });
            }

            return Ok(new
            {
                message = "No se ha eliminado al trabajor"
            });
        }
    }
}
