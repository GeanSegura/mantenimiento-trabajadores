using MantenimientoTrabajadores.api.Dto;
using Microsoft.AspNetCore.Components.Web;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace MantenimientoTrabajadores.web.Services
{
    public class TrabajadorService:ITrabajadorService
    {
        private readonly HttpClient _http;

        public TrabajadorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TrabajadorDto>> GetTrabajadoresAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<TrabajadorDto>>("api/Trabajador/lista");

                return response ?? new List<TrabajadorDto>();
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        public async Task<bool> CrearTrabajador(TrabajadorRequestDto obj)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Trabajador/agregar", obj);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarTrabajador(int id, TrabajadorRequestDto obj)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Trabajador/actualizar?id={id}", obj);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

        public async Task<bool> EliminarTrabajador(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/Trabajador/eliminar?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<List<BandejaTrabajadoresRegis>> BandejaTrabajador(string sexo)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<BandejaTrabajadoresRegis>>($"api/Trabajador/listaFiltro?sexo={sexo}");

                return response ?? new List<BandejaTrabajadoresRegis>();
            }
            catch (Exception ex)
            {
                return [];
            }

        }

    }
}
