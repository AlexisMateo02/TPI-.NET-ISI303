using System.Text.RegularExpressions;

namespace Academia.Entidades
{
    public class Persona
    {
        private int _idPlan;
        private Plan? _plan;
        public int IdPersona { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Direccion { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public int Legajo { get; private set; }
        public int TipoPersona { get; private set; }
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
        public Persona(string nombre, string apellido, string direccion, string email,
                      string telefono, DateTime fechaNacimiento, int legajo, int tipoPersona, int idPlan)
        {
            SetNombre(nombre);
            SetApellido(apellido);
            SetDireccion(direccion);
            SetEmail(email);
            SetTelefono(telefono);
            SetFechaNacimiento(fechaNacimiento);
            SetLegajo(legajo);
            SetTipoPersona(tipoPersona);
            SetIdPlan(idPlan);
        }

        // Constructor completo
        public Persona(int idPersona, string nombre, string apellido, string direccion, string email,
                      string telefono, DateTime fechaNacimiento, int legajo, int tipoPersona, int idPlan)
        {
            IdPersona = idPersona;
            SetNombre(nombre);
            SetApellido(apellido);
            SetDireccion(direccion);
            SetEmail(email);
            SetTelefono(telefono);
            SetFechaNacimiento(fechaNacimiento);
            SetLegajo(legajo);
            SetTipoPersona(tipoPersona);
            SetIdPlan(idPlan);
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección no puede ser nula o vacía.", nameof(direccion));
            Direccion = direccion;
        }

        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede ser nulo o vacío.", nameof(telefono));
            Telefono = telefono;
        }

        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            if (fechaNacimiento == default)
                throw new ArgumentException("La fecha de nacimiento no puede ser nula.", nameof(fechaNacimiento));
            if (fechaNacimiento >= DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento debe ser anterior a la fecha actual.", nameof(fechaNacimiento));
            FechaNacimiento = fechaNacimiento;
        }

        public void SetLegajo(int legajo)
        {
            if (legajo <= 0)
                throw new ArgumentException("El legajo debe ser mayor que cero.", nameof(legajo));
            Legajo = legajo;
        }

        public void SetTipoPersona(int tipoPersona)
        {
            if (tipoPersona != 1 && tipoPersona != 2)
                throw new ArgumentException("El tipo de persona debe ser 1 (Alumno) o 2 (Docente).", nameof(tipoPersona));
            TipoPersona = tipoPersona;
        }

        public void SetIdPlan(int idPlan)
        {
            if (idPlan <= 0)
                throw new ArgumentException("El ID del plan debe ser mayor que cero.", nameof(idPlan));
            IdPlan = idPlan;
        }
    }
}
