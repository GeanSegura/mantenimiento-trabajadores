using MantenimientoTrabajadores.api.Dto;

namespace MantenimientoTrabajadores.web.Services
{
    public interface IUbigeoService
    {
        Task<List<DepartamentoDto>> GetDepartamentosAsync();
        Task<List<ProvinciaDto>> GetProvinciasAsync(int idDepartamento);
        Task<List<DistritoDto>> GetDistritosAsync(int idProvincia);
    }
}
