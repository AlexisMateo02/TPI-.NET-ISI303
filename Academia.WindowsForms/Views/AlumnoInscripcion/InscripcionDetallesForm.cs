using APIClients;
using DTOs;
using System.Drawing;

namespace Academia.WindowsForms.Views.AlumnoInscripcion
{
    public enum FormMode
    {
        Add,
        Update,
        EditNota
    }
    public partial class InscripcionDetallesForm : Form
    {
        private AlumnoInscripcionDTO inscripcion;
        private FormMode mode;
        private List<PersonaDTO> alumnos;
        private List<CursoDTO> cursos;
        private readonly bool _isAdmin;
        private readonly bool _isAlumno;
        private readonly int _currentUserId;
        private string _originalCondicion;
        public AlumnoInscripcionDTO Inscripcion
        {
            get { return inscripcion; }
            set
            {
                inscripcion = value;
                this.SetInscripcion();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public InscripcionDetallesForm(bool isAdmin, bool isAlumno, int currentUserId)
        {
            InitializeComponent();
            _isAdmin = isAdmin;
            _isAlumno = isAlumno;
            _currentUserId = currentUserId;
            LoadCondiciones();
            LoadAlumnos();
            LoadCursos();
            Mode = FormMode.Add;
        }

        private void LoadCondiciones()
        {
            var condiciones = new List<string>
            {
                "Cursando",
                "Regular",
                "Aprobado",
                "Libre"
            };

            comboBoxCondicion.DataSource = condiciones;
            // comboBoxCondicion.SelectedIndex = -1;
        }

        private async void LoadAlumnos()
        {
            try
            {
                comboBoxAlumno.DataSource = null;
                alumnos = (await PersonaAPIClient.GetAlumnosAsync()).ToList();

                comboBoxAlumno.DataSource = alumnos;
                comboBoxAlumno.DisplayMember = "NombreCompletoYLegajoPersona";
                comboBoxAlumno.ValueMember = "IdPersona";
                comboBoxAlumno.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar alumnos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadCursos()
        {
            try
            {
                comboBoxCurso.DataSource = null;
                cursos = (await CursoAPIClient.GetAllAsync()).ToList();

                comboBoxCurso.DataSource = cursos;
                comboBoxCurso.DisplayMember = "DescripcionCompleta";
                comboBoxCurso.ValueMember = "IdCurso";
                comboBoxCurso.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cursos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (await this.ValidateInscripcion())
            {
                try
                {
                    this.Inscripcion.Condicion = comboBoxCondicion.SelectedItem?.ToString() ?? "";

                    // Limpiar nota si la condición no lo permite
                    if (this.Inscripcion.Condicion == "Cursando" ||
                        this.Inscripcion.Condicion == "Libre" ||
                        this.Inscripcion.Condicion == "Regular")
                    {
                        this.Inscripcion.Nota = null;
                    }
                    else if (this.Inscripcion.Condicion == "Aprobado")
                    {
                        // Validar que la nota esté en el rango correcto
                        if (numericNota.Value < 6 || numericNota.Value > 10)
                        {
                            MessageBox.Show("La nota debe estar entre 6 y 10 para aprobar.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        this.Inscripcion.Nota = (int)numericNota.Value;
                    }

                    if (Mode != FormMode.EditNota)
                    {
                        if (Mode == FormMode.Add && _isAlumno)
                        {
                            this.Inscripcion.IdAlumno = _currentUserId;
                        }
                        else
                        {
                            this.Inscripcion.IdAlumno = (int)comboBoxAlumno.SelectedValue;
                        }

                        this.Inscripcion.IdCurso = (int)comboBoxCurso.SelectedValue;
                    }

                    if (this.Mode == FormMode.Update || this.Mode == FormMode.EditNota)
                    {
                        await AlumnoInscripcionAPIClient.UpdateAsync(this.Inscripcion);
                        MessageBox.Show(
                            Mode == FormMode.EditNota ? "Calificación guardada exitosamente." : "Inscripción actualizada exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        await AlumnoInscripcionAPIClient.AddAsync(this.Inscripcion);
                        MessageBox.Show(
                            _isAlumno ? "Te has inscrito exitosamente." : "Inscripción creada exitosamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void SetInscripcion()
        {
            this.textId.Text = this.Inscripcion.IdInscripcion.ToString();

            if (Mode == FormMode.Add)
            {
                // Asegurar que la condición esté en "Cursando" para modo Add
                comboBoxCondicion.SelectedIndex = 0;

                if (_isAlumno)
                {
                    comboBoxAlumno.SelectedValue = _currentUserId;
                }
            }

            if (Mode == FormMode.EditNota)
            {
                // Modo calificación: mostrar info del docente y datos readonly
                await LoadCargoDocente();
                textAlumnoReadOnly.Text = this.Inscripcion.NombreCompletoPersona;
                textMateriaReadOnly.Text = this.Inscripcion.DescripcionMateria;
                textCondicionOriginal.Text = this.Inscripcion.Condicion;
                _originalCondicion = this.Inscripcion.Condicion;
            }
            else if (Mode == FormMode.Update)
            {
                comboBoxAlumno.SelectedValue = this.Inscripcion.IdAlumno;
                comboBoxCurso.SelectedValue = this.Inscripcion.IdCurso;
                _originalCondicion = this.Inscripcion.Condicion;
            }

            // Solo setear la condición del DTO si NO es modo Add
            if (Mode != FormMode.Add)
            {
                comboBoxCondicion.SelectedItem = this.Inscripcion.Condicion;
            }

            if (this.Inscripcion.Nota.HasValue)
            {
                numericNota.Value = this.Inscripcion.Nota.Value;
            }
            else
            {
                numericNota.Value = 0;
            }

            UpdateNotaState();
        }

        private async Task LoadCargoDocente()
        {
            try
            {
                var misDictados = (await DocenteCursoAPIClient.GetAllAsync())
                    .Where(d => d.IdDocente == _currentUserId && d.IdCurso == this.Inscripcion.IdCurso)
                    .ToList();

                var cargo = misDictados.FirstOrDefault()?.Cargo ?? "No asignado";
                textCargoDocente.Text = cargo;

                // Verificar si puede calificar
                if (cargo.ToLower() != "titular" && cargo.ToLower() != "adjunto")
                {
                    textCargoDocente.ForeColor = Color.Red;
                    buttonAceptar.Enabled = false;
                    MessageBox.Show("Solo los docentes con cargo de Titular o Adjunto pueden calificar alumnos.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    textCargoDocente.ForeColor = Color.Green;
                }
            }
            catch
            {
                textCargoDocente.Text = "Error al cargar cargo";
                textCargoDocente.ForeColor = Color.Red;
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                labelId.Visible = false;
                textId.Visible = false;

                // Ocultar controles de modo EditNota
                labelCargoDocente.Visible = false;
                textCargoDocente.Visible = false;
                labelAlumnoReadOnly.Visible = false;
                textAlumnoReadOnly.Visible = false;
                labelMateriaReadOnly.Visible = false;
                textMateriaReadOnly.Visible = false;
                labelCondicionOriginal.Visible = false;
                textCondicionOriginal.Visible = false;

                // Mostrar controles normales
                label2.Visible = true;
                comboBoxAlumno.Visible = true;
                label3.Visible = true;
                comboBoxCurso.Visible = true;

                numericNota.Visible = false;
                labelNota.Visible = false;
                panelAdvertencia.Visible = false;

                comboBoxCondicion.Enabled = false;
                comboBoxCondicion.SelectedIndex = 0;  // "Cursando" es el índice 0

                if (_isAlumno)
                {
                    label2.Visible = false;
                    comboBoxAlumno.Visible = false;
                }
                else
                {
                    comboBoxAlumno.Enabled = true;
                }
            }

            if (Mode == FormMode.Update)
            {
                labelId.Visible = true;
                textId.Visible = true;
                textId.ReadOnly = true;

                // Ocultar controles de modo EditNota
                labelCargoDocente.Visible = false;
                textCargoDocente.Visible = false;
                labelAlumnoReadOnly.Visible = false;
                textAlumnoReadOnly.Visible = false;
                labelMateriaReadOnly.Visible = false;
                textMateriaReadOnly.Visible = false;
                labelCondicionOriginal.Visible = false;
                textCondicionOriginal.Visible = false;

                // Mostrar controles normales
                label2.Visible = true;
                comboBoxAlumno.Visible = true;
                label3.Visible = true;
                comboBoxCurso.Visible = true;

                // Deshabilitar alumno y curso en modo edición
                comboBoxAlumno.Enabled = false;
                comboBoxCurso.Enabled = false;

                numericNota.Visible = true;
                labelNota.Visible = true;
                panelAdvertencia.Visible = false;

                comboBoxCondicion.Enabled = true;  // En UPDATE el admin SÍ puede cambiar
            }

            if (Mode == FormMode.EditNota)
            {
                labelId.Visible = true;
                textId.Visible = true;
                textId.ReadOnly = true;

                // Mostrar controles específicos de EditNota
                labelCargoDocente.Visible = true;
                textCargoDocente.Visible = true;
                textCargoDocente.ReadOnly = true;
                labelAlumnoReadOnly.Visible = true;
                textAlumnoReadOnly.Visible = true;
                textAlumnoReadOnly.ReadOnly = true;
                labelMateriaReadOnly.Visible = true;
                textMateriaReadOnly.Visible = true;
                textMateriaReadOnly.ReadOnly = true;
                labelCondicionOriginal.Visible = true;
                textCondicionOriginal.Visible = true;
                textCondicionOriginal.ReadOnly = true;

                // Ocultar controles normales de alumno y curso
                label2.Visible = false;
                comboBoxAlumno.Visible = false;
                label3.Visible = false;
                comboBoxCurso.Visible = false;

                numericNota.Visible = true;
                labelNota.Visible = true;
                panelAdvertencia.Visible = false;

                label4.Text = "Nueva Condición *";
                comboBoxCondicion.Enabled = true;  // El docente SÍ puede cambiar en EditNota
            }
        }

        private async Task<bool> ValidateInscripcion()
        {
            if (Mode == FormMode.EditNota)
            {
                // Validar que el docente puede calificar
                var cargo = textCargoDocente.Text.ToLower();
                if (cargo != "titular" && cargo != "adjunto")
                {
                    MessageBox.Show("Solo los docentes con cargo de Titular o Adjunto pueden calificar alumnos.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (Mode != FormMode.EditNota)
            {
                // Solo validar alumno si NO es alumno o si el combo está visible
                if (!_isAlumno && (comboBoxAlumno.SelectedValue == null || (int)comboBoxAlumno.SelectedValue <= 0))
                {
                    MessageBox.Show("Debe seleccionar un alumno.", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxAlumno.Focus();
                    return false;
                }

                if (comboBoxCurso.SelectedValue == null || (int)comboBoxCurso.SelectedValue <= 0)
                {
                    MessageBox.Show("Debe seleccionar un curso.", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxCurso.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(comboBoxCondicion.SelectedItem?.ToString()))
            {
                MessageBox.Show("Debe seleccionar una condición.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCondicion.Focus();
                return false;
            }

            // Validar nota según condición
            string condicion = comboBoxCondicion.SelectedItem.ToString();
            if (condicion == "Aprobado")
            {
                if (numericNota.Value < 6 || numericNota.Value > 10)
                {
                    MessageBox.Show("La nota debe estar entre 6 y 10 para aprobar la materia.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numericNota.Focus();
                    return false;
                }
            }

            // Validar duplicados en modo Add
            if (Mode == FormMode.Add)
            {
                try
                {
                    this.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    int idAlumno = _isAlumno ? _currentUserId : (int)comboBoxAlumno.SelectedValue;
                    int idCurso = (int)comboBoxCurso.SelectedValue;

                    bool existeInscripcion = await AlumnoInscripcionAPIClient.ExistAlumnoCursoAsync(
                        idAlumno, idCurso, null);

                    if (existeInscripcion)
                    {
                        if (_isAlumno)
                        {
                            var curso = cursos.FirstOrDefault(c => c.IdCurso == idCurso);
                            MessageBox.Show(
                                $"Ya estás inscrito en el curso '{curso?.DescripcionMateria} - {curso?.DescripcionComision}'.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            var alumno = alumnos.FirstOrDefault(a => a.IdPersona == idAlumno);
                            var curso = cursos.FirstOrDefault(c => c.IdCurso == idCurso);
                            MessageBox.Show(
                                $"El alumno '{alumno?.NombreCompletoPersona}' ya está inscrito en el curso '{curso?.DescripcionMateria} - {curso?.DescripcionComision}'.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        comboBoxCurso.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al validar inscripción: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }

            return true;
        }

        private void comboBoxCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNotaState();
            UpdateAdvertencia();
        }

        private void UpdateNotaState()
        {
            if (comboBoxCondicion.SelectedItem == null)
            {
                numericNota.Enabled = false;
                labelInfoNota.Text = "Selecciona una condición primero";
                labelInfoCondicion.Text = "";
                return;
            }

            string condicion = comboBoxCondicion.SelectedItem.ToString();

            switch (condicion)
            {
                case "Cursando":
                    numericNota.Enabled = false;
                    numericNota.Value = 0;
                    labelInfoNota.Text = "Nota no disponible para esta condición";
                    labelInfoCondicion.Text = "El alumno está actualmente cursando la materia (no requiere nota)";
                    break;

                case "Regular":
                    numericNota.Enabled = false;
                    numericNota.Value = 0;
                    labelInfoNota.Text = "Nota no disponible para esta condición";
                    labelInfoCondicion.Text = "El alumno ha regularizado la materia (no requiere nota)";
                    break;

                case "Libre":
                    numericNota.Enabled = false;
                    numericNota.Value = 0;
                    labelInfoNota.Text = "Nota no disponible para esta condición";
                    labelInfoCondicion.Text = "El alumno ha quedado libre en la materia (no requiere nota)";
                    break;

                case "Aprobado":
                    numericNota.Enabled = true;
                    if (numericNota.Value < 6)
                        numericNota.Value = 6;
                    labelInfoNota.Text = "Nota requerida (6-10 para aprobar)";
                    labelInfoCondicion.Text = "El alumno ha aprobado la materia (requiere nota 6-10)";
                    break;
            }
        }

        private void UpdateAdvertencia()
        {
            if (Mode == FormMode.Update || Mode == FormMode.EditNota)
            {
                string nuevaCondicion = comboBoxCondicion.SelectedItem?.ToString() ?? "";

                if (nuevaCondicion == "Aprobado" && _originalCondicion != "Aprobado")
                {
                    panelAdvertencia.Visible = true;
                    labelAdvertencia.Text = $"¡ATENCIÓN!\n\n" +
                        $"Estás cambiando la condición de \"{_originalCondicion}\" a \"Aprobado\".\n\n" +
                        $"Una vez aprobada, esta inscripción NO podrá ser modificada ni eliminada.";
                }
                else
                {
                    panelAdvertencia.Visible = false;
                }
            }
        }
    }
}
