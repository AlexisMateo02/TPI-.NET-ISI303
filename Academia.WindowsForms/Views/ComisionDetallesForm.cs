using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class ComisionDetallesForm : Form
    {
        private ComisionDTO comision;
        private FormMode mode;
        private List<EspecialidadDTO> especialidades;
        private List<PlanDTO> planes;

        public ComisionDTO Comision
        {
            get { return comision; }
            set
            {
                comision = value;
                this.SetComision();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public ComisionDetallesForm()
        {
            InitializeComponent();
            LoadEspecialidades();
            Mode = FormMode.Add;
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


                planes = (await PlanAPIClient.GetAllAsync()).ToList();

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
                var planesFiltrados = planes.Where(p => p.IdEspecialidad == idEspecialidad)
                    .ToList();

                comboBoxPlan.DataSource = planesFiltrados;
                comboBoxPlan.DisplayMember = "Descripcion";
                comboBoxPlan.ValueMember = "IdPlan";

                if (Mode == FormMode.Update && Comision != null)
                {
                    var planActual = planesFiltrados.FirstOrDefault(p => p.IdPlan == Comision.IdPlan);
                    if (planActual != null)
                    {
                        comboBoxPlan.SelectedValue = Comision.IdPlan;
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
            if (await this.ValidateComision())
            {
                try
                {
                    this.Comision.DescripcionComision = textDescripcion.Text;
                    this.Comision.AnioEspecialidad = int.Parse(textAnioEspecialidad.Text);
                    this.Comision.IdPlan = (int)comboBoxPlan.SelectedValue;

                    if (this.Mode == FormMode.Update)
                    {
                        await ComisionAPIClient.UpdateAsync(this.Comision);
                    }
                    else
                    {
                        await ComisionAPIClient.AddAsync(this.Comision);
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
                var plan = planes?.FirstOrDefault(p => p.IdPlan == Comision.IdPlan);

                if (plan != null)
                {
                    comboBoxEspecialidad.SelectedValue = plan.IdEspecialidad;

                    // Esperar a que se actualice el combo de planes
                    Application.DoEvents();

                    comboBoxPlan.SelectedValue = Comision.IdPlan;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar especialidad y plan: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SetComision()
        {
            this.textId.Text = this.Comision.IdComision.ToString();
            this.textDescripcion.Text = this.Comision.DescripcionComision;
            this.textAnioEspecialidad.Text = this.Comision.AnioEspecialidad > 0 ? this.Comision.AnioEspecialidad.ToString() : "";

            if (this.Comision.IdPlan > 0)
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
        private async Task<bool> ValidateComision()
        {
            if (string.IsNullOrWhiteSpace(textDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textAnioEspecialidad.Text))
            {
                MessageBox.Show("El año de la especialidad es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textAnioEspecialidad.Focus();
                return false;
            }

            if (comboBoxPlan.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un plan.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxPlan.Focus();
                return false;
            }

            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                int anioEspecialidad = int.Parse(textAnioEspecialidad.Text);
                int idPlan = (int)comboBoxPlan.SelectedValue;
                int? excludeId = this.Mode == FormMode.Update ? this.Comision.IdComision : null;
                
                bool comisionExiste = await ComisionAPIClient.ExistPlanAndAnioEspecialidadAsync(anioEspecialidad, idPlan, excludeId);
                if (comisionExiste)
                {
                    MessageBox.Show($"Ya existe una comisión para el plan seleccionado en el año {anioEspecialidad}.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textAnioEspecialidad.Focus();
                    return false;
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
