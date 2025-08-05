using System.ComponentModel.DataAnnotations;

namespace Academia.Entidades
{
    public class Especialidad
    {
        private int _idEspecialidad;
        private string _descEspecialidad;
        [Key]
        public int IdEspecialidad { get => _idEspecialidad; set => _idEspecialidad = value; }
        public string DescEspecialidad { get => _descEspecialidad; set => _descEspecialidad = value; }
    }
}
