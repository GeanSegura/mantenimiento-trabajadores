using MantenimientoTrabajadores.api.Dto;
using MantenimientoTrabajadores.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace MantenimientoTrabajadores.web.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly ITrabajadorService _trabajadorService;

        public TrabajadorController(ITrabajadorService trabajadorService)
        {
            _trabajadorService = trabajadorService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TrabajadorRequestDto dto)
        {
            var ok = await _trabajadorService.CrearTrabajador(dto);
            if (ok)
                return Json(new { success = true, message = "Se ha creado al trabajador éxitosamente" });

            return Json(new { success = false, message = "Error al crear al trabajador" });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] TrabajadorRequestDto dto,int id)
        {
            var ok = await _trabajadorService.ActualizarTrabajador(id,dto);
            if (ok)
                return Json(new { success = true, message = "Se ha creado al trabajador éxitosamente" });

            return Json(new { success = false, message = "Error al crear al trabajador" });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ok = await _trabajadorService.EliminarTrabajador(id);
            if (ok)
                return Json(new { success = true, message = "Se ha eliminado al trabajador" });

            return Json(new { success = false, message = "Error al eliminar al trabajador" });
        }

        [HttpGet]
        public async Task<IActionResult> Bandeja(string sexo)
        {
            var lista = await _trabajadorService.BandejaTrabajador(sexo);

            if (lista != null && lista.Any())
            {
                return Json(new { success = true, data = lista });
            }

            return Json(new { success = false, message = "No se encontraron trabajadores." });
        }
    }
}
