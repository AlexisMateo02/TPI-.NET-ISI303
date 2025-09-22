namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
