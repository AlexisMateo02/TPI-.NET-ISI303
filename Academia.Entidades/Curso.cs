namespace Academia.Entidades
{
    public  class Curso
    {
        private int _idComision;
        private Comision? _comision;
        private int _idMateria;
        private Materia? _materia;
        public int IdCurso { get; private set; }
        public int AnioCalendario { get; private set; }
        public int Cupo { get; private set; }
        public int IdComision
        {
            get => _comision?.IdComision ?? _idComision;
            private set => _idComision = value;
        }
        public Comision? Comision
        {
            get => _comision;
            private set
            {
                _comision = value;
                if (value != null && _idComision != value.IdComision)
                {
                    _idComision = value.IdComision;
                }
            }
        }
        public int IdMateria
        {
            get => _materia?.IdMateria ?? _idMateria;
            private set => _idMateria = value;
        }
        public Materia? Materia
        {
            get => _materia;
            private set
            {
                _materia = value;
                if (value != null && _idMateria != value.IdMateria)
                {
                    _idMateria = value.IdMateria;
                }
            }
        }

        // Constructor para Post
        public Curso(int anioCalendario, int cupo, int idComision, int idMateria)
        {
            SetAnioCalendario(anioCalendario);
            SetCupo(cupo);
            SetIdComision(idComision);
            SetIdMateria(idMateria);
        }

        // Constructor completo
        public Curso(int idCurso, int anioCalendario, int cupo, int idComision, int idMateria)
        {
            IdCurso = idCurso;
            SetAnioCalendario(anioCalendario);
            SetCupo(cupo);
            SetIdComision(idComision);
            SetIdMateria(idMateria);
        }

        protected Curso() { } // Constructor sin parámetros para Entity Framework

        public void SetAnioCalendario(int anioCalendario)
        {
            int anioActual = DateTime.Now.Year;
            if (anioCalendario < 1950)
                throw new ArgumentException("El año calendario no puede ser menor a 1950.", nameof(anioCalendario));
            if (anioCalendario > anioActual + 5)
                throw new ArgumentException($"El año calendario no puede ser mayor a {anioActual + 5} (5 años en el futuro).", nameof(anioCalendario));
            AnioCalendario = anioCalendario;
        }

        public void SetCupo(int cupo)
        {
            if (cupo <= 0)
                throw new ArgumentException("El cupo debe ser mayor que cero.", nameof(cupo));
            if (cupo > 1000)
                throw new ArgumentException("El cupo no puede ser mayor a 1000 alumnos.", nameof(cupo));
            Cupo = cupo;
        }

        public void SetIdComision(int idComision)
        {
            if (idComision <= 0)
                throw new ArgumentException("El ID de la comisión debe ser mayor que cero.", nameof(idComision));
            IdComision = idComision;
        }

        public void SetIdMateria(int idMateria)
        {
            if (idMateria <= 0)
                throw new ArgumentException("El ID de la materia debe ser mayor que cero.", nameof(idMateria));
            IdMateria = idMateria;
        }
    }
}
