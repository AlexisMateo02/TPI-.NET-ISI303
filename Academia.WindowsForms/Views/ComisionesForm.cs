using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class ComisionesForm : Form
    {
        public ComisionesForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvComisiones.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvComisiones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvComisiones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdComision",
                HeaderText = "ID",
                DataPropertyName = "IdComision",
                Width = 80
            });

            this.dgvComisiones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionComision",
                HeaderText = "Descripción",
                DataPropertyName = "DescripcionComision",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });

            this.dgvComisiones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnioEspecialidad",
                HeaderText = "Año de Especialidad",
                DataPropertyName = "AnioEspecialidad",
                Width = 140
            });

            this.dgvComisiones.Columns.Add(new DataGridViewTextBoxColumn
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

            this.dgvComisiones.Columns.Add(new DataGridViewTextBoxColumn
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

        private async void LoadComisiones()
        {
            try
            {
                this.dgvComisiones.DataSource = null;

                IEnumerable<ComisionDTO> comisiones;
                comisiones = await ComisionAPIClient.GetAllAsync();

                var planes = await PlanAPIClient.GetAllAsync();
                var especialidades = await EspecialidadAPIClient.GetAllAsync();

                foreach (var comision in comisiones)
                {
                    var plan = planes.FirstOrDefault(p => p.IdPlan == comision.IdPlan);
                    if (plan != null)
                    {
                        comision.DescripcionPlan = plan.Descripcion;
                        var esp = especialidades.FirstOrDefault(e => e.Id == plan.IdEspecialidad);
                        if (esp != null)
                        {
                            comision.DescripcionEspecialidad = esp.Descripcion;
                        }
                    }
                }

                this.dgvComisiones.DataSource = comisiones;
                this.dgvComisiones.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvComisiones.Rows.Count > 0)
                {
                    this.dgvComisiones.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de comisiones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonEliminar.Enabled = false;
                this.buttonModificar.Enabled = false;
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.LoadComisiones();
        }

        private void CreateComision()
        {
            try
            {
                ComisionDetallesForm comisionDetalles = new ComisionDetallesForm();
                ComisionDTO comisionNueva = new ComisionDTO();
                comisionDetalles.Mode = FormMode.Add;
                comisionDetalles.Comision = comisionNueva;
                {
                    if (comisionDetalles.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Comisión creada exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.LoadComisiones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear comisión: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateComision();
        }

        private async void EditarComisionSeleccionada()
        {
            ComisionDTO comisionExistente = this.SelectedItem();

            if (comisionExistente == null)
            {
                MessageBox.Show("Debe seleccionar una comisión de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = comisionExistente.IdComision;
                ComisionDetallesForm comisionDetalles = new ComisionDetallesForm();
                ComisionDTO comisionAModificar = await ComisionAPIClient.GetAsync(idExistente);
                comisionDetalles.Mode = FormMode.Update;
                comisionDetalles.Comision = comisionAModificar;
                if (comisionDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Comisión actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.LoadComisiones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar comisión: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarComisionSeleccionada();
        }

        private async void EliminarComisionSeleccionada()
        {
            ComisionDTO comisionExistente = this.SelectedItem();

            if (comisionExistente == null)
            {
                MessageBox.Show("Debe seleccionar una comisión de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar a la comisión?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await ComisionAPIClient.DeleteAsync(comisionExistente.IdComision);
                    MessageBox.Show("Comisión eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComisiones();
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
            EliminarComisionSeleccionada();
        }

        private ComisionDTO SelectedItem()
        {
            if (dgvComisiones.SelectedRows.Count > 0 &&
                dgvComisiones.SelectedRows[0].DataBoundItem != null)
            {
                return (ComisionDTO)dgvComisiones.SelectedRows[0].DataBoundItem;
            }
            return null;
        }
    }
}
