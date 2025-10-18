namespace DTOs
{
    public class DocenteCursoDTO
    {
        public int IdDictado { get; set; }
        public string Cargo { get; set; }
        public int IdDocente { get; set; }
        public int? Legajo { get; set; }
        public string? NombrePersona { get; set; }
        public string? ApellidoPersona { get; set; }
        public string NombreCompletoPersona
        {
            get
            {
                if (string.IsNullOrEmpty(NombrePersona) && string.IsNullOrEmpty(ApellidoPersona))
                {
                    return "";
                }
                else
                {
                    return $"{ApellidoPersona}, {NombrePersona}";
                }
            }
        }
        public int IdCurso { get; set; }
        public int? AnioCalendario { get; set; }
        public int? IdComision { get; set; }
        public string? DescripcionComision { get; set; }
        public int? IdMateria { get; set; }
        public string? DescripcionMateria { get; set; }
    }
}

