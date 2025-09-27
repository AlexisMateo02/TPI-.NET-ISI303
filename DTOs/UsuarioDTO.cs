namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public DateTime FechaAlta { get; set; }
        public int? IdPersona { get; set; }
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
    }
}
