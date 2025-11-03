using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views.DocenteCurso
{
    public enum FormMode
    {
        Add,
        Update
    }

    public partial class DocenteCursoDetallesForm : Form
    {
        private DocenteCursoDTO docenteCurso;
        private FormMode mode;
        private List<PersonaDTO> docentes;
        private List<CursoDTO> cursos;
        public DocenteCursoDTO DocenteCurso
        {
            get { return docenteCurso; }
            set
            {
                docenteCurso = value;
                this.SetDocenteCurso();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public DocenteCursoDetallesForm()
        {
            InitializeComponent();
            LoadCargos();
            LoadDocentes();
            LoadCursos();
            Mode = FormMode.Add;
        }
        private void LoadCargos()
        {
            var cargos = new List<string>
            {
                "Titular",
                "Adjunto",
                "Ayudante"
            };

            comboBoxCargo.DataSource = cargos;
            comboBoxCargo.SelectedIndex = -1;
        }
        private async void LoadDocentes()
        {
            try
            {
                comboBoxDocente.DataSource = null;
                docentes = (await PersonaAPIClient.GetDocentesAsync()).ToList();

                comboBoxDocente.DataSource = docentes;
                comboBoxDocente.DisplayMember = "NombreCompletoYLegajoPersona";
                comboBoxDocente.ValueMember = "IdPersona";
                comboBoxDocente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar docentes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void LoadCursos()
        {
            try
            {
                comboBoxCurso.DataSource = null;
                cursos = (await CursoAPIClient.GetAllAsync()).ToList();

                comboBoxCurso.DataSource = cursos;
                comboBoxCurso.DisplayMember = "DescripcionCompleta";
                comboBoxCurso.ValueMember = "IdCurso";
                comboBoxCurso.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cursos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (await this.ValidateDocenteCurso())
            {
                try
                {
                    this.DocenteCurso.Cargo = comboBoxCargo.SelectedItem?.ToString() ?? "";
                    this.DocenteCurso.IdDocente = (int)comboBoxDocente.SelectedValue;
                    this.DocenteCurso.IdCurso = (int)comboBoxCurso.SelectedValue;

                    if (this.Mode == FormMode.Update)
                    {
                        await DocenteCursoAPIClient.UpdateAsync(this.DocenteCurso);
                    }
                    else
                    {
                        await DocenteCursoAPIClient.AddAsync(this.DocenteCurso);
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
        private void SetDocenteCurso()
        {
            this.textId.Text = this.DocenteCurso.IdDictado.ToString();
            this.comboBoxCargo.SelectedItem = this.DocenteCurso.Cargo;
            this.comboBoxDocente.SelectedValue = this.DocenteCurso.IdDocente;
            this.comboBoxCurso.SelectedValue = this.DocenteCurso.IdCurso;
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
        private async Task<bool> ValidateDocenteCurso()
        {
            if (comboBoxCargo.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBoxCargo.SelectedItem?.ToString()))
            {
                MessageBox.Show("Debe seleccionar un cargo.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCargo.Focus();
                return false;
            }

            if (comboBoxDocente.SelectedValue == null || (int)comboBoxDocente.SelectedValue <= 0)
            {
                MessageBox.Show("Debe seleccionar un docente.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxDocente.Focus();
                return false;
            }

            if (comboBoxCurso.SelectedValue == null || (int)comboBoxCurso.SelectedValue <= 0)
            {
                MessageBox.Show("Debe seleccionar un curso.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCurso.Focus();
                return false;
            }

            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                int idDocente = (int)comboBoxDocente.SelectedValue;
                int idCurso = (int)comboBoxCurso.SelectedValue;
                int? excludeId = this.Mode == FormMode.Update ? this.DocenteCurso.IdDictado : null;

                bool existeDictado = await DocenteCursoAPIClient.ExistDocenteCursoAsync(
                    idDocente, idCurso, excludeId);

                if (existeDictado)
                {
                    var docente = docentes.FirstOrDefault(d => d.IdPersona == idDocente);
                    var curso = cursos.FirstOrDefault(c => c.IdCurso == idCurso);

                    MessageBox.Show(
                        $"El docente '{docente?.NombreCompletoPersona}' ya está asignado al curso '{curso?.DescripcionMateria} - {curso?.DescripcionComision}'.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxCurso.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar dictado: {ex.Message}",
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
