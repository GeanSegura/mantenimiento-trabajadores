namespace MantenimientoTrabajadores.api.Dto
{
    public class TrabajadorDto
    {
        public int in_id { get; set; }

        public string? vc_tipo_documento { get; set; }

        public string? vc_numero_documento { get; set; }

        public string? vc_nombres { get; set; }

        public string? ch_sexo { get; set; }

        public string? vc_nombre_departamento { get; set; }

        public string? vc_nombre_provincia { get; set; }

        public string? vc_nombre_distrito { get; set; }
    }

    public class TrabajadorRequestDto
    {
        public string? TipoDocumento { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? Nombres { get; set; }

        public string? Sexo { get; set; }

        public int? Departamento { get; set; }

        public int? Provincia { get; set; }

        public int? Distrito { get; set; }
    }


    public class BandejaTrabajadoresRegis
    {
        public string? NumeroDocumento { get; set; }

        public string? Nombres { get; set; }

        public string? Sexo { get; set; }

    }
}
