namespace Academia.Entidades
{
    public class AlumnoInscripcion
    {
        private int _idAlumno;
        private Persona? _alumno;
        private int _idCurso;
        private Curso? _curso;
        public int IdInscripcion { get; private set; }
        public string Condicion { get; private set; }
        public int? Nota { get; private set; }

        public int IdAlumno
        {
            get => _alumno?.IdPersona ?? _idAlumno;
            private set => _idAlumno = value;
        }

        public Persona? Alumno
        {
            get => _alumno;
            private set
            {
                _alumno = value;
                if (value != null && _idAlumno != value.IdPersona)
                {
                    _idAlumno = value.IdPersona;
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

        public AlumnoInscripcion(string condicion, int? nota,int idAlumno, int idCurso)
        {
            SetCondicion(condicion);
            SetNota(nota);
            SetIdAlumno(idAlumno);
            SetIdCurso(idCurso);
        }

        public AlumnoInscripcion(int idInscripcion, string condicion, int? nota, int idAlumno, int idCurso)
        {
            IdInscripcion = idInscripcion;
            SetCondicion(condicion);
            SetNota(nota);
            SetIdAlumno(idAlumno);
            SetIdCurso(idCurso);
        }

        protected AlumnoInscripcion() { } // Constructor sin parámetros para Entity Framework

        public void SetCondicion(string condicion)
        {
            if (string.IsNullOrWhiteSpace(condicion))
                throw new ArgumentException("La condición no puede ser nula o vacía.", nameof(condicion));

            // Validar que sea una condición válida
            var condicionesValidas = new[] { "Cursando", "Regular", "Aprobado", "Libre" };
            if (!condicionesValidas.Contains(condicion))
                throw new ArgumentException($"La condición debe ser una de las siguientes: {string.Join(", ", condicionesValidas)}.", nameof(condicion));

            Condicion = condicion;
        }

        public void SetNota(int? nota)
        {
            if (nota.HasValue)
            {
                if (nota < 0)
                    throw new ArgumentException("La nota no puede ser negativa.", nameof(nota));
                if (nota > 10)
                    throw new ArgumentException("La nota no puede ser mayor a 10.", nameof(nota));
            }
            Nota = nota;
        }

        public void SetIdAlumno(int idAlumno)
        {
            if (idAlumno <= 0)
                throw new ArgumentException("El ID de alumno debe ser mayor a cero.", nameof(idAlumno));
            IdAlumno = idAlumno;
        }

        public void SetIdCurso(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El ID de curso debe ser mayor a cero.", nameof(idCurso));
            IdCurso = idCurso;
        }
    }
}
