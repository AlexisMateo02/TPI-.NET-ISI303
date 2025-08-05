namespace APIWeb.DTOs
{
    public class UsuarioDTO
    {
        private string _nombreUsuario;
        private string _clave;
        private bool _habilitado;
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public bool Habilitado { get => _habilitado; set => _habilitado = value; }
    }
}
