using Microsoft.AspNetCore.Mvc;

namespace MantenimientoTrabajadores.api.Dto
{
    public class DepartamentoDto
    {
        public int Id { get; set; }
        public string? NombreDepartamento { get; set; }
    }

    public class ProvinciaDto
    {
        public int Id { get; set; }
        public string? NombreProvincia { get; set; }
    }

    public class DistritoDto
    {
        public int Id { get; set; }
        public string? NombreDistrito { get; set; }
    }
}
