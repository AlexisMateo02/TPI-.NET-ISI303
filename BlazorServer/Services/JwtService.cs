using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class JwtService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtService()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public bool IsTokenExpired(string token)
        {
            try
            {
                var jwtToken = _tokenHandler.ReadJwtToken(token);
                return jwtToken.ValidTo <= DateTime.UtcNow;
            }
            catch
            {
                return true;
            }
        }

        public Rol GetRoleFromToken(string token)
        {
            try
            {
                var jwtToken = _tokenHandler.ReadJwtToken(token);
                var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "rol");

                if (roleClaim != null)
                {
                    return RolExtensions.FromString(roleClaim.Value);
                }

                return Rol.Alumno; // Default
            }
            catch
            {
                return Rol.Alumno;
            }
        }

        public Rol GetRoleFromPrincipal(ClaimsPrincipal user)
        {
            try
            {
                // Primero intentar obtener del token
                var tokenClaim = user.FindFirst("token");
                if (tokenClaim != null)
                {
                    return GetRoleFromToken(tokenClaim.Value);
                }

                // Si no, buscar en claims directos
                var roleClaim = user.FindFirst("rol")
                    ?? user.FindFirst("role")
                    ?? user.FindFirst(ClaimTypes.Role);

                if (roleClaim != null)
                {
                    return RolExtensions.FromString(roleClaim.Value);
                }

                return Rol.Alumno;
            }
            catch
            {
                return Rol.Alumno;
            }
        }

        public string GetUsernameFromToken(string token)
        {
            try
            {
                var jwtToken = _tokenHandler.ReadJwtToken(token);
                return jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public int? GetUserIdFromToken(string token)
        {
            try
            {
                var jwtToken = _tokenHandler.ReadJwtToken(token);
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}