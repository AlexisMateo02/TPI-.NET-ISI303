namespace Academia.Entidades
{
    public class Usuario
    {
        private int? _idPersona;
        private Persona? _persona;
        public int Id { get; private set; }
        public string NombreUsuario { get; private set; }
        public string Clave { get; private set; }
        public bool Habilitado { get; private set; }
        public DateTime FechaAlta { get; private set; }

        public int? IdPersona
        {
            get => _persona?.IdPersona ?? _idPersona;
            private set => _idPersona = value;
        }

        public Persona? Persona
        {
            get => _persona;
            private set
            {
                _persona = value;
                _idPersona = value?.IdPersona; // null si no hay persona
            }
        }

        // Constructor para Post con Persona
        public Usuario(string nombreUsuario, string clave, DateTime fechaAlta, int idPersona)
        {
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            Habilitado = true;
            SetFechaAlta(fechaAlta);
            SetIdPersona(idPersona);
        }

        // Constructor para Post sin Persona
        public Usuario(string nombreUsuario, string clave, DateTime fechaAlta)
        {
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            Habilitado = true;
            SetFechaAlta(fechaAlta);
            _idPersona = null;
        }

        // Constructor completo con Persona
        public Usuario(int id, string nombreUsuario, string clave, bool habilitado, DateTime fechaAlta, int idPersona)
        {
            Id = id;
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            SetHabilitado(habilitado);
            SetFechaAlta(fechaAlta);
            SetIdPersona(idPersona);
        }

        // Constructor completo sin Persona
        public Usuario(int id, string nombreUsuario, string clave, bool habilitado, DateTime fechaAlta)
        {
            Id = id;
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            SetHabilitado(habilitado);
            SetFechaAlta(fechaAlta);
            _idPersona = null;
        }

        public void SetNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.", nameof(nombreUsuario));
            NombreUsuario = nombreUsuario;
        }
        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede ser nula o vacía.", nameof(clave));

            if (clave.Length < 6)
                throw new ArgumentException("La clave debe tener al menos 6 caracteres.", nameof(clave));

            Clave = PasswordHelper.HashPassword(clave);
        }
        public void SetHabilitado(bool habilitado)
        {
            Habilitado = habilitado;
        }
        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default)
                throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }
        public void SetIdPersona(int? idPersona)
        {
            if (idPersona <= 0)
                throw new ArgumentException("El ID de la persona debe ser mayor que cero.", nameof(idPersona));
            IdPersona = idPersona;
        }
    }
}
