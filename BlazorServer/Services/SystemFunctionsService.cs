using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class SystemFunctionsService
    {
        private readonly List<SystemFunction> _allFunctions;

        public SystemFunctionsService()
        {
            _allFunctions = new List<SystemFunction>
            {
                new SystemFunction(
                    "Gestión de Usuarios",
                    "Administrar usuarios y permisos del sistema",
                    "/usuarios",
                    "bi-people-fill",
                    Rol.Administrador
                ),
                new SystemFunction(
                    "Planes Académicos",
                    "Gestionar planes de estudio",
                    "/planes",
                    "bi-journal-bookmark-fill",
                    Rol.Administrador, Rol.Docente
                ),
                new SystemFunction(
                    "Especialidades",
                    "Gestionar especialidades académicas",
                    "/especialidades",
                    "bi-mortarboard-fill",
                    Rol.Administrador, Rol.Docente
                ),
                new SystemFunction(
                    "Cursos",
                    "Gestionar cursos y materias",
                    "/cursos",
                    "bi-book-fill",
                    Rol.Administrador, Rol.Docente
                ),
                new SystemFunction(
                    "Mis Cursos",
                    "Ver mis cursos asignados",
                    "/mis-cursos",
                    "bi-collection-fill",
                    Rol.Docente, Rol.Alumno
                ),
                new SystemFunction(
                    "Inscripciones",
                    "Inscribirse a cursos disponibles",
                    "/inscripciones",
                    "bi-pencil-square",
                    Rol.Alumno
                ),
                new SystemFunction(
                    "Calificaciones",
                    "Consultar calificaciones",
                    "/calificaciones",
                    "bi-clipboard-data-fill",
                    Rol.Alumno
                ),
                new SystemFunction(
                    "Reportes",
                    "Generar reportes del sistema",
                    "/reportes",
                    "bi-file-earmark-bar-graph-fill",
                    Rol.Administrador
                ),
                new SystemFunction(
                    "Configuración",
                    "Configurar parámetros del sistema",
                    "/configuracion",
                    "bi-gear-fill",
                    Rol.Administrador
                )
            };
        }

        public List<SystemFunction> GetFunctionsForRole(Rol rol)
        {
            return _allFunctions
                .Where(f => f.AllowedRoles.Contains(rol))
                .ToList();
        }

        public List<SystemFunction> GetAllFunctions()
        {
            return _allFunctions.ToList();
        }

        public SystemFunction? GetFunctionByUrl(string url)
        {
            return _allFunctions.FirstOrDefault(f => f.Url.Equals(url, StringComparison.OrdinalIgnoreCase));
        }

        public bool CanAccessFunction(string url, Rol rol)
        {
            var function = GetFunctionByUrl(url);
            return function?.AllowedRoles.Contains(rol) ?? false;
        }
    }
}
