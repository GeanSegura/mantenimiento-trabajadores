using MantenimientoTrabajadores.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MantenimientoTrabajadores.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbigeoController : Controller
    {
        private readonly IUbigeoService _ubigeoService;

        public UbigeoController(IUbigeoService ubigeoService)
        {
            _ubigeoService = ubigeoService;
        }

        [HttpGet("departamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            var departamentos = await _ubigeoService.GetDepartamentos();
            return Ok(departamentos);
        }

        [HttpGet("provincias")]
        public async Task<IActionResult> GetProvincias([FromQuery] int id)
        {
            var provincias = await _ubigeoService.GetProvincias(id);
            return Ok(provincias);
        }


        [HttpGet("distritos")]
        public async Task<IActionResult> GetDistritos([FromQuery] int id)
        {
            var distritos = await _ubigeoService.GetDistritos(id);
            return Ok(distritos);
        }
    }
}
