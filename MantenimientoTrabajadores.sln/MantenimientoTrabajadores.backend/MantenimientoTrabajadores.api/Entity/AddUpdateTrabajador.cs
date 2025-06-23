namespace MantenimientoTrabajadores.api.Entity
{
    public class AddUpdateTrabajador
    {
        public string? TipoDocumento { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? Nombres { get; set; }

        public string? Sexo { get; set; }

        public int? Departamento { get; set; }

        public int? Provincia { get; set; }

        public int? Distrito { get; set; }
    }
}
