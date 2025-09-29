namespace Academia.Entidades
{
    public class Comision
    {
        private int _idPlan;
        private Plan? _plan;
        public int IdComision { get; private set; }
        public string DescripcionComision { get; private set; }
        public int AnioEspecialidad { get; private set; }
        public int IdPlan
        {
            get => _plan?.IdPlan ?? _idPlan;
            private set => _idPlan = value;
        }
        public Plan? Plan
        {
            get => _plan;
            private set
            {
                _plan = value;
                if (value != null && _idPlan != value.IdPlan)
                {
                    _idPlan = value.IdPlan;
                }
            }
        }

        // Constructor para Post
        public Comision(string descripcionComision, int anioEspecialidad, int idPlan)
        {
            SetDescripcionComision(descripcionComision);
            SetAnioEspecialidad(anioEspecialidad);
            SetIdPlan(idPlan);
        }

        // Constructor completo
        public Comision(int idComision, string descripcionComision, int anioEspecialidad, int idPlan)
        {
            IdComision = idComision;
            SetDescripcionComision(descripcionComision);
            SetAnioEspecialidad(anioEspecialidad);
            SetIdPlan(idPlan);
        }

        protected Comision() { } // Constructor sin parámetros para Entity Framework

        public void SetDescripcionComision(string descripcionComision)
        {
            if (string.IsNullOrWhiteSpace(descripcionComision))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcionComision));
            DescripcionComision = descripcionComision;
        }

        public void SetAnioEspecialidad(int anioEspecialidad)
        {
            int añoActual = DateTime.Now.Year;
            if (anioEspecialidad > añoActual)
                throw new ArgumentException($"El año de especialidad no puede ser mayor al año actual ({añoActual}).", nameof(anioEspecialidad));
            if (anioEspecialidad < 1950)
                throw new ArgumentException("El año de especialidad debe ser mayor a 1950.", nameof(anioEspecialidad));
            AnioEspecialidad = anioEspecialidad;
        }

        public void SetIdPlan(int idPlan)
        {
            if (idPlan <= 0)
                throw new ArgumentException("El ID del plan debe ser mayor que cero.", nameof(idPlan));
            IdPlan = idPlan;
        }
    }
}
