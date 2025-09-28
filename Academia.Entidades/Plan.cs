namespace Academia.Entidades
{
    public class Plan
    {
        private int _idEspecialidad;
        private Especialidad? _especialidad;
        public int IdPlan { get; private set; }
        public string Descripcion { get; private set; }
        public int IdEspecialidad
        {
            get => _especialidad?.Id ?? _idEspecialidad;
            private set => _idEspecialidad = value;
        }

        public Especialidad? Especialidad
        {
            get => _especialidad;
            private set
            {
                _especialidad = value;
                if (value != null && _idEspecialidad != value.Id)
                {
                    _idEspecialidad = value.Id;
                }
            }
        }

        // Constructor para Post
        public Plan(string descripcion, int idEspecialidad)
        {
            SetDescripcion(descripcion);
            SetIdEspecialidad(idEspecialidad);
        }

        // Constructor completo
        public Plan(int idPlan, string descripcion, int idEspecialidad)
        {
            IdPlan = idPlan;
            SetDescripcion(descripcion);
            SetIdEspecialidad(idEspecialidad);
        }

        protected Plan() { } // Constructor sin parámetros para Entity Framework

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }

        public void SetIdEspecialidad(int idEspecialidad)
        {
            if (idEspecialidad <= 0)
                throw new ArgumentException("El ID de especialidad debe ser mayor a cero.", nameof(idEspecialidad));
            IdEspecialidad = idEspecialidad;
        }
    }
}
