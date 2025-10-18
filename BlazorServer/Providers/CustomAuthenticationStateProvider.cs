using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace BlazorServer.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedLocalStorage _protectedLocalStorage;

        public CustomAuthenticationStateProvider(ProtectedLocalStorage protectedLocalStorage)
        {
            _protectedLocalStorage = protectedLocalStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var tokenResult = await _protectedLocalStorage.GetAsync<string>("authToken");
                var usernameResult = await _protectedLocalStorage.GetAsync<string>("username");

                if (tokenResult.Success && !string.IsNullOrEmpty(tokenResult.Value))
                {
                    var token = tokenResult.Value;
                    var username = usernameResult.Success ? usernameResult.Value : string.Empty;

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username ?? string.Empty),
                        new Claim("token", token)
                    };

                    // var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                    // claims.AddRange(jwtToken.Claims);

                    var identity = new ClaimsIdentity(claims, "jwt");
                    var user = new ClaimsPrincipal(identity);
                    return new AuthenticationState(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting auth state: {ex.Message}");
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async Task MarkUserAsAuthenticated(string token, string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("token", token)
            };

            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
