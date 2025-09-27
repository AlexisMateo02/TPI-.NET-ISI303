using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class PersonaDetallesForm : Form
    {
        private PersonaDTO persona;
        private FormMode mode;
        private List<EspecialidadDTO> especialidades;
        private List<PlanDTO> todosLosPlanes;

        public PersonaDTO Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                this.SetPersona();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public PersonaDetallesForm()
        {
            InitializeComponent();
            LoadTiposPersona();
            LoadEspecialidades();
            Mode = FormMode.Add;
        }

        private void LoadTiposPersona()
        {
            var tipos = new List<object>
            {
                new { Id = 1, Descripcion = "Estudiante" },
                new { Id = 2, Descripcion = "Docente" }
            };

            comboBoxTipoPersona.DataSource = tipos;
            comboBoxTipoPersona.DisplayMember = "Descripcion";
            comboBoxTipoPersona.ValueMember = "Id";
            comboBoxTipoPersona.SelectedIndex = -1;
        }

        private async void LoadEspecialidades()
        {
            try
            {
                comboBoxEspecialidad.DataSource = null;
                especialidades = (await EspecialidadAPIClient.GetAllAsync()).ToList();
                comboBoxEspecialidad.DataSource = especialidades;
                comboBoxEspecialidad.DisplayMember = "Descripcion";
                comboBoxEspecialidad.ValueMember = "Id";
                comboBoxEspecialidad.SelectedIndex = -1;

                
                todosLosPlanes = (await PlanAPIClient.GetAllAsync()).ToList();

                comboBoxPlan.DataSource = null;
                comboBoxPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxEspecialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEspecialidad.SelectedValue != null && comboBoxEspecialidad.SelectedValue is int idEspecialidad)
            {
                var planesFiltrados = todosLosPlanes.Where(p => p.IdEspecialidad == idEspecialidad)
                    .ToList();

                comboBoxPlan.DataSource = planesFiltrados;
                comboBoxPlan.DisplayMember = "Descripcion";
                comboBoxPlan.ValueMember = "IdPlan";

                if (Mode == FormMode.Update && Persona != null)
                {
                    var planActual = planesFiltrados.FirstOrDefault(p => p.IdPlan == Persona.IdPlan);
                    if (planActual != null)
                    {
                        comboBoxPlan.SelectedValue = Persona.IdPlan;
                    }
                    else
                    {
                        comboBoxPlan.SelectedIndex = -1;
                    }
                }
                else
                {
                    comboBoxPlan.SelectedIndex = -1;
                }
            }
            else
            {
                comboBoxPlan.DataSource = null;
                comboBoxPlan.SelectedIndex = -1;
            }
        }

        private async void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (await this.ValidatePersona())
            {
                try
                {
                    this.Persona.Legajo = int.Parse(textLegajo.Text);
                    this.Persona.Nombre = textNombre.Text;
                    this.Persona.Apellido = textApellido.Text;
                    this.Persona.Direccion = textDireccion.Text;
                    this.Persona.Email = textEmail.Text;
                    this.Persona.Telefono = textTelefono.Text;
                    this.Persona.FechaNacimiento = pickerFechaNac.Value;
                    this.Persona.TipoPersona = (int)comboBoxTipoPersona.SelectedValue;
                    this.Persona.IdPlan = (int)comboBoxPlan.SelectedValue;

                    if (this.Mode == FormMode.Update)
                    {
                        await PersonaAPIClient.UpdateAsync(this.Persona);
                    }
                    else
                    {
                        await PersonaAPIClient.AddAsync(this.Persona);
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
        private async void SetEspecialidadYPlan()
        {
            try
            {
                var plan = todosLosPlanes?.FirstOrDefault(p => p.IdPlan == Persona.IdPlan);

                if (plan != null)
                {
                    comboBoxEspecialidad.SelectedValue = plan.IdEspecialidad;

                    // Esperar a que se actualice el combo de planes
                    Application.DoEvents();

                    comboBoxPlan.SelectedValue = Persona.IdPlan;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar especialidad y plan: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SetPersona()
        {
            this.textId.Text = this.Persona.IdPersona.ToString();
            this.textNombre.Text = this.Persona.Nombre;
            this.textApellido.Text = this.Persona.Apellido;
            this.textDireccion.Text = this.Persona.Direccion;
            this.textEmail.Text = this.Persona.Email;
            this.textTelefono.Text = this.Persona.Telefono;
            this.pickerFechaNac.Value = this.Persona.FechaNacimiento == default ? DateTime.Today : this.Persona.FechaNacimiento;
            this.textLegajo.Text = this.Persona.Legajo > 0 ? this.Persona.Legajo.ToString() : "";
            this.comboBoxTipoPersona.SelectedValue = this.Persona.TipoPersona;

            // Configurar especialidad y plan
            if (this.Persona.IdPlan > 0)
            {
                SetEspecialidadYPlan();
            }
        }
        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                labelId.Visible = false;
                textId.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                labelId.Visible = true;
                textId.Visible = true;
                textId.ReadOnly = true;
            }
        }
        private async Task<bool> ValidatePersona()
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textEmail.Text))
            {
                MessageBox.Show("El email es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEmail.Focus();
                return false;
            }

            if (comboBoxPlan.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un plan.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxPlan.Focus();
                return false;
            }

            if (!int.TryParse(textLegajo.Text, out int legajo) || legajo <= 0)
            {
                MessageBox.Show("El legajo debe ser un número válido mayor que cero.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textLegajo.Focus();
                return false;
            }

            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (this.Mode == FormMode.Add || textEmail.Text != this.Persona.Email)
                {
                    int? excludeId = this.Mode == FormMode.Update ? this.Persona.IdPersona : null;
                    bool emailExiste = await PersonaAPIClient.ExistsEmailAsync(textEmail.Text, excludeId);

                    if (emailExiste)
                    {
                        MessageBox.Show($"Ya existe una persona con el email '{textEmail.Text}'.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textEmail.Focus();
                        return false;
                    }
                }

                if (this.Mode == FormMode.Add || legajo != this.Persona.Legajo)
                {
                    int? excludeId = this.Mode == FormMode.Update ? this.Persona.IdPersona : null;
                    bool legajoExiste = await PersonaAPIClient.ExistsLegajoAsync(legajo, excludeId);

                    if (legajoExiste)
                    {
                        MessageBox.Show($"Ya existe una persona con el legajo '{legajo}'.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textLegajo.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }

            return true;
        }
    }
}
