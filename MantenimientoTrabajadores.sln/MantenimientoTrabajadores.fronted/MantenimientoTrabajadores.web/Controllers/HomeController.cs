using MantenimientoTrabajadores.web.Models;
using MantenimientoTrabajadores.web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MantenimientoTrabajadores.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUbigeoService _ubigeoService;
        private readonly ITrabajadorService _trabajadorService;

        public HomeController(IUbigeoService ubigeoService, ITrabajadorService trabajadorService)
        {
            _ubigeoService = ubigeoService;
            _trabajadorService = trabajadorService;
        }

        public async Task<IActionResult> Index()
        {
            var departamentos = await _ubigeoService.GetDepartamentosAsync();
            var trabajadores = await _trabajadorService.GetTrabajadoresAsync();
            ViewBag.Departamentos = departamentos;
            return View(trabajadores);
        }

        [HttpGet]
        public async Task<IActionResult> GetProvincias(int id)
        {
            var provincias = await _ubigeoService.GetProvinciasAsync(id);
            return Json(provincias);
        }

        [HttpGet]
        public async Task<IActionResult> GetDistritos(int id)
        {
            var distritos = await _ubigeoService.GetDistritosAsync(id);
            return Json(distritos);
        }

    }
}
