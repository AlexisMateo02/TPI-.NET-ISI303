namespace BlazorServer.Models
{
    // Enum para representar los roles del sistema
    public enum Rol
    {
        Administrador = 1,
        Docente = 2,
        Alumno = 3
    }

    public static class RolExtensions
    {
        public static string GetDisplayName(this Rol rol)
        {
            return rol switch
            {
                Rol.Administrador => "Administrador",
                Rol.Docente => "Docente",
                Rol.Alumno => "Alumno",
                _ => "Usuario"
            };
        }

        public static string GetDescription(this Rol rol)
        {
            return rol switch
            {
                Rol.Administrador => "Acceso completo al sistema",
                Rol.Docente => "Gestión de cursos y calificaciones",
                Rol.Alumno => "Consulta y gestión de inscripciones",
                _ => "Usuario del sistema"
            };
        }

        // Helper para convertir desde int
        public static Rol FromInt(int rolValue)
        {
            return rolValue switch
            {
                1 => Rol.Administrador,
                2 => Rol.Docente,
                3 => Rol.Alumno,
                _ => Rol.Alumno // Default
            };
        }

        // Helper para convertir desde string
        public static Rol FromString(string rolValue)
        {
            if (int.TryParse(rolValue, out int intValue))
            {
                return FromInt(intValue);
            }

            return Enum.TryParse<Rol>(rolValue, true, out var result)
                ? result
                : Rol.Alumno;
        }

        // Helper para convertir a int
        public static int ToInt(this Rol rol)
        {
            return (int)rol;
        }
    }
}
