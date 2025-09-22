using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public enum FormMode
    {
        Add,
        Update
    }
    public partial class UsuarioDetallesForm : Form
    {
        private UsuarioDTO usuario;
        private FormMode mode;

        public UsuarioDTO Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                this.SetUsuario();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public UsuarioDetallesForm()
        {
            InitializeComponent();
            Mode = FormMode.Add;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (await this.ValidateUsuario())
            {
                try
                {
                    this.Usuario.Nombre = textNombre.Text;
                    this.Usuario.Clave = textClave.Text;
                    this.Usuario.Habilitado = checkHabilitado.Checked;

                    if (this.Mode == FormMode.Update)
                    {
                        if (!string.IsNullOrWhiteSpace(textClave.Text))
                        {
                            this.Usuario.Clave = PasswordHelper.HashPassword(textClave.Text);
                        }
                        await UsuarioAPIClient.UpdateAsync(this.Usuario);
                    }
                    else
                    {
                        this.Usuario.Clave = PasswordHelper.HashPassword(textClave.Text);
                        this.Usuario.FechaAlta = DateTime.Now;
                        await UsuarioAPIClient.AddAsync(this.Usuario);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetUsuario()
        {
            this.textId.Text = this.Usuario.Id.ToString();
            this.textNombre.Text = this.Usuario.Nombre;
            this.textClave.Text = "";
            this.checkHabilitado.Checked = this.Usuario.Habilitado;
            this.textFechaAlta.Text = this.Usuario.FechaAlta.ToString();
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                textId.Visible = false;
                checkHabilitado.Visible = false;
                fechaAltaLabel.Visible = false;
                textFechaAlta.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                textId.Visible = true;
                textId.ReadOnly = true;
                checkHabilitado.Visible = true;
                fechaAltaLabel.Visible = true;
                textFechaAlta.Visible = true;
                textFechaAlta.ReadOnly = true;
            }
        }

        private async Task<bool> ValidateUsuario()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNombre.Focus();
                isValid = false;
            }
            if (this.Mode == FormMode.Add || textNombre.Text != this.Usuario.Nombre)
            {
                try
                {
                    this.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    int? excludeId = this.Mode == FormMode.Update ? this.Usuario.Id : null;
                    bool nombreExiste = await UsuarioAPIClient.ExistsNombreAsync(textNombre.Text, excludeId);

                    if (nombreExiste)
                    {
                        MessageBox.Show($"Ya existe un usuario con el nombre '{textNombre.Text}'.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textNombre.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al validar nombre de usuario: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
            if (this.Mode == FormMode.Add && string.IsNullOrWhiteSpace(textClave.Text))
            {
                MessageBox.Show("La clave es obligatoria.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textClave.Focus();
                isValid = false;
            }
            if (textClave.Text.Length < 6 && !string.IsNullOrWhiteSpace(textClave.Text))
            {
                MessageBox.Show("La clave debe tener al menos 6 caracteres.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textClave.Focus();
                isValid = false;
            }
            return isValid;
        }
    }
}
