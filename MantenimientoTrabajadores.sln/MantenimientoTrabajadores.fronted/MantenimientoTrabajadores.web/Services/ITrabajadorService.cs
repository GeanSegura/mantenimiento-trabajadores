using MantenimientoTrabajadores.api.Dto;

namespace MantenimientoTrabajadores.web.Services
{
    public interface ITrabajadorService
    {
        Task<List<TrabajadorDto>> GetTrabajadoresAsync();
        Task<bool> CrearTrabajador(TrabajadorRequestDto obj);
        Task<bool> ActualizarTrabajador(int id,TrabajadorRequestDto obj);
        Task<bool> EliminarTrabajador(int id);
        Task<List<BandejaTrabajadoresRegis>> BandejaTrabajador(string sexo);
    }
}
