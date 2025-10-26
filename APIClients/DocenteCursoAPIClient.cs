using DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace APIClients
{
    public class DocenteCursoAPIClient
    {
        private static HttpClient client = new HttpClient();
        static DocenteCursoAPIClient()
        {
            client.BaseAddress = new Uri("http://localhost:5226/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
        public static async Task<DocenteCursoDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("docentecursos/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<DocenteCursoDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener dictado con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener dictado con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener dictado con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<IEnumerable<DocenteCursoDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("docentecursos");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<DocenteCursoDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de dictados. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de dictados: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de dictados: {ex.Message}", ex);
            }
        }
        public async static Task AddAsync(DocenteCursoDTO docenteCurso)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("docentecursos", docenteCurso);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear dictado. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear dictado: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear dictado: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(DocenteCursoDTO docenteCurso)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("docentecursos", docenteCurso);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar dictado con Id {docenteCurso.IdDictado}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar dictado con Id {docenteCurso.IdDictado}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar dictado con Id {docenteCurso.IdDictado}: {ex.Message}", ex);
            }
        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("docentecursos/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar dictado con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar dictado con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar dictado con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<bool> ExistDocenteCursoAsync(int idDocente, int idCurso, int? excludeId = null)
        {
            try
            {
                string url = $"docentecursos/existDocenteCurso?idDocente={idDocente}&idCurso={idCurso}";
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
                    throw new Exception($"Error al verificar dictado duplicado. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al verificar dictado duplicado: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al verificar dictado duplicado: {ex.Message}", ex);
            }
        }
    }
}
