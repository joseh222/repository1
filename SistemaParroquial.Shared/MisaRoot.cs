namespace SistemaParroquial.Shared
{
    public class MisaRoot
    {
        public int IdMisa { get; set; }
        public MisaTipo? TipoMisa { get; set; }
        public MisaMotivo? MotivoMisa { get; set; }
        public string? Motivo { get; set; }
        public List<NombresRoot>? ListNombres { get; set; }
        public DateTime? FhMisa { get; set; }
        public decimal? Pay { get; set; }
        public string? Observaciones { get; set; }
        public bool FlgMisaPersonal { get; set; }
        public DateTime? FhCreacion { get; set; }
        public DateTime? FhActualizacion { get; set; }
        public bool FlgEliminado { get; set; }
        public DateTime? DateMass { get; set; }
        public DateTime? HoraMass { get; set; }

        //propiedades para usar en el mudtable
        public string? StrFhMisa { get; set; }
        public bool ShowDetails { get; set; } //para detalle del registro
    }
}
