using Academia.Entidades;
using Academia.WindowsForms.Helpers;
using APIClients;
using DTOs;
using System.Threading.Tasks;

namespace Academia.WindowsForms.Views.Curso
{
    public partial class CursosForm : Form
    {
        private readonly RoleHelper _roleHelper;
        private readonly string _authToken;
        private bool _isAdmin;
        public CursosForm()
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
            await LoadCursosAsync();
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
                this.Text = "Gestión de Cursos - Administrador";
            }
            else
            {
                // Docente/Alumno: Solo lectura
                buttonAgregar.Visible = false;
                buttonModificar.Visible = false;
                buttonEliminar.Visible = false;
                buttonListar.Visible = false;
                this.Text = "Cursos";
            }
        }

        private void ConfigurarColumnas()
        {
            this.dgvCursos.AutoGenerateColumns = false;
            this.dgvCursos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvCursos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdCurso",
                HeaderText = "ID",
                DataPropertyName = "IdCurso",
                Width = 80
            });

            this.dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnioCalendario",
                HeaderText = "Año de Calendario",
                DataPropertyName = "AnioCalendario",
                Width = 140
            });

            this.dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cupo",
                HeaderText = "Cupo",
                DataPropertyName = "Cupo",
                Width = 80
            });

            this.dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionComision",
                HeaderText = "Comisión",
                DataPropertyName = "DescripcionComision",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });

            this.dgvCursos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionMateria",
                HeaderText = "Materia",
                DataPropertyName = "DescripcionMateria",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });
        }
        private async Task LoadCursosAsync()
        {
            try
            {
                this.dgvCursos.DataSource = null;

                IEnumerable<CursoDTO> cursos;
                cursos = await CursoAPIClient.GetAllAsync();

                this.dgvCursos.DataSource = cursos;
                this.dgvCursos.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvCursos.Rows.Count > 0)
                {
                    this.dgvCursos.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de cursos: {ex.Message}", "Error",
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
            _ = LoadCursosAsync();
        }

        private void CreateCurso()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                CursoDetallesForm cursoDetalles = new CursoDetallesForm();
                CursoDTO cursoNuevo = new CursoDTO();
                cursoDetalles.Mode = FormMode.Add;
                cursoDetalles.Curso = cursoNuevo;
                {
                    if (cursoDetalles.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Curso creado exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _ = LoadCursosAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear curso: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateCurso();
        }

        private async void EditarCursoSeleccionado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CursoDTO cursoExistente = this.SelectedItem();

            if (cursoExistente == null)
            {
                MessageBox.Show("Debe seleccionar una curso de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = cursoExistente.IdCurso;
                CursoDetallesForm cursoDetalles = new CursoDetallesForm(); ;
                CursoDTO cursoAModificar = await CursoAPIClient.GetAsync(idExistente);
                cursoDetalles.Mode = FormMode.Update;
                cursoDetalles.Curso = cursoAModificar;
                if (cursoDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Curso actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCursosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar curso: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarCursoSeleccionado();
        }

        private async void EliminarCursoSeleccionado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CursoDTO cursoExistente = this.SelectedItem();

            if (cursoExistente == null)
            {
                MessageBox.Show("Debe seleccionar un curso de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el curso?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await CursoAPIClient.DeleteAsync(cursoExistente.IdCurso);
                    MessageBox.Show("Curso eliminado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCursosAsync();
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
            EliminarCursoSeleccionado();
        }

        private async Task GenerarReporteCurso()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CursoDTO cursoExistente = this.SelectedItem();

            if (cursoExistente == null)
            {
                MessageBox.Show("Debe seleccionar un curso de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                buttonReporte.Enabled = false;
                buttonReporte.Text = "Generando...";

                // Generar el PDF
                byte[] pdfBytes = await CursoAPIClient.GenerarPdfAsync(cursoExistente.IdCurso);

                string fileName = $"Curso_{cursoExistente?.DescripcionMateria?.Replace(" ", "_").Replace("/", "_").Replace("\\", "_")}_{cursoExistente?.DescripcionComision?.Replace(" ", "_").Replace("/", "_").Replace("\\", "_")}_{cursoExistente?.AnioCalendario}.pdf";

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = fileName;
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Guardar el archivo
                        await File.WriteAllBytesAsync(saveFileDialog.FileName, pdfBytes);

                        MessageBox.Show($"PDF generado exitosamente.\n\nArchivo guardado en:\n{saveFileDialog.FileName}",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var result = MessageBox.Show("¿Desea abrir el PDF ahora?",
                            "Abrir PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                buttonReporte.Enabled = true;
                buttonReporte.Text = "Generar reporte";
            }
        }

        private async void buttonReporte_Click(object sender, EventArgs e)
        {
            await GenerarReporteCurso();
        }

        private CursoDTO SelectedItem()
        {
            if (dgvCursos.SelectedRows.Count > 0 &&
                dgvCursos.SelectedRows[0].DataBoundItem != null)
            {
                return (CursoDTO)dgvCursos.SelectedRows[0].DataBoundItem;
            }
            return null;
        }
    }
}
