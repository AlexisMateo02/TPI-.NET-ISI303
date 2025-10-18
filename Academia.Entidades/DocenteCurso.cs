namespace Academia.Entidades
{
    public class DocenteCurso
    {
        private int _idDocente;
        private Persona? _docente;
        private int _idCurso;
        private Curso? _curso;
        public int IdDictado { get; private set; }
        public string Cargo { get; private set; }
        public int IdDocente
        {
            get => _docente?.IdPersona ?? _idDocente;
            private set => _idDocente = value;
        }

        public Persona? Docente
        {
            get => _docente;
            private set
            {
                _docente = value;
                if (value != null && _idDocente != value.IdPersona)
                {
                    _idDocente = value.IdPersona;
                }
            }
        }

        public int IdCurso
        {
            get => _curso?.IdCurso ?? _idCurso;
            private set => _idCurso = value;
        }

        public Curso? Curso
        {
            get => _curso;
            private set
            {
                _curso = value;
                if (value != null && _idCurso != value.IdCurso)
                {
                    _idCurso = value.IdCurso;
                }
            }
        }

        public DocenteCurso(string cargo, int idDocente, int idCurso)
        {
            SetCargo(cargo);
            SetIdDocente(idDocente);
            SetIdCurso(idCurso);
        }

        public DocenteCurso(int idDictado, string cargo, int idDocente, int idCurso)
        {
            IdDictado = idDictado;
            SetCargo(cargo);
            SetIdDocente(idDocente);
            SetIdCurso(idCurso);
        }

        protected DocenteCurso() { } // Constructor sin parámetros para Entity Framework

        public void SetCargo(string cargo)
        {
            if (string.IsNullOrWhiteSpace(cargo))
                throw new ArgumentException("El cargo no puede ser nulo o vacío.", nameof(cargo));
            Cargo = cargo;
        }

        public void SetIdDocente(int idDocente)
        {
            if (idDocente <= 0)
                throw new ArgumentException("El ID de docente debe ser mayor a cero.", nameof(idDocente));
            IdDocente = idDocente;
        }

        public void SetIdCurso(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El ID de curso debe ser mayor a cero.", nameof(idCurso));
            IdCurso = idCurso;
        }
    }
}
