using DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace APIClients
{
    public class PersonaAPIClient
    {
        private static HttpClient client = new HttpClient();
        static PersonaAPIClient()
        {
            client.BaseAddress = new Uri("http://localhost:5226/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public static async Task<PersonaDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("personas/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonaDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener persona con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener persona con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener persona con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<PersonaDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("personas");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<PersonaDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de personas. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de personas: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de personas: {ex.Message}", ex);
            }
        }

        public async static Task AddAsync(PersonaDTO persona)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("personas", persona);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear persona. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear persona: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear persona: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(PersonaDTO persona)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("personas", persona);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar persona con Id {persona.IdPersona}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar persona con Id {persona.IdPersona}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar persona con Id {persona.IdPersona}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("personas/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar persona con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar persona con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar persona con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<bool> ExistsEmailAsync(string email, int? excludeId = null)
        {
            try
            {
                string url = $"personas/existsEmail?email={Uri.EscapeDataString(email)}";
                if (excludeId.HasValue)
                {
                    url += $"&excludeId={excludeId.Value}";
                }

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al verificar email duplicado. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al verificar email duplicado: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al verificar email duplicado: {ex.Message}", ex);
            }
        }

        public static async Task<bool> ExistsLegajoAsync(int legajo, int? excludeId = null)
        {
            try
            {
                string url = $"personas/existsLegajo?legajo={legajo}";
                if (excludeId.HasValue)
                {
                    url += $"&excludeId={excludeId.Value}";
                }

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al verificar legajo duplicado. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al verificar legajo duplicado: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al verificar legajo duplicado: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<PersonaDTO>> GetAlumnosAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("personas/alumnos");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<PersonaDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener alumnos. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener alumnos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener alumnos: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<PersonaDTO>> GetDocentesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("personas/docentes");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<PersonaDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener docentes. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener docentes: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener docentes: {ex.Message}", ex);
            }
        }
    }
}
