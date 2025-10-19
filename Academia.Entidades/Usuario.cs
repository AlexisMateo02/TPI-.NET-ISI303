using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Academia.Entidades
{
    public class Usuario
    {
        private int? _idPersona;
        private Persona? _persona;
        public int Id { get; private set; }
        public string NombreUsuario { get; private set; }
        public string Clave { get; private set; } //PasswordHash
        public string Salt { get; private set; }
        public bool Habilitado { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public int Rol { get; private set; }

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
        public Usuario(string nombreUsuario, string clave, DateTime fechaAlta, int rolUsuario, int idPersona)
        {
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            Habilitado = true;
            SetFechaAlta(fechaAlta);
            SetRol(rolUsuario);
            SetIdPersona(idPersona);
        }

        // Constructor para Post sin Persona
        public Usuario(string nombreUsuario, string clave, DateTime fechaAlta, int rolUsuario)
        {
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            Habilitado = true;
            SetFechaAlta(fechaAlta);
            SetRol(rolUsuario);
            _idPersona = null;
        }

        // Constructor completo con Persona
        public Usuario(int id, string nombreUsuario, string clave, bool habilitado, DateTime fechaAlta, int rolUsuario, int idPersona)
        {
            Id = id;
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            SetHabilitado(habilitado);
            SetFechaAlta(fechaAlta);
            SetRol(rolUsuario);
            SetIdPersona(idPersona);
        }

        // Constructor completo sin Persona
        public Usuario(int id, string nombreUsuario, string clave, bool habilitado, DateTime fechaAlta, int rolUsuario)
        {
            Id = id;
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            SetHabilitado(habilitado);
            SetFechaAlta(fechaAlta);
            SetRol(rolUsuario);
            _idPersona = null;
        }

        // Constructor para cambio de contraseña con persona
        public void CambioContrasenia(int id, string nombreUsuario, string clave, bool habilitado, DateTime fechaAlta, int rolUsuario, int idPersona)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            SetClave(clave);
            Habilitado = habilitado;
            FechaAlta = fechaAlta;
            Rol = rolUsuario;
            _idPersona = idPersona;
        }

        // Constructor para cambio de contraseña sin persona
        public void CambioContrasenia(int id, string nombreUsuario, string clave, bool habilitado, DateTime fechaAlta, int rolUsuario)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            SetClave(clave);
            Habilitado = habilitado;
            FechaAlta = fechaAlta;
            Rol = rolUsuario;
            _idPersona = null;
        }

        protected Usuario() { } // Constructor sin parámetros para Entity Framework
        public void SetNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.", nameof(nombreUsuario));
            NombreUsuario = nombreUsuario;
        }
        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(clave));

            if (clave.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.", nameof(clave));

            Salt = GenerateSalt();
            Clave = HashPassword(clave, Salt);
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
        public void SetRol(int rol)
        {
            if (rol < 1 || rol > 3)
            {
                throw new ArgumentException("El rol debe ser 1 (Admin), 2 (Docente) o 3 (Alumno).", nameof(rol));
            }
            Rol = rol;
        }
        public void SetIdPersona(int? idPersona)
        {
            if (idPersona <= 0)
                throw new ArgumentException("El ID de la persona debe ser mayor que cero.", nameof(idPersona));
            IdPersona = idPersona;
        }
        public bool ValidateClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                return false;

            string hashedInput = HashPassword(clave, Salt);
            return Clave == hashedInput;
        }
        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            RandomNumberGenerator.Fill(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private static string HashPassword(string clave, string salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(clave, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
