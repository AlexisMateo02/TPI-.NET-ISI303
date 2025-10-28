using Academia.WindowsForms.Helpers;
using Academia.WindowsForms.Services;
using Academia.WindowsForms.Views.Login;
using Academia.WindowsForms.Views.Menu;

namespace Academia.WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Intentar cargar sesión existente
            var (token, expiry, username) = SessionManager.LoadSession();

            // Verificar si hay una sesión válida
            if (!string.IsNullOrEmpty(token))
            {
                var authService = new AuthService();
                if (authService.IsTokenValid(token))
                {
                    // Sesión válida, ir directamente al menú
                    Application.Run(new MenuForm(token, username ?? "Usuario"));
                    return;
                }
                else
                {
                    // Token expirado, limpiar sesión
                    SessionManager.ClearSession();
                }
            }

            // No hay sesión válida, mostrar login
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK &&
                    !string.IsNullOrEmpty(loginForm.AuthToken))
                {
                    Application.Run(new MenuForm(loginForm.AuthToken, loginForm.Username ?? "Usuario"));
                }
            }
        }
    }
}