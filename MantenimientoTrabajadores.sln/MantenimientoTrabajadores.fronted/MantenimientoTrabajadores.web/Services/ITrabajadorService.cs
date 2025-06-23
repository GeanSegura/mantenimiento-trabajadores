using MantenimientoTrabajadores.api.Dto;

namespace MantenimientoTrabajadores.web.Services
{
    public interface ITrabajadorService
    {
        Task<List<TrabajadorDto>> GetTrabajadoresAsync();
        Task<bool> CrearTrabajador(TrabajadorRequestDto obj);
    }
}
