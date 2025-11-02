using Academia.WindowsForms.Helpers;
using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class PlanesForm : Form
    {
        private readonly RoleHelper _roleHelper;
        private readonly string _authToken;
        private bool _isAdmin;
        public PlanesForm()
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
            await LoadPlanesAsync();
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
                this.Text = "Gestión de Planes - Administrador";
            }
            else
            {
                // Docente/Alumno: Solo lectura
                buttonAgregar.Visible = false;
                buttonModificar.Visible = false;
                buttonEliminar.Visible = false;
                buttonListar.Visible = false;
                this.Text = "Planes Académicos";
            }
        }

        private void ConfigurarColumnas()
        {
            this.dgvPlanes.AutoGenerateColumns = false;
            this.dgvPlanes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvPlanes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvPlanes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdPlan",
                HeaderText = "Id",
                DataPropertyName = "IdPlan",
                Width = 80
            });

            this.dgvPlanes.Columns.Add(new DataGridViewTextBoxColumn
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

            this.dgvPlanes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionEspecialidad",
                HeaderText = "Descripción de Especialidad",
                DataPropertyName = "DescripcionEspecialidad",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });
        }

        private async Task LoadPlanesAsync()
        {
            try
            {
                this.dgvPlanes.DataSource = null;

                IEnumerable<PlanDTO> planes = await PlanAPIClient.GetAllAsync();

                this.dgvPlanes.DataSource = planes;
                this.dgvPlanes.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvPlanes.Rows.Count > 0)
                {
                    this.dgvPlanes.Rows[0].Selected = true;

                    if (_isAdmin)
                    {
                        this.buttonEliminar.Enabled = true;
                        this.buttonModificar.Enabled = true;
                        this.buttonReporte.Enabled = true;
                    }
                }
                else
                {
                    if (_isAdmin)
                    {
                        this.buttonEliminar.Enabled = false;
                        this.buttonModificar.Enabled = false;
                        this.buttonReporte.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de planes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (_isAdmin)
                {
                    this.buttonEliminar.Enabled = false;
                    this.buttonModificar.Enabled = false;
                    this.buttonReporte.Enabled = false;
                }
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            _ = LoadPlanesAsync();
        }

        private async void EliminarPlanSeleccionado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PlanDTO planExistente = this.SelectedItem();

            if (planExistente == null)
            {
                MessageBox.Show("Debe seleccionar un plan de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el plan?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await PlanAPIClient.DeleteAsync(planExistente.IdPlan);
                    MessageBox.Show("Plan eliminado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPlanesAsync();
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
            EliminarPlanSeleccionado();
        }

        private void CreatePlan()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PlanDetallesForm planDetalles = new PlanDetallesForm();
                PlanDTO planNuevo = new PlanDTO();
                planDetalles.Mode = FormMode.Add;
                planDetalles.Plan = planNuevo;

                if (planDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Plan creado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = LoadPlanesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear plan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreatePlan();
        }

        private async void EditarPlanSeleccionado()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PlanDTO planExistente = this.SelectedItem();

            if (planExistente == null)
            {
                MessageBox.Show("Debe seleccionar un plan de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = planExistente.IdPlan;
                PlanDetallesForm planDetalles = new PlanDetallesForm();
                PlanDTO planAModificar = await PlanAPIClient.GetAsync(idExistente);
                planDetalles.Mode = FormMode.Update;
                planDetalles.Plan = planAModificar;

                if (planDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Plan actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPlanesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar plan: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarPlanSeleccionado();
        }

        // Función para Generar Reporte
        private async Task GenerarReportePlan()
        {
            if (!_isAdmin)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PlanDTO planExistente = this.SelectedItem();

            if (planExistente == null)
            {
                MessageBox.Show("Debe seleccionar un plan de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                buttonReporte.Enabled = false;
                buttonReporte.Text = "Generando...";

                // Generar el PDF
                byte[] pdfBytes = await PlanAPIClient.GenerarPdfAsync(planExistente.IdPlan);

                string fileName = $"Plan_{planExistente.Descripcion.Replace(" ", "_").Replace("/", "_").Replace("\\", "_")}.pdf";

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
            await GenerarReportePlan();
        }

        private PlanDTO SelectedItem()
        {
            if (dgvPlanes.SelectedRows.Count > 0 &&
                dgvPlanes.SelectedRows[0].DataBoundItem != null)
            {
                return (PlanDTO)dgvPlanes.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

    }
}
