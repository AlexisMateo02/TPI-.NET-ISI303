using APIClients;
using BlazorServer.Providers;
using DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace BlazorServer.Services
{
    public class AuthClientService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ProtectedLocalStorage _protectedLocalStorage;

        public AuthClientService(HttpClient httpClient,
                               AuthenticationStateProvider authenticationStateProvider,
                               ProtectedLocalStorage protectedLocalStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _protectedLocalStorage = protectedLocalStorage;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("auth/login", request);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

                    if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token))
                    {
                        // Guardar el token en localStorage
                        await _protectedLocalStorage.SetAsync("authToken", loginResponse.Token);
                        await _protectedLocalStorage.SetAsync("username", loginResponse.NombreUsuario);
                        await _protectedLocalStorage.SetAsync("tokenExpiry", loginResponse.ExpiresAt);

                        // Notificar al proveedor de autenticación que el estado cambió
                        await ((CustomAuthenticationStateProvider)_authenticationStateProvider)
                            .MarkUserAsAuthenticated(loginResponse.Token, loginResponse.NombreUsuario);

                        return loginResponse;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante el login: {ex.Message}");
                return null;
            }
        }

        public async Task LogoutAsync()
        {
            // Eliminar el token
            await _protectedLocalStorage.DeleteAsync("authToken");
            await _protectedLocalStorage.DeleteAsync("username");
            await _protectedLocalStorage.DeleteAsync("tokenExpiry");

            // Notificar al proveedor de autenticación que el usuario cerró sesión
            await ((CustomAuthenticationStateProvider)_authenticationStateProvider)
                .MarkUserAsLoggedOut();
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                var tokenResult = await _protectedLocalStorage.GetAsync<string>("authToken");
                return tokenResult.Success && !string.IsNullOrEmpty(tokenResult.Value);
            }
            catch
            {
                return false;
            }
        }

        public async Task<string?> GetTokenAsync()
        {
            try
            {
                var tokenResult = await _protectedLocalStorage.GetAsync<string>("authToken");
                return tokenResult.Success ? tokenResult.Value : null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> GetUsernameAsync()
        {
            try
            {
                var usernameResult = await _protectedLocalStorage.GetAsync<string>("username");
                return usernameResult.Success ? usernameResult.Value : null;
            }
            catch
            {
                return null;
            }
        }
    }
}