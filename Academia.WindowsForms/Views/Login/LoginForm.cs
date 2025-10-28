using Academia.WindowsForms.Helpers;
using Academia.WindowsForms.Services;
using DTOs;

namespace Academia.WindowsForms.Views.Login
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;

        public string? AuthToken { get; private set; }
        public string? Username { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();

            // Intentar cargar sesión existente
            TryLoadExistingSession();
        }

        private void TryLoadExistingSession()
        {
            var (token, expiry, username) = SessionManager.LoadSession();
            if (!string.IsNullOrEmpty(token) && _authService.IsTokenValid(token))
            {
                AuthToken = token;
                Username = username;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            _ = PerformLogin();
        }

        private async Task PerformLogin()
        {
            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Iniciando sesión...";

                var request = new LoginRequest
                {
                    NombreUsuario = txtUsername.Text.Trim(),
                    Clave = txtPassword.Text
                };

                // Validaciones básicas
                if (string.IsNullOrEmpty(request.NombreUsuario) ||
                    string.IsNullOrEmpty(request.Clave))
                {
                    MessageBox.Show("Por favor, complete todos los campos", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var loginResponse = await _authService.LoginAsync(request);

                if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token))
                {
                    // Guardar sesión
                    SessionManager.SaveSession(loginResponse);

                    AuthToken = loginResponse.Token;
                    Username = loginResponse.NombreUsuario;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error de autenticación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Iniciar Sesión";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                _ = PerformLogin();
            }
        }
    }
}
