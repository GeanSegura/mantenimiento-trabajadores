using MantenimientoTrabajadores.api.Dto;
using MantenimientoTrabajadores.api.Entity;
using MantenimientoTrabajadores.api.Models;
using Microsoft.EntityFrameworkCore;

namespace MantenimientoTrabajadores.api.Services
{
    public class UbigeoService : IUbigeoService
    {
        private readonly ApplicationDbContext _db;

        public UbigeoService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<DepartamentoDto>> GetDepartamentos()
        {
            try
            {
                var departamentos = await _db.Departamentos
                    .Select(d => new DepartamentoDto
                    {
                        Id = d.Id,
                        NombreDepartamento = d.NombreDepartamento
                    })
                    .ToListAsync();

                if (departamentos != null)
                {
                    return departamentos;
                }

                return new List<DepartamentoDto>(); 

            }catch(Exception e)
            {
                return new List<DepartamentoDto>();
            }
        }

        public async Task<List<ProvinciaDto>> GetProvincias(int id)
        {
            try
            {
                var provincias = await _db.Provincia
               .Where(p => p.IdDepartamento == id)
               .Select(d => new ProvinciaDto
               {
                   Id = d.Id,
                   NombreProvincia = d.NombreProvincia
               })
               .ToListAsync();

                if (provincias != null)
                {
                    return provincias;
                }

                return new List<ProvinciaDto>();

            }catch(Exception e)
            {
                return new List<ProvinciaDto>();
            }
           
        }

        public async Task<List<DistritoDto>> GetDistritos(int id)
        {
            try
            {
                var distritos = await _db.Distritos
                .Where(p => p.IdProvincia == id)
                .Select(d => new DistritoDto
                {
                    Id = d.Id,
                    NombreDistrito = d.NombreDistrito
                })
                .ToListAsync();

                if (distritos != null)
                {
                    return distritos;
                }

                return new List<DistritoDto>();
            }
            catch (Exception e) {
                return new List<DistritoDto>();
            }
         
        }
    }
}
