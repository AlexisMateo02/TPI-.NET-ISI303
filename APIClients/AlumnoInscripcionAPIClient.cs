using DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace APIClients
{
    public class AlumnoInscripcionAPIClient
    {
        private static HttpClient client = new HttpClient();
        static AlumnoInscripcionAPIClient()
        {
            client.BaseAddress = new Uri("http://localhost:5226/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
        public static async Task<AlumnoInscripcionDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("alumnoinscripciones/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AlumnoInscripcionDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener inscripción con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener inscripción con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener inscripción con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("alumnoinscripciones");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AlumnoInscripcionDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de inscripciones. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de inscripciones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de inscripciones: {ex.Message}", ex);
            }
        }
        public async static Task AddAsync(AlumnoInscripcionDTO alumnoInscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("alumnoinscripciones", alumnoInscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear inscripción. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear inscripción: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear inscripción: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(AlumnoInscripcionDTO alumnoInscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("alumnoinscripciones", alumnoInscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar inscripción con Id {alumnoInscripcion.IdInscripcion}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar inscripción con Id {alumnoInscripcion.IdInscripcion}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar inscripción con Id {alumnoInscripcion.IdInscripcion}: {ex.Message}", ex);
            }
        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("alumnoinscripciones/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar inscripción con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar inscripción con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar inscripción con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<bool> ExistAlumnoCursoAsync(int idAlumno, int idCurso, int? excludeId = null)
        {
            try
            {
                string url = $"alumnoinscripciones/existAlumnoCurso?idAlumno={idAlumno}&idCurso={idCurso}";
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
                    throw new Exception($"Error al verificar inscripción duplicada. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al verificar inscripción duplicada: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al verificar inscripción duplicada: {ex.Message}", ex);
            }
        }
    }
}
