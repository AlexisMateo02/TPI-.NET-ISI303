using Academia.Entidades;
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
        private List<PersonaDTO> personas;

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
            LoadPersonas();
            Mode = FormMode.Add;
        }

        private async void LoadPersonas()
        {
            try
            {
                listBoxPersona.DataSource = null;
                personas = (await PersonaAPIClient.GetAllAsync()).ToList();
                listBoxPersona.DataSource = personas;
                listBoxPersona.DisplayMember = "NombreCompletoPersona";
                listBoxPersona.ValueMember = "IdPersona";
                listBoxPersona.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (await this.ValidateUsuario())
            {
                try
                {
                    this.Usuario.NombreUsuario = textNombreUsuario.Text;
                    this.Usuario.Habilitado = checkHabilitado.Checked;

                    if (listBoxPersona.SelectedItem != null)
                    {
                        var personaSeleccionada = (PersonaDTO)listBoxPersona.SelectedItem;
                        this.Usuario.IdPersona = personaSeleccionada.IdPersona;
                    }
                    else
                    {
                        this.Usuario.IdPersona = null;
                    }

                    if (this.Mode == FormMode.Update)
                    {
                        if (!string.IsNullOrWhiteSpace(textClave.Text))
                        {
                            this.Usuario.Clave = textClave.Text;
                        }
                        await UsuarioAPIClient.UpdateAsync(this.Usuario);
                    }
                    else
                    {
                        this.Usuario.Clave = textClave.Text;
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
            this.textNombreUsuario.Text = this.Usuario.NombreUsuario;
            this.textClave.Text = "";
            this.checkHabilitado.Checked = this.Usuario.Habilitado;
            this.textFechaAlta.Text = this.Usuario.FechaAlta.ToString("dd/MM/yyyy HH:mm:ss");
            if (this.Usuario.IdPersona.HasValue)
            {
                listBoxPersona.SelectedValue = this.Usuario.IdPersona.Value;
            }
            else
            {
                listBoxPersona.SelectedIndex = -1;
            }
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

            if (string.IsNullOrWhiteSpace(textNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNombreUsuario.Focus();
                isValid = false;
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
            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                int? excludeId = this.Mode == FormMode.Update ? this.Usuario.Id : null;

                bool nombreUsuarioExiste = await UsuarioAPIClient.ExistsNombreUsuarioAsync(textNombreUsuario.Text, excludeId);
                if (nombreUsuarioExiste)
                {
                    MessageBox.Show($"Ya existe un usuario con el nombre '{textNombreUsuario.Text}'.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textNombreUsuario.Focus();
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
            return isValid;
        }
    }
}
