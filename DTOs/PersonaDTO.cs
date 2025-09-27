namespace DTOs
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Legajo { get; set; }
        public int TipoPersona { get; set; }
        public int IdPlan { get; set; }
        public string? DescripcionPlan { get; set; }
        public string? DescripcionEspecialidad { get; set; }
        public string TipoPersonaDescripcion
        {
            get
            {
                if (TipoPersona == 1)
                {
                    return "Alumno";
                }
                else
                {
                    return "Docente";
                }
            }
        }
        public string NombreCompletoPersona
        {
            get
            {
                return $"{Apellido}, {Nombre}";
            }
        }
    }
}
