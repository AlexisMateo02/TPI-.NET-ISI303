using Academia.WindowsForms.Helpers;
using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views.Especialidad
{
    public partial class EspecialidadesForm : Form
    {
        private readonly RoleHelper _roleHelper;
        private readonly string _authToken;
        private bool _isAdmin;
        public EspecialidadesForm()
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
            ConfigurarColumnas();
            await LoadEspecialidadesAsync();
            ConfigureByRole();
        }

        private void ConfigureByRole()
        {
            if (_isAdmin)
            {
                // Admin: CRUD completo
                buttonAgregar.Visible = true;
                buttonModificar.Visible = true;
                buttonEliminar.Visible = true;
                buttonListar.Visible = true;
                this.Text = "Gestión de Especialidades - Administrador";
                this.Height = 394;
            }
            else
            {
                // Docente/Alumno: Solo lectura
                buttonAgregar.Visible = false;
                buttonModificar.Visible = false;
                buttonEliminar.Visible = false;
                buttonListar.Visible = false;
                this.Text = "Especialidades";
                this.Height = 345;
            }
        }

        private void ConfigurarColumnas()
        {
            this.dgvEspecialidades.AutoGenerateColumns = false;
            this.dgvEspecialidades.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvEspecialidades.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 80
            });

            this.dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });
        }

        private async Task LoadEspecialidadesAsync()
        {
            try
            {
                this.dgvEspecialidades.DataSource = null;

                IEnumerable<EspecialidadDTO> especialidades = await EspecialidadAPIClient.GetAllAsync();

                this.dgvEspecialidades.DataSource = especialidades;
                this.dgvEspecialidades.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvEspecialidades.Rows.Count > 0)
                {
                    this.dgvEspecialidades.Rows[0].Selected = true;
                    if (_isAdmin)
                    {
                        this.buttonEliminar.Enabled = true;
                        this.buttonModificar.Enabled = true;
                    }
                }
                else
                {
                    this.buttonEliminar.Enabled = false;
                    this.buttonModificar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de especialidades: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (_isAdmin)
                {
                    this.buttonEliminar.Enabled = false;
                    this.buttonModificar.Enabled = false;
                }
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            _ = LoadEspecialidadesAsync();
        }

        private async void EliminarEspecialidadSeleccionada()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EspecialidadDTO especialidadExistente = this.SelectedItem();

            if (especialidadExistente == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la especialidad?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await EspecialidadAPIClient.DeleteAsync(especialidadExistente.Id);
                    MessageBox.Show("Especialidad eliminada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEspecialidadesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            EliminarEspecialidadSeleccionada();
        }

        private void CreateEspecialidad()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                EspecialidadDetallesForm especialidadDetalles = new EspecialidadDetallesForm();
                EspecialidadDTO especialidadNueva = new EspecialidadDTO();
                especialidadDetalles.Mode = FormMode.Add;
                especialidadDetalles.Especialidad = especialidadNueva;

                if (especialidadDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Especialidad creada exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = LoadEspecialidadesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear especialidad: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateEspecialidad();
        }

        private async void EditarEspecialidadSeleccionada()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EspecialidadDTO especialidadExistente = this.SelectedItem();

            if (especialidadExistente == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = especialidadExistente.Id;
                EspecialidadDetallesForm especialidadDetalles = new EspecialidadDetallesForm();
                EspecialidadDTO especialidadAModificar = await EspecialidadAPIClient.GetAsync(idExistente);
                especialidadDetalles.Mode = FormMode.Update;
                especialidadDetalles.Especialidad = especialidadAModificar;

                if (especialidadDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Especialidad actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEspecialidadesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar especialidad: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarEspecialidadSeleccionada();
        }

        private EspecialidadDTO SelectedItem()
        {
            if (dgvEspecialidades.SelectedRows.Count > 0 &&
                dgvEspecialidades.SelectedRows[0].DataBoundItem != null)
            {
                return (EspecialidadDTO)dgvEspecialidades.SelectedRows[0].DataBoundItem;
            }
            return null;
        }
    }
}
