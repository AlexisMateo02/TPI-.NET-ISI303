using Academia.Entidades;
using Newtonsoft.Json;

namespace Academia.Negocio
{
    public class EspecialidadControlador
    {
        private const string API_URL = "https://localhost:7099/api/Especialidad/";
        private static readonly HttpClient client = new HttpClient();

        public async static Task<Especialidades> GetAll()
        {
            try
            {
                Especialidades especialidades = new Especialidades();
                HttpResponseMessage response = await client.GetAsync(API_URL);

                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                especialidades.ListaEspecialidades = JsonConvert.DeserializeObject<List<Especialidad>>(responseJson);

                return especialidades;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al conectar con la API. Verifique que esté en ejecución.", ex);
            }
        }

        public async static Task<bool> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{API_URL}{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al eliminar la especialidad con ID {id}. Verifique que esté en ejecución la API.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al eliminar la especialidad: {ex.Message}", ex);
            }
        }
        public async static Task<bool> Create(Especialidad especialidad)
        {
            try
            {
                string jsonEspecialidad = JsonConvert.SerializeObject(especialidad);
                StringContent content = new StringContent(jsonEspecialidad, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(API_URL, content);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al conectar con la API para crear la especialidad. Verifique que esté en ejecución.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al crear la especialidad: {ex.Message}", ex);
            }
        }
        public async static Task<bool> Update(Especialidad especialidad)
        {
            try
            {
                string jsonEspecialidad = JsonConvert.SerializeObject(especialidad);
                StringContent content = new StringContent(jsonEspecialidad, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"{API_URL}{especialidad.IdEspecialidad}", content);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al conectar con la API para actualizar la especialidad con ID {especialidad.IdEspecialidad}. Verifique que esté en ejecución.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al actualizar la especialidad: {ex.Message}", ex);
            }
        }
    }
}
