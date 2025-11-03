using Academia.WindowsForms.Helpers;
using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views.DocenteCurso
{
    public partial class DocenteCursosForm : Form
    {
        private readonly RoleHelper _roleHelper;
        private readonly string _authToken;
        private bool _isAdmin;
        private bool _isDocente;
        private int _currentUserId;
        public DocenteCursosForm()
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
            _isDocente = _roleHelper.IsDocente();

            ConfigurarColumnas();

            if (_isDocente && !_isAdmin)
            {
                await GetCurrentUserId();
            }

            await LoadDocenteCursosAsync();
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
                this.Text = "Gestión de Dictados - Administrador";
                this.Height = 493;
            }
            else if (_isDocente)
            {
                // Docente: Solo lectura de sus propios dictados
                buttonAgregar.Visible = false;
                buttonModificar.Visible = false;
                buttonEliminar.Visible = false;
                buttonListar.Visible = false;
                this.Text = "Mis Dictados";
                this.Height = 444;
            }
            else
            {
                // Alumno: Sin acceso
                MessageBox.Show("No tiene permisos para acceder a esta sección.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private async Task GetCurrentUserId()
        {
            try
            {
                var (username, _) = _roleHelper.GetUserInfoFromToken(_authToken);

                if (!string.IsNullOrEmpty(username))
                {
                    var usuarios = await UsuarioAPIClient.GetAllAsync();
                    var usuario = usuarios?.FirstOrDefault(u =>
                        u.NombreUsuario.Equals(username, StringComparison.OrdinalIgnoreCase));

                    if (usuario != null && usuario.IdPersona.HasValue)
                    {
                        _currentUserId = usuario.IdPersona.Value;

                        // Verificar que sea un docente
                        var persona = await PersonaAPIClient.GetAsync(_currentUserId);
                        if (persona != null && persona.TipoPersona != 2)
                        {
                            MessageBox.Show("Tu usuario no tiene permisos de docente.",
                                "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _currentUserId = 0;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener información del usuario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            this.dgvDocenteCursos.AutoGenerateColumns = false;
            this.dgvDocenteCursos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDocenteCursos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvDocenteCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdDictado",
                HeaderText = "Id",
                DataPropertyName = "IdDictado",
                Width = 60
            });

            this.dgvDocenteCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cargo",
                HeaderText = "Cargo",
                DataPropertyName = "Cargo",
                Width = 100
            });

            if (_isAdmin)
            {
                this.dgvDocenteCursos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NombreCompletoPersona",
                    HeaderText = "Docente",
                    DataPropertyName = "NombreCompletoPersona",
                    Width = 200
                });

                this.dgvDocenteCursos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Legajo",
                    HeaderText = "Legajo",
                    DataPropertyName = "Legajo",
                    Width = 80
                });
            }

            this.dgvDocenteCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnioCalendario",
                HeaderText = "Año",
                DataPropertyName = "AnioCalendario",
                Width = 80
            });

            this.dgvDocenteCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionComision",
                HeaderText = "Comisión",
                DataPropertyName = "DescripcionComision",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });

            this.dgvDocenteCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionMateria",
                HeaderText = "Materia",
                DataPropertyName = "DescripcionMateria",
                Width = 300,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });
        }

        private async Task LoadDocenteCursosAsync()
        {
            try
            {
                this.dgvDocenteCursos.DataSource = null;

                var todosDictados = await DocenteCursoAPIClient.GetAllAsync();

                IEnumerable<DocenteCursoDTO> dictados;

                if (_isDocente && !_isAdmin && _currentUserId > 0)
                {
                    // Filtrar solo los dictados del docente actual
                    dictados = todosDictados.Where(d => d.IdDocente == _currentUserId);
                }
                else
                {
                    // Admin ve todos los dictados
                    dictados = todosDictados;
                }

                this.dgvDocenteCursos.DataSource = dictados.ToList();
                this.dgvDocenteCursos.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvDocenteCursos.Rows.Count > 0)
                {
                    this.dgvDocenteCursos.Rows[0].Selected = true;

                    if (_isAdmin)
                    {
                        this.buttonEliminar.Enabled = true;
                        this.buttonModificar.Enabled = true;
                    }
                }
                else
                {
                    if (_isAdmin)
                    {
                        this.buttonEliminar.Enabled = false;
                        this.buttonModificar.Enabled = false;
                    }

                    if (_isDocente && !_isAdmin)
                    {
                        MessageBox.Show("No tienes dictados asignados.",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de dictados: {ex.Message}", "Error",
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
            _ = LoadDocenteCursosAsync();
        }

        private async void EliminarDictadoSeleccionado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocenteCursoDTO dictadoExistente = this.SelectedItem();

            if (dictadoExistente == null)
            {
                MessageBox.Show("Debe seleccionar un dictado de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el dictado de '{dictadoExistente.NombreCompletoPersona}' en '{dictadoExistente.DescripcionMateria}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await DocenteCursoAPIClient.DeleteAsync(dictadoExistente.IdDictado);
                    MessageBox.Show("Dictado eliminado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDocenteCursosAsync();
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
            EliminarDictadoSeleccionado();
        }

        private void CreateDictado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DocenteCursoDetallesForm dictadoDetalles = new DocenteCursoDetallesForm();
                DocenteCursoDTO dictadoNuevo = new DocenteCursoDTO();
                dictadoDetalles.Mode = FormMode.Add;
                dictadoDetalles.DocenteCurso = dictadoNuevo;

                if (dictadoDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Dictado creado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = LoadDocenteCursosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear dictado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateDictado();
        }

        private async void EditarDictadoSeleccionado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocenteCursoDTO dictadoExistente = this.SelectedItem();

            if (dictadoExistente == null)
            {
                MessageBox.Show("Debe seleccionar un dictado de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = dictadoExistente.IdDictado;
                DocenteCursoDetallesForm dictadoDetalles = new DocenteCursoDetallesForm();
                DocenteCursoDTO dictadoAModificar = await DocenteCursoAPIClient.GetAsync(idExistente);
                dictadoDetalles.Mode = FormMode.Update;
                dictadoDetalles.DocenteCurso = dictadoAModificar;

                if (dictadoDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Dictado actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDocenteCursosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar dictado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarDictadoSeleccionado();
        }

        private DocenteCursoDTO SelectedItem()
        {
            if (dgvDocenteCursos.SelectedRows.Count > 0 &&
                dgvDocenteCursos.SelectedRows[0].DataBoundItem != null)
            {
                return (DocenteCursoDTO)dgvDocenteCursos.SelectedRows[0].DataBoundItem;
            }
            return null;
        }
    }
}
