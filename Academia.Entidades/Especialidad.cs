namespace Academia.Entidades
{
    public class Especialidad
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        // Constructor para Post
        public Especialidad(string descripcion)
        {
            SetDescripcion(descripcion);
        }
        public Especialidad(int id, string descripcion)
        {
            Id = id;
            SetDescripcion(descripcion);
        }
        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripcion no puede ser nulo o vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }

    }
}
