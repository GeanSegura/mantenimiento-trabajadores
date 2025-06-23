using MantenimientoTrabajadores.api.Dto;

namespace MantenimientoTrabajadores.web.Services
{
    public class UbigeoService : IUbigeoService
    {
        private readonly HttpClient _http;

        public UbigeoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DepartamentoDto>> GetDepartamentosAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<DepartamentoDto>>("api/ubigeo/departamentos");

                return response ?? new List<DepartamentoDto>();
            }
            catch (Exception ex)
            {
                return []; 
            }
        }

        public async Task<List<ProvinciaDto>> GetProvinciasAsync(int idDepartamento)
        {
            try
            {
                var response =  await _http.GetFromJsonAsync<List<ProvinciaDto>>($"api/ubigeo/provincias?id={idDepartamento}");

                return response ?? new List<ProvinciaDto>();
            }
            catch (Exception ex)
            {
                return [];
            }
            
        }

        public async Task<List<DistritoDto>> GetDistritosAsync(int idProvincia)
        {
            try
            {
                var response=  await _http.GetFromJsonAsync<List<DistritoDto>>($"api/ubigeo/distritos?id={idProvincia}");

                return response ?? new List<DistritoDto>();
            }
            catch (Exception ex)
            {
                return [];
            }
            
        }
    }
}
