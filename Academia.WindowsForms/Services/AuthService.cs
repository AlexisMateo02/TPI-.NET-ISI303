using DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Academia.WindowsForms.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;

        public AuthService(string baseAddress = "http://localhost:5226/")
        {
            _baseAddress = baseAddress;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("auth/login", request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return loginResponse;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el login: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Método para verificar si el token es válido
        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token)) return false;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                return jwtToken.ValidTo > DateTime.UtcNow;
            }
            catch
            {
                return false;
            }
        }
    }
}
