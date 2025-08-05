using Academia.Entidades;
using Newtonsoft.Json;

namespace Academia.Negocio
{
    public class UsuarioControlador
    {
        private const string API_URL = "https://localhost:7099/api/Usuario/";
        private static readonly HttpClient client = new HttpClient();

        public async static Task<Usuarios> GetAll()
        {
            try
            {
                Usuarios usuarios = new Usuarios();
                HttpResponseMessage response = await client.GetAsync(API_URL);

                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                usuarios.ListaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(responseJson);

                return usuarios;
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
                throw new Exception($"Error al eliminar el usuario con ID {id}. Verifique que esté en ejecución la API.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al eliminar el usuario: {ex.Message}", ex);
            }
        }
        public async static Task<bool> Create(Usuario usuario)
        {
            try
            {
                string jsonUsuario = JsonConvert.SerializeObject(usuario);
                StringContent content = new StringContent(jsonUsuario, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(API_URL, content);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al conectar con la API para crear el usuario. Verifique que esté en ejecución.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al crear el usuario: {ex.Message}", ex);
            }
        }
        public async static Task<bool> Update(Usuario usuario)
        {
            try
            {
                string jsonUsuario = JsonConvert.SerializeObject(usuario);
                StringContent content = new StringContent(jsonUsuario, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"{API_URL}{usuario.IdUsuario}", content);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al conectar con la API para actualizar el usuario con ID {usuario.IdUsuario}. Verifique que esté en ejecución.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al actualizar el usuario: {ex.Message}", ex);
            }
        }
    }
}
