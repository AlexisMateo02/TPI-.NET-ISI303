using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Academia.WindowsForms.Helpers
{
    public class RoleHelper
    {
        private readonly string _token;

        public RoleHelper(string token)
        {
            _token = token;
        }

        public string GetCurrentUserRole()
        {
            try
            {
                if (string.IsNullOrEmpty(_token)) return "3";

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(_token);
                var roleClaim = token.Claims.FirstOrDefault(c => c.Type == "rol");

                return roleClaim?.Value ?? "3"; // Default: Alumno
            }
            catch
            {
                return "3";
            }
        }

        public bool IsAdmin()
        {
            var role = GetCurrentUserRole();
            return role == "1";
        }

        public bool IsDocente()
        {
            var role = GetCurrentUserRole();
            return role == "2";
        }

        public bool IsAlumno()
        {
            var role = GetCurrentUserRole();
            return role == "3";
        }

        public bool IsAdminOrDocente()
        {
            var role = GetCurrentUserRole();
            return role == "1" || role == "2";
        }

        public string GetRoleDisplayName(string role)
        {
            return role switch
            {
                "1" => "Administrador",
                "2" => "Docente",
                "3" => "Alumno",
                _ => "Usuario"
            };
        }

        public (string? username, string? role) GetUserInfoFromToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var username = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "rol")?.Value;

                return (username, role);
            }
            catch
            {
                return (null, null);
            }
        }
    }
}