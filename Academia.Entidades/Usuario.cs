using System.ComponentModel.DataAnnotations;

namespace Academia.Entidades
{
    public class Usuario
    {
        private int _idUsuario;
        private string _nombreUsuario;
        private string _clave;
        private bool _habilitado;
        [Key]
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public bool Habilitado { get => _habilitado; set => _habilitado = value; }
    }
}
