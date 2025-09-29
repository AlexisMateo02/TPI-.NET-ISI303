using DTOs;
using APIClients;

namespace Academia.WindowsForms.Views
{
    public partial class PlanesForm : Form
    {
        public PlanesForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
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

        private async void LoadPlanes()
        {
            try
            {
                this.dgvPlanes.DataSource = null;

                IEnumerable<PlanDTO> planes;
                planes = await PlanAPIClient.GetAllAsync();

                this.dgvPlanes.DataSource = planes;
                this.dgvPlanes.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvPlanes.Rows.Count > 0)
                {
                    this.dgvPlanes.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonEliminar.Enabled = false;
                this.buttonModificar.Enabled = false;
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.LoadPlanes();
        }

        private async void EliminarPlanSeleccionado()
        {
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
                    MessageBox.Show("Plan eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPlanes();
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
            try
            {
                PlanDetallesForm planDetalles = new PlanDetallesForm();
                PlanDTO planNuevo = new PlanDTO();
                planDetalles.Mode = FormMode.Add;
                planDetalles.Plan = planNuevo;
                {
                    if (planDetalles.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Plan creado exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.LoadPlanes();
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
            PlanDTO planExistente = this.SelectedItem();

            if (planExistente == null)
            {
                MessageBox.Show("Debe seleccionar una plan de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = planExistente.IdPlan;
                PlanDetallesForm planDetalles = new PlanDetallesForm(); ;
                PlanDTO planAModificar = await PlanAPIClient.GetAsync(idExistente);
                planDetalles.Mode = FormMode.Update;
                planDetalles.Plan = planAModificar;
                if (planDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Plan actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.LoadPlanes();
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
