namespace DTOs
{
    public class CursoDTO
    {
        public int IdCurso { get; set; }
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }
        public int IdComision { get; set; }
        public string? DescripcionComision { get; set; }
        public int IdMateria { get; set; }
        public string? DescripcionMateria { get; set; }
        public List<AlumnoInscripcionDTO>? AlumnosInscriptos { get; set; }
        public string DescripcionCompleta
        {
            get
            {
                return $"{DescripcionMateria} - {DescripcionComision} ({AnioCalendario})";
            }
        }
    }
}
