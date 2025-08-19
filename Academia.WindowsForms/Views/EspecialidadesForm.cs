using Academia.WindowsForms.Views;
using Academia.Entidades;
using Academia.Negocio;

namespace Academia.WindowsForms.Views
{
    public partial class EspecialidadesForm : Form
    {
        private EspecialidadControlador especialidadControlador;
        private Especialidades especialidades;
        public EspecialidadesForm()
        {
            InitializeComponent();
            especialidadControlador = new EspecialidadControlador();
            especialidades = new Especialidades();
        }
        private async void GetEspecialidades()
        {
            dgvEspecialidades.Rows.Clear();

            try
            {
                especialidades = await EspecialidadControlador.GetAll();

                if (especialidades != null)
                {
                    foreach (var especialidad in especialidades?.ListaEspecialidades!)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvEspecialidades);
                        row.Cells[0].Value = especialidad.IdEspecialidad;
                        row.Cells[1].Value = especialidad.DescEspecialidad;
                        row.Tag = especialidad;
                        dgvEspecialidades.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron especialidades.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener especialidades: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            GetEspecialidades();
        }

        private async void EliminarEspecialidadSeleccionada()
        {
            Especialidad especialidadExistente = this.SelectedItem();

            if (especialidadExistente == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idEspecialidad = especialidadExistente.IdEspecialidad;

                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la especialidad '{idEspecialidad}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    bool eliminado = await EspecialidadControlador.Delete(especialidadExistente.IdEspecialidad);

                    if (eliminado)
                    {
                        MessageBox.Show("Especialidad eliminada exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GetEspecialidades();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar especialidad: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            EliminarEspecialidadSeleccionada();
        }

        private async void CreateEspecialidad()
        {
            try
            {
                using (EspDetallesForm detallesForm = new EspDetallesForm())
                {
                    if (detallesForm.ShowDialog() == DialogResult.OK)
                    {
                        Especialidad nuevaEspecialidad = detallesForm.Especialidad;
                        bool creado = await EspecialidadControlador.Create(nuevaEspecialidad);

                        if (creado)
                        {
                            MessageBox.Show("Especialidad creada exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear especialidad: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateEspecialidad();
            GetEspecialidades();
        }

        private async void EditarEspecialidadSeleccionada()
        {
            Especialidad especialidadExistente = this.SelectedItem();

            if (especialidadExistente == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (EspDetallesForm detallesForm = new EspDetallesForm(especialidadExistente))
                {
                    if (detallesForm.ShowDialog() == DialogResult.OK)
                    {
                        Especialidad especialidadModificada = detallesForm.Especialidad;
                        bool actualizada = await EspecialidadControlador.Update(especialidadModificada);

                        if (actualizada)
                        {
                            MessageBox.Show("Especialidad actualizada exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetEspecialidades();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar especialidad: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarEspecialidadSeleccionada();
        }

        private Especialidad SelectedItem()
        {
            if (dgvEspecialidades.SelectedRows.Count > 0)
            {
                return (Especialidad)dgvEspecialidades.SelectedRows[0].Tag;
            }
            else
            {
                return null;
            }
        }
    }
}
