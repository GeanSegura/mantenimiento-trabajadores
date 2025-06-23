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
    }
}
