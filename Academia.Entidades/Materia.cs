namespace Academia.Entidades
{
    public class Materia
    {
        private int _idPlan;
        private Plan? _plan;
        public int IdMateria { get; private set; }
        public string DescripcionMateria { get; private set; }
        public int HorasSemanales { get; private set; }
        public int HorasTotales { get; private set; }
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
        public Materia(string descripcionMateria, int horasSemanales,int horasTotales, int idPlan)
        {
            SetDescripcionMateria(descripcionMateria);
            SetHorasSemanales(horasSemanales);
            SetHorasTotales(horasTotales);
            SetIdPlan(idPlan);
        }

        // Constructor completo
        public Materia(int idMateria, string descripcionMateria, int horasSemanales, int horasTotales, int idPlan)
        {
            IdMateria = idMateria;
            SetDescripcionMateria(descripcionMateria);
            SetHorasSemanales(horasSemanales);
            SetHorasTotales(horasTotales);
            SetIdPlan(idPlan);
        }

        protected Materia() { } // Constructor sin parámetros para Entity Framework

        public void SetDescripcionMateria(string descripcionMateria)
        {
            if (string.IsNullOrWhiteSpace(descripcionMateria))
                throw new ArgumentException("La descripcion no puede ser nulo o vacía.", nameof(descripcionMateria));
            DescripcionMateria = descripcionMateria;
        }

        public void SetHorasSemanales(int horasSemanales)
        {
            if (horasSemanales <= 0)
                throw new ArgumentException("Las horas semanales deben ser mayor que cero.", nameof(horasSemanales));
            if (horasSemanales > 40)
                throw new ArgumentException("Las horas semanales no pueden ser mayor a 40.", nameof(horasSemanales));
            HorasSemanales = horasSemanales;
        }

        public void SetHorasTotales(int horasTotales)
        {
            if (horasTotales <= 0)
                throw new ArgumentException("Las horas totales deben ser mayor que cero.", nameof(horasTotales));
            if (horasTotales > 2000)
                throw new ArgumentException("Las horas totales no pueden ser mayor a 2000.", nameof(horasTotales));
            HorasTotales = horasTotales;
        }

        public void SetIdPlan(int idPlan)
        {
            if (idPlan <= 0)
                throw new ArgumentException("El ID del plan debe ser mayor que cero.", nameof(idPlan));
            IdPlan = idPlan;
        }
    }
}
