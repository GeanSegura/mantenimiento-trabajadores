using Azure.Core;
using MantenimientoTrabajadores.api.Dto;
using MantenimientoTrabajadores.api.Entity;
using MantenimientoTrabajadores.api.Models;
using Microsoft.EntityFrameworkCore;

namespace MantenimientoTrabajadores.api.Services
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly ApplicationDbContext _db;

        public TrabajadorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<TrabajadorDto>> GetTrabajadores()
        {
            try
            {
                var resultado = await _db.TrabajadorDtos
                .FromSqlRaw("EXEC UspGetTrabajadores")
                .ToListAsync();

                if(resultado.Count >=0)
                {
                    return resultado;
                }

                return new List<TrabajadorDto>();

            }
            catch(Exception e)
            {
                return new List<TrabajadorDto>();
            }
        }

        public async Task<List<BandejaTrabajadoresRegis>> GetTrabajadoresFiltro(string? sexo)
        {
            try
            {
                var trabajadoresFiltro = await _db.Trabajadores
                    .Where(d => d.Sexo == sexo)
                    .Select(t => new BandejaTrabajadoresRegis
                    {
                        NumeroDocumento = t.NumeroDocumento,
                        Nombres = t.Nombres,
                        Sexo = t.Sexo
                    }).ToListAsync();

                if(trabajadoresFiltro != null)
                {
                    return trabajadoresFiltro;
                }

                    return new List<BandejaTrabajadoresRegis>();
            }
            catch (Exception e)
            {
                return new List<BandejaTrabajadoresRegis>();
            }
        }


        public async Task<bool> UpdateTrabajador(int id, AddUpdateTrabajador obj)
        {
            try
            {
                var trabajador = await _db.Trabajadores.FirstOrDefaultAsync(index => index.Id == id);

                if (trabajador != null)
                {
                    trabajador.TipoDocumento = obj.TipoDocumento;
                    trabajador.NumeroDocumento = obj.NumeroDocumento;
                    trabajador.Nombres = obj.Nombres;
                    trabajador.Sexo = obj.Sexo;
                    trabajador.IdDepartamento = obj.Departamento;
                    trabajador.IdProvincia = obj.Provincia;
                    trabajador.IdDistrito = obj.Distrito;

                    var result = await _db.SaveChangesAsync();
                    return result >= 0;
                }

                return false;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTrabajador(int id)
        {
            try
            {
                var hero = await _db.Trabajadores.FirstOrDefaultAsync(index => index.Id == id);
                if (hero != null)
                {
                    _db.Trabajadores.Remove(hero);
                    var result = await _db.SaveChangesAsync();
                    return result >= 0;
                }

                return false;

            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> AddTrabajador(AddUpdateTrabajador obj)
        {
            try
            {
                var addTrabajador = new Trabajadore()
                {
                    TipoDocumento = obj.TipoDocumento,
                    NumeroDocumento = obj.NumeroDocumento,
                    Nombres = obj.Nombres,
                    Sexo = obj.Sexo,
                    IdDepartamento = obj.Departamento,
                    IdProvincia = obj.Provincia,
                    IdDistrito = obj.Distrito,
                };

                _db.Trabajadores.Add(addTrabajador);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            catch(Exception e)
            {
                return false;
            }
         
        }
    }
}
