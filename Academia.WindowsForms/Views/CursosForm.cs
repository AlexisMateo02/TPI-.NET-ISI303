using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class CursosForm : Form
    {
        public CursosForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
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
        private async void LoadCursos()
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
                MessageBox.Show($"Error al cargar la lista de cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonEliminar.Enabled = false;
                this.buttonModificar.Enabled = false;
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.LoadCursos();
        }

        private void CreateCurso()
        {
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
                    }
                }
                this.LoadCursos();
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
                }
                this.LoadCursos();
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
                    MessageBox.Show("Curso eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCursos();
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
