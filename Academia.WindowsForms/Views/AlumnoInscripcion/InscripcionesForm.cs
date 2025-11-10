using Academia.WindowsForms.Helpers;
using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views.AlumnoInscripcion
{
    public partial class InscripcionesForm : Form
    {
        private readonly RoleHelper _roleHelper;
        private readonly string _authToken;
        private bool _isAdmin;
        private bool _isDocente;
        private bool _isAlumno;
        private int _currentUserId;

        public InscripcionesForm()
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
            _isAlumno = _roleHelper.IsAlumno();

            await GetCurrentUserId();
            ConfigurarColumnas();
            await LoadInscripcionesAsync();
            ConfigureByRole();
        }

        private void ConfigureByRole()
        {
            if (_isAdmin)
            {
                // Admin: CRUD completo
                buttonAgregar.Visible = true;
                buttonAgregar.Text = "Agregar Inscripción";
                buttonModificar.Visible = true;
                buttonEliminar.Visible = true;
                buttonListar.Visible = true;
                buttonCalificar.Visible = false;
                this.Text = "Gestión de Inscripciones - Administrador";
            }
            else if (_isDocente)
            {
                // Docente: Ver inscripciones de sus cursos y calificar
                buttonAgregar.Visible = false;
                buttonModificar.Visible = false;
                buttonEliminar.Visible = false;
                buttonListar.Visible = false;
                buttonCalificar.Visible = true;
                this.Text = "Mis Cursos - Notas";
            }
            else if (_isAlumno)
            {
                // Alumno: Ver sus inscripciones, inscribirse y desinscribirse
                buttonAgregar.Visible = true;
                buttonAgregar.Text = "Inscribirse a Curso";
                buttonModificar.Visible = false;
                buttonEliminar.Visible = true;
                buttonEliminar.Text = "Desinscribirse";
                buttonListar.Visible = false;
                buttonCalificar.Visible = false;
                this.Text = "Mis Inscripciones";
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

                        // Verificar el tipo de persona
                        var persona = await PersonaAPIClient.GetAsync(_currentUserId);
                        if (persona != null)
                        {
                            if (_isAlumno && persona.TipoPersona != 1)
                            {
                                MessageBox.Show("Tu usuario no tiene permisos de alumno.",
                                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _currentUserId = 0;
                                this.Close();
                            }
                            else if (_isDocente && persona.TipoPersona != 2)
                            {
                                MessageBox.Show("Tu usuario no tiene permisos de docente.",
                                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _currentUserId = 0;
                                this.Close();
                            }
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
            this.dgvInscripciones.AutoGenerateColumns = false;
            this.dgvInscripciones.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvInscripciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvInscripciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdInscripcion",
                HeaderText = "Id",
                DataPropertyName = "IdInscripcion",
                Width = 60
            });

            if (_isAdmin || _isDocente)
            {
                this.dgvInscripciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NombreCompletoPersona",
                    HeaderText = "Alumno",
                    DataPropertyName = "NombreCompletoPersona",
                    Width = 200
                });

                this.dgvInscripciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Legajo",
                    HeaderText = "Legajo",
                    DataPropertyName = "Legajo",
                    Width = 80
                });
            }

            this.dgvInscripciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionMateria",
                HeaderText = "Materia",
                DataPropertyName = "DescripcionMateria",
                Width = 250,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });

            this.dgvInscripciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionComision",
                HeaderText = "Comisión",
                DataPropertyName = "DescripcionComision",
                Width = 150
            });

            this.dgvInscripciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnioCalendario",
                HeaderText = "Año",
                DataPropertyName = "AnioCalendario",
                Width = 80
            });

            this.dgvInscripciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Condicion",
                HeaderText = "Condición",
                DataPropertyName = "Condicion",
                Width = 100
            });

            this.dgvInscripciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nota",
                HeaderText = "Nota",
                DataPropertyName = "Nota",
                Width = 60
            });
        }

        private async Task LoadInscripcionesAsync()
        {
            try
            {
                this.dgvInscripciones.DataSource = null;

                var todasInscripciones = await AlumnoInscripcionAPIClient.GetAllAsync();
                IEnumerable<AlumnoInscripcionDTO> inscripciones;

                if (_isAlumno && _currentUserId > 0)
                {
                    // Alumno: solo sus inscripciones
                    inscripciones = todasInscripciones.Where(i => i.IdAlumno == _currentUserId);
                }
                else if (_isDocente && _currentUserId > 0)
                {
                    // Docente: inscripciones de sus cursos
                    inscripciones = await GetInscripcionesDeMisCursos(_currentUserId);
                }
                else
                {
                    // Admin: todas las inscripciones
                    inscripciones = todasInscripciones;
                }

                this.dgvInscripciones.DataSource = inscripciones.ToList();
                this.dgvInscripciones.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvInscripciones.Rows.Count > 0)
                {
                    this.dgvInscripciones.Rows[0].Selected = true;
                    UpdateButtonStates(true);
                }
                else
                {
                    UpdateButtonStates(false);

                    if (_isAlumno)
                    {
                        MessageBox.Show("No tienes inscripciones. ¡Inscríbete a un curso!",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inscripciones: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateButtonStates(false);
            }
        }

        private void UpdateButtonStates(bool hasRows)
        {
            if (_isAdmin)
            {
                this.buttonEliminar.Enabled = hasRows;
                this.buttonModificar.Enabled = hasRows;
            }
            else if (_isDocente)
            {
                this.buttonCalificar.Enabled = hasRows;
            }
            else if (_isAlumno)
            {
                this.buttonEliminar.Enabled = hasRows;
            }
        }

        private async Task<IEnumerable<AlumnoInscripcionDTO>> GetInscripcionesDeMisCursos(int idDocente)
        {
            try
            {
                var misDictados = (await DocenteCursoAPIClient.GetAllAsync())
                    .Where(d => d.IdDocente == idDocente)
                    .ToList();

                if (!misDictados.Any())
                    return new List<AlumnoInscripcionDTO>();

                var misCursosIds = misDictados.Select(d => d.IdCurso).Distinct().ToList();
                var todasInscripciones = await AlumnoInscripcionAPIClient.GetAllAsync();

                return todasInscripciones.Where(i => misCursosIds.Contains(i.IdCurso)).ToList();
            }
            catch
            {
                return new List<AlumnoInscripcionDTO>();
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            _ = LoadInscripcionesAsync();
        }

        private void CreateInscripcion()
        {
            try
            {
                InscripcionDetallesForm inscripcionDetalles = new InscripcionDetallesForm(_isAdmin, _isAlumno, _currentUserId);
                AlumnoInscripcionDTO inscripcionNueva = new AlumnoInscripcionDTO();

                inscripcionDetalles.Mode = FormMode.Add;

                if (_isAlumno)
                {
                    inscripcionNueva.IdAlumno = _currentUserId;
                    inscripcionNueva.Condicion = "Cursando";
                }

                inscripcionDetalles.Inscripcion = inscripcionNueva;

                if (inscripcionDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(
                        _isAlumno ? "Te has inscrito exitosamente." : "Inscripción creada exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = LoadInscripcionesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear inscripción: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateInscripcion();
        }

        private async Task EditarInscripcionSeleccionada()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AlumnoInscripcionDTO inscripcionExistente = this.SelectedItem();

            if (inscripcionExistente == null)
            {
                MessageBox.Show("Debe seleccionar una inscripción de la lista.",
                    "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (inscripcionExistente.Condicion == "Aprobado")
            {
                MessageBox.Show("No se puede editar una inscripción con condición 'Aprobado'.",
                    "Restricción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = inscripcionExistente.IdInscripcion;
                InscripcionDetallesForm inscripcionDetalles = new InscripcionDetallesForm(_isAdmin, false, _currentUserId);
                AlumnoInscripcionDTO inscripcionAModificar = await AlumnoInscripcionAPIClient.GetAsync(idExistente);
                inscripcionDetalles.Mode = FormMode.Update;
                inscripcionDetalles.Inscripcion = inscripcionAModificar;

                if (inscripcionDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Inscripción actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadInscripcionesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar inscripción: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonModificar_Click(object sender, EventArgs e)
        {
            await EditarInscripcionSeleccionada();
        }

        private async Task CalificarInscripcionSeleccionada()
        {
            if (!_isDocente)
            {
                MessageBox.Show("No tienes permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AlumnoInscripcionDTO inscripcionExistente = this.SelectedItem();

            if (inscripcionExistente == null)
            {
                MessageBox.Show("Debe seleccionar una inscripción de la lista.",
                    "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (inscripcionExistente.Condicion == "Aprobado")
            {
                MessageBox.Show("Esta inscripción ya está aprobada y no puede ser modificada.",
                    "Restricción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!await PuedeCalificarCurso(inscripcionExistente.IdCurso))
            {
                MessageBox.Show("No tienes permisos para calificar en este curso.\n" +
                               "Solo los docentes con cargo de Titular o Adjunto pueden calificar.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                InscripcionDetallesForm inscripcionDetalles = new InscripcionDetallesForm(_isAdmin, false, _currentUserId);
                inscripcionDetalles.Mode = FormMode.EditNota;
                inscripcionDetalles.Inscripcion = inscripcionExistente;

                if (inscripcionDetalles.ShowDialog() == DialogResult.OK)
                {
                    await LoadInscripcionesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calificar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> PuedeCalificarCurso(int idCurso)
        {
            try
            {
                var misDictados = (await DocenteCursoAPIClient.GetAllAsync())
                    .Where(d => d.IdDocente == _currentUserId
                             && d.IdCurso == idCurso
                             && (d.Cargo.ToLower() == "titular" || d.Cargo.ToLower() == "adjunto"))
                    .ToList();

                return misDictados.Any();
            }
            catch
            {
                return false;
            }
        }

        private void buttonCalificar_Click(object sender, EventArgs e)
        {
            _ = CalificarInscripcionSeleccionada();
        }

        private async Task EliminarInscripcionSeleccionada()
        {
            if (!_isAdmin && !_isAlumno)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AlumnoInscripcionDTO inscripcionExistente = this.SelectedItem();

            if (inscripcionExistente == null)
            {
                MessageBox.Show("Debe seleccionar una inscripción de la lista.",
                    "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isAlumno && inscripcionExistente.IdAlumno != _currentUserId)
            {
                MessageBox.Show("Solo puedes desinscribirte de tus propias inscripciones.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CanDelete(inscripcionExistente))
            {
                MessageBox.Show($"No se puede eliminar esta inscripción: {GetDeleteRestrictionReason(inscripcionExistente)}",
                    "Restricción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string message = _isAlumno
                    ? $"¿Está seguro que desea desinscribirse de '{inscripcionExistente.DescripcionMateria}'?"
                    : $"¿Está seguro que desea eliminar la inscripción de '{inscripcionExistente.NombreCompletoPersona}' en '{inscripcionExistente.DescripcionMateria}'?";

                DialogResult result = MessageBox.Show(message, "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await AlumnoInscripcionAPIClient.DeleteAsync(inscripcionExistente.IdInscripcion);
                    MessageBox.Show(
                        _isAlumno ? "Te has desinscrito exitosamente." : "Inscripción eliminada exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadInscripcionesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar inscripción: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CanDelete(AlumnoInscripcionDTO inscripcion)
        {
            return inscripcion.Condicion == "Cursando" && !inscripcion.Nota.HasValue;
        }

        private string GetDeleteRestrictionReason(AlumnoInscripcionDTO inscripcion)
        {
            if (inscripcion.Condicion == "Aprobado")
                return "La materia está aprobada";

            if (inscripcion.Nota.HasValue)
                return "Ya tiene nota asignada";

            if (inscripcion.Condicion != "Cursando")
                return $"Condición '{inscripcion.Condicion}' no permite eliminación";

            return "Restricción del sistema";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            _ = EliminarInscripcionSeleccionada();
        }

        private AlumnoInscripcionDTO SelectedItem()
        {
            if (dgvInscripciones.SelectedRows.Count > 0 &&
                dgvInscripciones.SelectedRows[0].DataBoundItem != null)
            {
                return (AlumnoInscripcionDTO)dgvInscripciones.SelectedRows[0].DataBoundItem;
            }
            return null;
        }
    }
}
