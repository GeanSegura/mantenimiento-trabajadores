using MantenimientoTrabajadores.api.Dto;
using MantenimientoTrabajadores.api.Models;

namespace MantenimientoTrabajadores.api.Services
{
    public interface IUbigeoService
    {
        Task<List<DepartamentoDto>> GetDepartamentos();
        Task<List<ProvinciaDto>> GetProvincias(int id);
        Task<List<DistritoDto>> GetDistritos(int id);
    }
}
