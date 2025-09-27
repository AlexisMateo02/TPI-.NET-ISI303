using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class PersonasForm : Form
    {
        public PersonasForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvPersonas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdPersona",
                HeaderText = "ID",
                DataPropertyName = "IdPersona",
                Width = 80
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Legajo",
                HeaderText = "Legajo",
                DataPropertyName = "Legajo",
                Width = 80
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 200
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Apellido",
                HeaderText = "Apellido",
                DataPropertyName = "Apellido",
                Width = 200
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaNacimiento",
                HeaderText = "Fecha de Nacimiento",
                DataPropertyName = "FechaNacimiento",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 100
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Direccion",
                HeaderText = "Dirección",
                DataPropertyName = "Direccion",
                Width = 200
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoPersona",
                HeaderText = "Tipo",
                DataPropertyName = "TipoPersonaDescripcion",
                Width = 100
            });

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
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

            this.dgvPersonas.Columns.Add(new DataGridViewTextBoxColumn
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

        private async void LoadPersonas(int tipoLoad)
        {
            try
            {
                this.dgvPersonas.DataSource = null;

                IEnumerable<PersonaDTO> personas;
                if (tipoLoad == 1)
                {
                    personas = await PersonaAPIClient.GetAlumnosAsync();
                }
                else if(tipoLoad == 2)
                {
                    personas = await PersonaAPIClient.GetDocentesAsync();
                }
                else
                {
                    personas = await PersonaAPIClient.GetAllAsync();
                }

                var planes = await PlanAPIClient.GetAllAsync();
                var especialidades = await EspecialidadAPIClient.GetAllAsync();

                foreach (var persona in personas)
                {
                    var plan = planes.FirstOrDefault(p => p.IdPlan == persona.IdPlan);
                    if (plan != null)
                    {
                        persona.DescripcionPlan = plan.Descripcion;
                        var esp = especialidades.FirstOrDefault(e => e.Id == plan.IdEspecialidad);
                        if (esp != null)
                            persona.DescripcionEspecialidad = esp.Descripcion;
                    }
                }

                this.dgvPersonas.DataSource = personas;
                this.dgvPersonas.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                if (this.dgvPersonas.Rows.Count > 0)
                {
                    this.dgvPersonas.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonEliminar.Enabled = false;
                this.buttonModificar.Enabled = false;
            }
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            this.LoadPersonas(0);
        }

        private void buttonListarAlumnos_Click(object sender, EventArgs e)
        {
            this.LoadPersonas(1);
        }

        private void buttonListarDocentes_Click(object sender, EventArgs e)
        {
            this.LoadPersonas(2);
        }

        private void CreatePersona()
        {
            try
            {
                PersonaDetallesForm personaDetalles = new PersonaDetallesForm();
                PersonaDTO personaNueva = new PersonaDTO();
                personaDetalles.Mode = FormMode.Add;
                personaDetalles.Persona = personaNueva;
                {
                    if (personaDetalles.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Persona creada exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.LoadPersonas(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear persona: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreatePersona();
        }

        private async void EditarPersonaSeleccionada()
        {
            PersonaDTO personaExistente = this.SelectedItem();

            if (personaExistente == null)
            {
                MessageBox.Show("Debe seleccionar una persona de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = personaExistente.IdPersona;
                PersonaDetallesForm personaDetalles = new PersonaDetallesForm();
                PersonaDTO personaAModificar = await PersonaAPIClient.GetAsync(idExistente);
                personaDetalles.Mode = FormMode.Update;
                personaDetalles.Persona = personaAModificar;
                if (personaDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Persona actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.LoadPersonas(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar persona: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarPersonaSeleccionada();
        }

        private async void EliminarPersonaSeleccionada()
        {
            PersonaDTO personaExistente = this.SelectedItem();

            if (personaExistente == null)
            {
                MessageBox.Show("Debe seleccionar una persona de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar a la persona?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await PersonaAPIClient.DeleteAsync(personaExistente.IdPersona);
                    MessageBox.Show("Persona eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPersonas(0);
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
            EliminarPersonaSeleccionada();
        }

        private PersonaDTO SelectedItem()
        {
            if (dgvPersonas.SelectedRows.Count > 0 &&
                dgvPersonas.SelectedRows[0].DataBoundItem != null)
            {
                return (PersonaDTO)dgvPersonas.SelectedRows[0].DataBoundItem;
            }
            return null;
        }
    }
}
