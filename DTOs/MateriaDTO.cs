namespace DTOs
{
    public class MateriaDTO
    {
        public int IdMateria { get; set; }
        public string DescripcionMateria { get; set; }
        public int HorasSemanales { get; set; }
        public int HorasTotales { get; set; }
        public int IdPlan { get; set; }
        public string? DescripcionPlan { get; set; }
        public string? DescripcionEspecialidad { get; set; }
    }
}
