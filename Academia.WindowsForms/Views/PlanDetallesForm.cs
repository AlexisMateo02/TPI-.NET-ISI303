using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class PlanDetallesForm : Form
    {
        private PlanDTO plan;
        private FormMode mode;
        private List<EspecialidadDTO> especialidades;
        public PlanDTO Plan
        {
            get { return plan; }
            set
            {
                plan = value;
                this.SetPlan();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public PlanDetallesForm()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (await this.ValidatePlan())
            {
                try
                {
                    this.Plan.Descripcion = textDescripcion.Text;
                    this.Plan.IdEspecialidad = (int)comboBoxEspecialidad.SelectedValue;

                    if (this.Mode == FormMode.Update)
                    {
                        await PlanAPIClient.UpdateAsync(this.Plan);
                    }
                    else
                    {
                        await PlanAPIClient.AddAsync(this.Plan);
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

        private void SetPlan()
        {
            this.textIdPlan.Text = this.Plan.IdPlan.ToString();
            this.textDescripcion.Text = this.Plan.Descripcion;
            this.comboBoxEspecialidad.SelectedValue = this.Plan.IdEspecialidad;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                labelIdPlan.Visible = false;
                textIdPlan.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                labelIdPlan.Visible = true;
                textIdPlan.Visible = true;
                textIdPlan.ReadOnly = true;
            }
        }

        private async Task<bool> ValidatePlan()
        {
            if (string.IsNullOrWhiteSpace(textDescripcion.Text))
            {
                MessageBox.Show("La descripción del plan es obligatoria.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDescripcion.Focus();
                return false;
            }

            if (comboBoxEspecialidad.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxEspecialidad.Focus();
                return false;
            }

            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                int idEspecialidad = (int)comboBoxEspecialidad.SelectedValue;
                int? excludeId = this.Mode == FormMode.Update ? this.Plan.IdPlan : null;

                bool descripcionExiste = await PlanAPIClient.ExistsDescripcionInEspecialidadAsync(
                    textDescripcion.Text, idEspecialidad, excludeId);

                if (descripcionExiste)
                {
                    MessageBox.Show($"Ya existe un plan con la descripción '{textDescripcion.Text}' en la especialidad seleccionada.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textDescripcion.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar descripción del plan: {ex.Message}",
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
