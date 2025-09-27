using DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace APIClients
{
    public class PlanAPIClient
    {
        private static HttpClient client = new HttpClient();
        static PlanAPIClient()
        {
            client.BaseAddress = new Uri("http://localhost:5226/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
        public static async Task<PlanDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("planes/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PlanDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener plan con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener plan con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener plan con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<IEnumerable<PlanDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("planes");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<PlanDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de planes. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de planes: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de planes: {ex.Message}", ex);
            }
        }
        public async static Task AddAsync(PlanDTO plan)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("planes", plan);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear plan. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear plan: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear plan: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(PlanDTO plan)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("planes", plan);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar plan con Id {plan.IdPlan}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar plan con Id {plan.IdPlan}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar plan con Id {plan.IdPlan}: {ex.Message}", ex);
            }
        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("planes/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar plan con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar plan con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar plan con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<bool> ExistsDescripcionInEspecialidadAsync(string descripcion, int idEspecialidad, int? excludeId = null)
        {
            try
            {
                string url = $"planes/existsDescripcion?descripcion={Uri.EscapeDataString(descripcion)}&idEspecialidad={idEspecialidad}";
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
                    throw new Exception($"Error al verificar descripción duplicada. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al verificar descripción duplicada: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al verificar descripción duplicada: {ex.Message}", ex);
            }
        }
    }
}
