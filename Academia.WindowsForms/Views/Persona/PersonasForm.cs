using Academia.WindowsForms.Helpers;
using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views.Persona
{
    public partial class PersonasForm : Form
    {
        private readonly RoleHelper _roleHelper;
        private readonly string _authToken;
        private bool _isAdmin;
        private PersonaDTO? _personaActual;
        public PersonasForm()
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
                await LoadPersonasAsync(0);
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
            dgvPersonas.Visible = true;
            buscarTextBox.Visible = true;
            buttonListar.Visible = true;
            buttonListar2.Visible = true;
            buttonListarAlumnos.Visible = true;
            buttonListarDocentes.Visible = true;
            buttonAgregar.Visible = true;
            buttonModificar.Visible = true;
            buttonEliminar.Visible = true;

            // Ocultar panel de información personal
            panelMiInfo.Visible = false;

            this.Text = "Gestión de Personas - Administrador";
        }

        private async Task SetupReadOnlyMode()
        {
            // Ocultar controles de administración
            dgvPersonas.Visible = false;
            buscarTextBox.Visible = false;
            buttonListar.Visible = false;
            buttonListar2.Visible = false;
            buttonListarAlumnos.Visible = false;
            buttonListarDocentes.Visible = false;
            buttonAgregar.Visible = false;
            buttonModificar.Visible = false;
            buttonEliminar.Visible = false;

            // Mostrar panel de información personal
            panelMiInfo.Visible = true;

            await LoadCurrentPersonaInfo();

            this.Text = "Mis Datos Personales";
        }

        private async Task LoadCurrentPersonaInfo()
        {
            try
            {
                var (username, _) = _roleHelper.GetUserInfoFromToken(_authToken);

                if (!string.IsNullOrEmpty(username))
                {
                    var allUsuarios = await UsuarioAPIClient.GetAllAsync();
                    var usuarioActual = allUsuarios.FirstOrDefault(u => u.NombreUsuario == username);

                    if (usuarioActual != null && usuarioActual.IdPersona.HasValue)
                    {
                        _personaActual = await PersonaAPIClient.GetAsync(usuarioActual.IdPersona.Value);

                        if (_personaActual != null)
                        {
                            DisplayCurrentPersonaInfo();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron tus datos personales.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tu usuario no tiene una persona asociada.",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar información personal: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCurrentPersonaInfo()
        {
            if (_personaActual == null) return;

            labelLegajoValue.Text = _personaActual.Legajo.ToString();
            labelEmailValue.Text = _personaActual.Email;
            labelDireccionValue.Text = _personaActual.Direccion;
            labelTelefonoValue.Text = _personaActual.Telefono;
            labelPlanValue.Text = _personaActual.DescripcionPlan ?? "-";
            labelEspecialidadValue.Text = _personaActual.DescripcionEspecialidad ?? "-";
            labelTipoPersonaValue.Text = _personaActual.TipoPersonaDescripcion;

            labelTitulo.Text = $"Datos Personales de {_personaActual.NombreCompletoPersona}";
        }

        private void ConfigurarColumnas()
        {
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvPersonas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdPersona",
                HeaderText = "ID",
                DataPropertyName = "IdPersona",
                Width = 80
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Legajo",
                HeaderText = "Legajo",
                DataPropertyName = "Legajo",
                Width = 80
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 200
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Apellido",
                HeaderText = "Apellido",
                DataPropertyName = "Apellido",
                Width = 200
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaNacimiento",
                HeaderText = "Fecha de Nacimiento",
                DataPropertyName = "FechaNacimiento",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 100
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Direccion",
                HeaderText = "Dirección",
                DataPropertyName = "Direccion",
                Width = 200
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoPersona",
                HeaderText = "Tipo",
                DataPropertyName = "TipoPersonaDescripcion",
                Width = 100
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionPlan",
                HeaderText = "Plan",
                DataPropertyName = "DescripcionPlan",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionEspecialidad",
                HeaderText = "Especialidad",
                DataPropertyName = "DescripcionEspecialidad",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });
        }

        private async Task LoadPersonasAsync(int tipoLoad)
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.dgvPersonas.DataSource = null;

                IEnumerable<PersonaDTO> personas;
                if (tipoLoad == 1)
                {
                    personas = await PersonaAPIClient.GetAlumnosAsync();
                }
                else if (tipoLoad == 2)
                {
                    personas = await PersonaAPIClient.GetDocentesAsync();
                }
                else
                {
                    personas = await PersonaAPIClient.GetAllAsync();
                }

                var planes = await PlanAPIClient.GetAllAsync();
                var especialidades = await EspecialidadAPIClient.GetAllAsync();

                foreach (var persona in personas)
                {
                    var plan = planes.FirstOrDefault(p => p.IdPlan == persona.IdPlan);
                    if (plan != null)
                    {
                        persona.DescripcionPlan = plan.Descripcion;
                        var esp = especialidades.FirstOrDefault(e => e.Id == plan.IdEspecialidad);
                        if (esp != null)
                        {
                            persona.DescripcionEspecialidad = esp.Descripcion;
                        }
                    }
                }

                this.dgvPersonas.DataSource = personas;
                this.dgvPersonas.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvPersonas.Rows.Count > 0)
                {
                    this.dgvPersonas.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de personas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonEliminar.Enabled = false;
                this.buttonModificar.Enabled = false;
            }
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
            if (string.IsNullOrWhiteSpace(texto) || texto == "Buscar por nombre, apellido o legajo...")
            {
                _ = LoadPersonasAsync(0);
            }
            else
            {
                _ = BuscarPersonasAsync(texto);
            }
        }

        private async Task BuscarPersonasAsync(string texto)
        {
            try
            {
                this.dgvPersonas.DataSource = null;
                var personas = await PersonaAPIClient.GetByCriteriaAsync(texto);

                var planes = await PlanAPIClient.GetAllAsync();
                var especialidades = await EspecialidadAPIClient.GetAllAsync();

                foreach (var persona in personas)
                {
                    var plan = planes.FirstOrDefault(p => p.IdPlan == persona.IdPlan);
                    if (plan != null)
                    {
                        persona.DescripcionPlan = plan.Descripcion;
                        var esp = especialidades.FirstOrDefault(e => e.Id == plan.IdEspecialidad);
                        if (esp != null)
                        {
                            persona.DescripcionEspecialidad = esp.Descripcion;
                        }
                    }
                }

                this.dgvPersonas.DataSource = personas;

                if (this.dgvPersonas.Rows.Count > 0)
                {
                    this.dgvPersonas.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al buscar personas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListar2_Click(object sender, EventArgs e)
        {
            _ = LoadPersonasAsync(0);
        }

        private void buttonListarAlumnos_Click(object sender, EventArgs e)
        {
            _ = LoadPersonasAsync(1);
        }

        private void buttonListarDocentes_Click(object sender, EventArgs e)
        {
            _ = LoadPersonasAsync(2);
        }

        private void CreatePersona()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PersonaDetallesForm personaDetalles = new PersonaDetallesForm();
                PersonaDTO personaNueva = new PersonaDTO();
                personaDetalles.Mode = FormMode.Add;
                personaDetalles.Persona = personaNueva;

                if (personaDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Persona creada exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = LoadPersonasAsync(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear persona: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreatePersona();
        }

        private async void EditarPersonaSeleccionada()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PersonaDTO personaExistente = this.SelectedItem();

            if (personaExistente == null)
            {
                MessageBox.Show("Debe seleccionar una persona de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = personaExistente.IdPersona;
                PersonaDetallesForm personaDetalles = new PersonaDetallesForm();
                PersonaDTO personaAModificar = await PersonaAPIClient.GetAsync(idExistente);
                personaDetalles.Mode = FormMode.Update;
                personaDetalles.Persona = personaAModificar;

                if (personaDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Persona actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPersonasAsync(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar persona: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarPersonaSeleccionada();
        }

        private async void EliminarPersonaSeleccionada()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PersonaDTO personaExistente = this.SelectedItem();

            if (personaExistente == null)
            {
                MessageBox.Show("Debe seleccionar una persona de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar a {personaExistente.NombreCompletoPersona}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await PersonaAPIClient.DeleteAsync(personaExistente.IdPersona);
                    MessageBox.Show("Persona eliminada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPersonasAsync(0);
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
            EliminarPersonaSeleccionada();
        }

        private PersonaDTO SelectedItem()
        {
            if (dgvPersonas.SelectedRows.Count > 0 &&
                dgvPersonas.SelectedRows[0].DataBoundItem != null)
            {
                return (PersonaDTO)dgvPersonas.SelectedRows[0].DataBoundItem;
            }
            return null;
        }
    }
}
