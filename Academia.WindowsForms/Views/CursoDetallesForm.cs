using Academia.Entidades;
using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class CursoDetallesForm : Form
    {
        private CursoDTO curso;
        private FormMode mode;
        private List<ComisionDTO> comisiones;
        private List<MateriaDTO> materias;
        public CursoDTO Curso
        {
            get { return curso; }
            set
            {
                curso = value;
                this.SetCurso();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public CursoDetallesForm()
        {
            InitializeComponent();
            LoadComisiones();
            LoadMaterias();
            Mode = FormMode.Add;
        }
        private async void LoadComisiones()
        {
            try
            {
                comboBoxComision.DataSource = null;
                comisiones = (await ComisionAPIClient.GetAllAsync()).ToList();
                comboBoxComision.DataSource = comisiones;
                comboBoxComision.DisplayMember = "DescripcionComision";
                comboBoxComision.ValueMember = "IdComision";
                comboBoxComision.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar comisiones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void LoadMaterias()
        {
            try
            {
                comboBoxMateria.DataSource = null;
                materias = (await MateriaAPIClient.GetAllAsync()).ToList();
                comboBoxMateria.DataSource = materias;
                comboBoxMateria.DisplayMember = "DescripcionMateria";
                comboBoxMateria.ValueMember = "IdMateria";
                comboBoxMateria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (await this.ValidateCurso())
            {
                try
                {
                    this.Curso.AnioCalendario = int.Parse(textAnioCalendario.Text);
                    this.Curso.Cupo = int.Parse(textCupo.Text);
                    this.Curso.IdComision = (int)comboBoxComision.SelectedValue;
                    this.Curso.IdMateria = (int)comboBoxMateria.SelectedValue;

                    if (this.Mode == FormMode.Update)
                    {
                        await CursoAPIClient.UpdateAsync(this.Curso);
                    }
                    else
                    {
                        await CursoAPIClient.AddAsync(this.Curso);
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
        private void SetCurso()
        {
            this.textId.Text = this.Curso.IdCurso.ToString();
            this.textAnioCalendario.Text = this.Curso.AnioCalendario > 0 ? this.Curso.AnioCalendario.ToString() : "";
            this.textCupo.Text = this.Curso.Cupo > 0 ? this.Curso.Cupo.ToString() : "";
            this.comboBoxComision.SelectedValue = this.Curso.IdComision;
            this.comboBoxMateria.SelectedValue = this.Curso.IdMateria;
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
        private async Task<bool> ValidateCurso()
        {
            if (string.IsNullOrWhiteSpace(textAnioCalendario.Text))
            {
                MessageBox.Show("El año del calendario es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textAnioCalendario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textCupo.Text))
            {
                MessageBox.Show("El cupo es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCupo.Focus();
                return false;
            }

            if (comboBoxComision.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una comisión.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxComision.Focus();
                return false;
            }

            if (comboBoxMateria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una materia.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMateria.Focus();
                return false;
            }

            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                int anioCalendario = int.Parse(textAnioCalendario.Text);
                int idComision = (int)comboBoxComision.SelectedValue;
                int idMateria = (int)comboBoxMateria.SelectedValue;
                int? excludeId = this.Mode == FormMode.Update ? this.Curso.IdCurso : null;

                bool cursoExiste = await CursoAPIClient.ExistComisionMateriaAndAnioCalendarioAsync(
                    idComision, idMateria, anioCalendario, excludeId);

                if (cursoExiste)
                {
                    MessageBox.Show($"Ya existe un curso en el año {anioCalendario} en la comisión y materia seleccionada.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textAnioCalendario.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar curso: {ex.Message}",
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
