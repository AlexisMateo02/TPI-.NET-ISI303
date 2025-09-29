using DTOs;
using APIClients;

namespace Academia.WindowsForms.Views
{
    public partial class MateriasForm : Form
    {
        public MateriasForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.dgvMaterias.AutoGenerateColumns = false;
            this.dgvMaterias.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvMaterias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdMateria",
                HeaderText = "Id",
                DataPropertyName = "IdMateria",
                Width = 80
            });

            this.dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DescripcionMateria",
                HeaderText = "Descripción",
                DataPropertyName = "DescripcionMateria",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            });

            this.dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HorasSemanales",
                HeaderText = "Horas Semanales",
                DataPropertyName = "HorasSemanales",
                Width = 140
            });

            this.dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HorasTotales",
                HeaderText = "Horas Totales",
                DataPropertyName = "HorasTotales",
                Width = 140
            });

            this.dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn
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

            this.dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn
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
        private async void LoadMaterias()
        {
            try
            {
                this.dgvMaterias.DataSource = null;

                IEnumerable<MateriaDTO> materias;
                materias = await MateriaAPIClient.GetAllAsync();

                var planes = await PlanAPIClient.GetAllAsync();
                var especialidades = await EspecialidadAPIClient.GetAllAsync();

                foreach (var materia in materias)
                {
                    var plan = planes.FirstOrDefault(p => p.IdPlan == materia.IdPlan);
                    if (plan != null)
                    {
                        materia.DescripcionPlan = plan.Descripcion;
                        var esp = especialidades.FirstOrDefault(e => e.Id == plan.IdEspecialidad);
                        if (esp != null)
                        {
                            materia.DescripcionEspecialidad = esp.Descripcion;
                        }
                    }
                }

                this.dgvMaterias.DataSource = materias;
                this.dgvMaterias.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvMaterias.Rows.Count > 0)
                {
                    this.dgvMaterias.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonEliminar.Enabled = false;
                this.buttonModificar.Enabled = false;
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.LoadMaterias();
        }

        private void CreateMateria()
        {
            try
            {
                MateriaDetallesForm materiaDetalles = new MateriaDetallesForm();
                MateriaDTO materiaNueva = new MateriaDTO();
                materiaDetalles.Mode = FormMode.Add;
                materiaDetalles.Materia = materiaNueva;
                {
                    if (materiaDetalles.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Materia creada exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.LoadMaterias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear materia: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateMateria();
        }

        private async void EditarMateriaSeleccionada()
        {
            MateriaDTO materiaExistente = this.SelectedItem();

            if (materiaExistente == null)
            {
                MessageBox.Show("Debe seleccionar una materia de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = materiaExistente.IdMateria;
                MateriaDetallesForm materiaDetalles = new MateriaDetallesForm();
                MateriaDTO materiaAModificar = await MateriaAPIClient.GetAsync(idExistente);
                materiaDetalles.Mode = FormMode.Update;
                materiaDetalles.Materia = materiaAModificar;
                if (materiaDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Materia actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.LoadMaterias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar materia: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarMateriaSeleccionada();
        }

        private async void EliminarMateriaSeleccionada()
        {
            MateriaDTO materiaExistente = this.SelectedItem();

            if (materiaExistente == null)
            {
                MessageBox.Show("Debe seleccionar una materia de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar a la materia?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await MateriaAPIClient.DeleteAsync(materiaExistente.IdMateria);
                    MessageBox.Show("Materia eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMaterias();
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
            EliminarMateriaSeleccionada();
        }

        private MateriaDTO SelectedItem()
        {
            if (dgvMaterias.SelectedRows.Count > 0 &&
                dgvMaterias.SelectedRows[0].DataBoundItem != null)
            {
                return (MateriaDTO)dgvMaterias.SelectedRows[0].DataBoundItem;
            }
            return null;
        }
    }
}
