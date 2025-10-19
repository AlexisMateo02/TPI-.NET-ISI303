using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorServer.Helpers
{
    public class RoleHelper
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public RoleHelper(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<string> GetCurrentUserRoleAsync()
        {
            try
            {
                var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;

                if (user.Identity?.IsAuthenticated == true)
                {
                    return GetUserRoleFromPrincipal(user);
                }

                return "3"; // Default: Alumno
            }
            catch
            {
                return "3";
            }
        }

        public async Task<bool> IsAdminAsync()
        {
            var role = await GetCurrentUserRoleAsync();
            return role == "1";
        }

        public async Task<bool> IsDocenteAsync()
        {
            var role = await GetCurrentUserRoleAsync();
            return role == "2";
        }

        public async Task<bool> IsAlumnoAsync()
        {
            var role = await GetCurrentUserRoleAsync();
            return role == "3";
        }

        public async Task<bool> IsAdminOrDocenteAsync()
        {
            var role = await GetCurrentUserRoleAsync();
            return role == "1" || role == "2";
        }

        private string GetUserRoleFromPrincipal(ClaimsPrincipal user)
        {
            try
            {
                // Intentar obtener del token JWT
                var tokenClaim = user.FindFirst("token");
                if (tokenClaim != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenClaim.Value);
                    var roleClaim = token.Claims.FirstOrDefault(c => c.Type == "rol");
                    if (roleClaim != null) return roleClaim.Value;
                }

                // Intentar obtener de claims directos
                var directRoleClaim = user.FindFirst("rol")
                    ?? user.FindFirst("role")
                    ?? user.FindFirst(ClaimTypes.Role);

                if (directRoleClaim != null) return directRoleClaim.Value;

                return "3"; // Default: Alumno
            }
            catch
            {
                return "3";
            }
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
    }
}

