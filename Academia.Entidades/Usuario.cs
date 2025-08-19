using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Entidades
{
    public class Usuario
    {
        private int _idUsuario;
        private string _nombreUsuario;
        private string _clave;
        private bool _habilitado;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public bool Habilitado { get => _habilitado; set => _habilitado = value; }
    }
}
