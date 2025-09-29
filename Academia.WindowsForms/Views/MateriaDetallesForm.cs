using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class MateriaDetallesForm : Form
    {
        private MateriaDTO materia;
        private FormMode mode;
        private List<EspecialidadDTO> especialidades;
        private List<PlanDTO> planes;
        public MateriaDTO Materia
        {
            get { return materia; }
            set
            {
                materia = value;
                this.SetMateria();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public MateriaDetallesForm()
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

                if (Mode == FormMode.Update && Materia != null)
                {
                    var planActual = planesFiltrados.FirstOrDefault(p => p.IdPlan == Materia.IdPlan);
                    if (planActual != null)
                    {
                        comboBoxPlan.SelectedValue = Materia.IdPlan;
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
            if (await this.ValidateMateria())
            {
                try
                {
                    this.Materia.DescripcionMateria = textDescripcion.Text;
                    this.Materia.HorasSemanales = int.Parse(textHorasSemanales.Text);
                    this.Materia.HorasTotales = int.Parse(textHorasTotales.Text);
                    this.Materia.IdPlan = (int)comboBoxPlan.SelectedValue;

                    if (this.Mode == FormMode.Update)
                    {
                        await MateriaAPIClient.UpdateAsync(this.Materia);
                    }
                    else
                    {
                        await MateriaAPIClient.AddAsync(this.Materia);
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
                var plan = planes?.FirstOrDefault(p => p.IdPlan == Materia.IdPlan);

                if (plan != null)
                {
                    comboBoxEspecialidad.SelectedValue = plan.IdEspecialidad;

                    // Esperar a que se actualice el combo de planes
                    Application.DoEvents();

                    comboBoxPlan.SelectedValue = Materia.IdPlan;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar especialidad y plan: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SetMateria()
        {
            this.textId.Text = this.Materia.IdMateria.ToString();
            this.textDescripcion.Text = this.Materia.DescripcionMateria;
            this.textHorasSemanales.Text = this.Materia.HorasSemanales > 0 ? this.Materia.HorasSemanales.ToString() : "";
            this.textHorasTotales.Text = this.Materia.HorasTotales > 0 ? this.Materia.HorasTotales.ToString() : "";

            if (this.Materia.IdPlan > 0)
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
        private async Task<bool> ValidateMateria()
        {
            if (string.IsNullOrWhiteSpace(textDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textHorasSemanales.Text))
            {
                MessageBox.Show("Las horas semanales son obligatorias.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textHorasSemanales.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textHorasTotales.Text))
            {
                MessageBox.Show("Las horas totales son obligatorias.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textHorasTotales.Focus();
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

                string descripcionMateria = textDescripcion.Text;
                int idPlan = (int)comboBoxPlan.SelectedValue;
                int? excludeId = this.Mode == FormMode.Update ? this.Materia.IdMateria : null;

                bool materiaExiste = await MateriaAPIClient.ExistPlanAndDescripcionMateriaAsync(idPlan, descripcionMateria, excludeId);
                if (materiaExiste)
                {
                    MessageBox.Show($"Ya existe una materia con esa descripción para el plan seleccionado.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textDescripcion.Focus();
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
