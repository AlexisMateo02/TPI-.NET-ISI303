namespace Academia.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public DateTime FechaAlta { get; private set; }
        // Constructor para Post
        public Usuario(string nombre, string clave, DateTime fechaAlta)
        {
            SetNombre(nombre);
            SetClave(clave);
            Habilitado = true;
            SetFechaAlta(fechaAlta);
        }
        public Usuario(int id, string nombre, string clave, bool habilitado, DateTime fechaAlta)
        {
            Id = id;
            SetNombre(nombre);
            SetClave(clave);
            SetHabilitado(habilitado);
            SetFechaAlta(fechaAlta);
        }
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
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
    }
}
