using Academia.WindowsForms.Helpers;
using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views.Usuario
{
    public partial class UsuariosForm : Form
    {
        private readonly RoleHelper _roleHelper;
        private readonly string _authToken;
        private bool _isAdmin;
        private int _currentUserId;
        private UsuarioDTO? _currentUserInfo;

        public UsuariosForm()
        {
            InitializeComponent();

            // Obtener token de la sesión
            var (token, _, _) = SessionManager.LoadSession();
            _authToken = token ?? string.Empty;
            _roleHelper = new RoleHelper(_authToken);

            // Verificar permisos y configurar UI
            InitializeByRole();
        }

        private async void InitializeByRole()
        {
            _isAdmin = _roleHelper.IsAdmin();

            if (_isAdmin)
            {
                ConfigurarColumnas();
                ConfigurarBusqueda();
                await GetByCriteriaAndLoadAsync();
                SetupAdminMode();
            }
            else
            {
                await SetupReadOnlyMode();
            }
        }

        private void SetupAdminMode()
        {
            // Mostrar todos los controles de administración
            dgvUsuarios.Visible = true;
            buscarTextBox.Visible = true;
            buttonListar.Visible = true;
            buttonAgregar.Visible = true;
            buttonModificar.Visible = true;
            buttonEliminar.Visible = true;

            // Ocultar panel de información personal
            panelMiInfo.Visible = false;

            this.Text = "Gestión de Usuarios - Administrador";
        }

        private async Task SetupReadOnlyMode()
        {
            // Ocultar controles de administración
            dgvUsuarios.Visible = false;
            buscarTextBox.Visible = false;
            buttonListar.Visible = false;
            buttonAgregar.Visible = false;
            buttonModificar.Visible = false;
            buttonEliminar.Visible = false;

            // Mostrar panel de información personal
            panelMiInfo.Visible = true;

            await LoadCurrentUserInfo();

            this.Text = "Mi Usuario";
        }

        private async Task LoadCurrentUserInfo()
        {
            try
            {
                var (username, _) = _roleHelper.GetUserInfoFromToken(_authToken);

                if (!string.IsNullOrEmpty(username))
                {
                    var allUsuarios = await UsuarioAPIClient.GetAllAsync();
                    _currentUserInfo = allUsuarios.FirstOrDefault(u => u.NombreUsuario == username);

                    if (_currentUserInfo != null)
                    {
                        _currentUserId = _currentUserInfo.Id;
                        DisplayCurrentUserInfo();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cargar la información de tu usuario.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar información del usuario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCurrentUserInfo()
        {
            if (_currentUserInfo == null) return;

            labelUsuarioValue.Text = _currentUserInfo.NombreUsuario;
            labelRolValue.Text = GetRoleDisplayName(_currentUserInfo.Rol);
            labelEstadoValue.Text = _currentUserInfo.Habilitado ? "Activo" : "Inactivo";
            labelEstadoValue.ForeColor = _currentUserInfo.Habilitado ? Color.Green : Color.Red;
            labelFechaAltaValue.Text = _currentUserInfo.FechaAlta.ToString("dd/MM/yyyy");

            if (!string.IsNullOrEmpty(_currentUserInfo.NombreCompletoPersona))
            {
                labelPersonaValue.Text = _currentUserInfo.NombreCompletoPersona;
                labelPersonaValue.Visible = true;
                labelPersona.Visible = true;
            }
            else
            {
                labelPersonaValue.Visible = false;
                labelPersona.Visible = false;
            }

            if (_currentUserInfo.Legajo.HasValue)
            {
                labelLegajoValue.Text = _currentUserInfo.Legajo.ToString();
                labelLegajoValue.Visible = true;
                labelLegajo.Visible = true;
            }
            else
            {
                labelLegajoValue.Visible = false;
                labelLegajo.Visible = false;
            }
        }

        private string GetRoleDisplayName(int rol)
        {
            return rol switch
            {
                1 => "Administrador",
                2 => "Docente",
                3 => "Alumno",
                _ => "Usuario"
            };
        }

        private void ConfigurarColumnas()
        {
            this.dgvUsuarios.AutoGenerateColumns = false;

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 60
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreUsuario",
                HeaderText = "Usuario",
                DataPropertyName = "NombreUsuario",
                Width = 150
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Persona",
                HeaderText = "Persona",
                DataPropertyName = "NombreCompletoPersona",
                Width = 200
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Legajo",
                HeaderText = "Legajo",
                DataPropertyName = "Legajo",
                Width = 80
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Rol",
                HeaderText = "Rol",
                DataPropertyName = "Rol",
                Width = 100
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Habilitado",
                HeaderText = "Activo",
                DataPropertyName = "Habilitado",
                Width = 60
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaAlta",
                HeaderText = "Fecha Alta",
                DataPropertyName = "FechaAlta",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm"
                }
            });

            // Formatear columna de Rol
            this.dgvUsuarios.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dgvUsuarios.Columns["Rol"].Index && e.Value != null)
                {
                    int rol = Convert.ToInt32(e.Value);
                    e.Value = GetRoleDisplayName(rol);
                }
            };
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string texto = this.buscarTextBox.Text.Trim();
            if (texto == "Buscar por nombre de usuario, nombre, apellido o legajo")
            {
                texto = "";
            }
            _ = GetByCriteriaAndLoadAsync(texto);
        }

        private async void EliminarUsuarioSeleccionado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioDTO usuarioExistente = this.SelectedItem();

            if (usuarioExistente == null)
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombreUsuario = usuarioExistente.NombreUsuario;

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el usuario '{nombreUsuario}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await UsuarioAPIClient.DeleteAsync(usuarioExistente.Id);
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await GetByCriteriaAndLoadAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuarioSeleccionado();
        }

        private void CreateUsuario()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UsuarioDetallesForm usuarioDetalles = new UsuarioDetallesForm();
                UsuarioDTO usuarioNuevo = new UsuarioDTO();
                usuarioDetalles.Mode = FormMode.Add;
                usuarioDetalles.Usuario = usuarioNuevo;

                if (usuarioDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = GetByCriteriaAndLoadAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateUsuario();
        }

        private async void EditarUsuarioSeleccionado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioDTO usuarioExistente = this.SelectedItem();

            if (usuarioExistente == null)
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = usuarioExistente.Id;
                UsuarioDetallesForm usuarioDetalles = new UsuarioDetallesForm();
                UsuarioDTO usuarioAModificar = await UsuarioAPIClient.GetAsync(idExistente);
                usuarioDetalles.Mode = FormMode.Update;
                usuarioDetalles.Usuario = usuarioAModificar;

                if (usuarioDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await GetByCriteriaAndLoadAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarUsuarioSeleccionado();
        }

        private UsuarioDTO SelectedItem()
        {
            if (dgvUsuarios.SelectedRows.Count > 0 &&
                dgvUsuarios.SelectedRows[0].DataBoundItem != null)
            {
                return (UsuarioDTO)dgvUsuarios.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

        private async Task GetByCriteriaAndLoadAsync(string texto = "")
        {
            try
            {
                this.dgvUsuarios.DataSource = null;

                IEnumerable<UsuarioDTO> usuarios;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    usuarios = await UsuarioAPIClient.GetAllAsync();
                }
                else
                {
                    usuarios = await UsuarioAPIClient.GetByCriteriaAsync(texto);
                }

                this.dgvUsuarios.DataSource = usuarios;

                if (this.dgvUsuarios.Rows.Count > 0)
                {
                    this.dgvUsuarios.Rows[0].Selected = true;
                    this.buttonEliminar.Enabled = true;
                    this.buttonModificar.Enabled = true;
                }
                else
                {
                    this.buttonEliminar.Enabled = false;
                    this.buttonModificar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de usuarios: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonEliminar.Enabled = false;
                this.buttonModificar.Enabled = false;
            }
        }

        private void ConfigurarBusqueda()
        {
            buscarTextBox.Text = "Buscar por nombre de usuario, nombre, apellido o legajo";
            buscarTextBox.ForeColor = SystemColors.GrayText;
            buscarTextBox.Enter += BuscarTextBox_Enter;
            buscarTextBox.Leave += BuscarTextBox_Leave;
        }

        private void BuscarTextBox_Enter(object sender, EventArgs e)
        {
            if (buscarTextBox.Text == "Buscar por nombre de usuario, nombre, apellido o legajo")
            {
                buscarTextBox.Text = "";
                buscarTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void BuscarTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(buscarTextBox.Text))
            {
                buscarTextBox.Text = "Buscar por nombre de usuario, nombre, apellido o legajo";
                buscarTextBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void buttonCambiarContrasenia_Click_1(object sender, EventArgs e)
        {
            if (_currentUserId == 0)
            {
                MessageBox.Show("No se pudo obtener la información del usuario.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CambiarContraseniaForm cambiarForm = new CambiarContraseniaForm(_currentUserId);

                if (cambiarForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar contraseña: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}