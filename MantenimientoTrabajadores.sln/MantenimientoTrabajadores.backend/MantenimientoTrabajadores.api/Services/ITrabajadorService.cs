using MantenimientoTrabajadores.api.Dto;
using MantenimientoTrabajadores.api.Entity;
using MantenimientoTrabajadores.api.Models;

namespace MantenimientoTrabajadores.api.Services
{
    public interface ITrabajadorService
    {
        Task<List<TrabajadorDto>> GetTrabajadores();
        Task<bool> AddTrabajador(AddUpdateTrabajador obj);
        Task<bool> UpdateTrabajador(int id ,AddUpdateTrabajador obj);
        Task<bool> DeleteTrabajador(int id);
        Task<List<BandejaTrabajadoresRegis>> GetTrabajadoresFiltro(string? sexo);
    }
}
