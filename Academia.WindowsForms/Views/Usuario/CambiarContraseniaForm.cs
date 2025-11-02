using APIClients;

namespace Academia.WindowsForms.Views.Usuario
{
    public partial class CambiarContraseniaForm : Form
    {
        private readonly int _usuarioId;
        public CambiarContraseniaForm(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                btnAceptar.Enabled = false;
                btnAceptar.Text = "Cambiando...";

                await UsuarioAPIClient.CambiarContraseniaAsync(
                    _usuarioId,
                    txtClaveActual.Text,
                    txtNuevaClave.Text
                );

                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar contraseña: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAceptar.Enabled = true;
                btnAceptar.Text = "Cambiar Contraseña";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            // Limpiar mensajes de error previos
            errorProvider1.Clear();

            bool isValid = true;

            // Validar Contraseña Actual
            if (string.IsNullOrWhiteSpace(txtClaveActual.Text))
            {
                errorProvider1.SetError(txtClaveActual, "La contraseña actual es requerida");
                isValid = false;
            }

            // Validar Nueva Contraseña
            if (string.IsNullOrWhiteSpace(txtNuevaClave.Text))
            {
                errorProvider1.SetError(txtNuevaClave, "La nueva contraseña es requerida");
                isValid = false;
            }
            else if (txtNuevaClave.Text.Length < 6)
            {
                errorProvider1.SetError(txtNuevaClave, "La nueva contraseña debe tener al menos 6 caracteres");
                isValid = false;
            }

            // Validar Confirmación de Contraseña
            if (string.IsNullOrWhiteSpace(txtConfirmarClave.Text))
            {
                errorProvider1.SetError(txtConfirmarClave, "Debe confirmar la nueva contraseña");
                isValid = false;
            }
            else if (txtNuevaClave.Text != txtConfirmarClave.Text)
            {
                errorProvider1.SetError(txtConfirmarClave, "Las contraseñas no coinciden");
                isValid = false;
            }

            // Validar que la nueva contraseña sea diferente a la actual
            if (!string.IsNullOrWhiteSpace(txtClaveActual.Text) &&
                !string.IsNullOrWhiteSpace(txtNuevaClave.Text) &&
                txtClaveActual.Text == txtNuevaClave.Text)
            {
                errorProvider1.SetError(txtNuevaClave, "La nueva contraseña debe ser diferente a la actual");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Por favor, corrija los errores en el formulario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void checkBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtClaveActual.UseSystemPasswordChar = !checkBoxMostrar.Checked;
            txtNuevaClave.UseSystemPasswordChar = !checkBoxMostrar.Checked;
            txtConfirmarClave.UseSystemPasswordChar = !checkBoxMostrar.Checked;
        }
    }
}
