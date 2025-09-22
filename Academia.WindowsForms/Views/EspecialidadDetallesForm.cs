using Academia.Entidades;
using APIClients;
using DTOs;

namespace Academia.WindowsForms.Views
{
    public partial class EspecialidadDetallesForm : Form
    {
        private EspecialidadDTO especialidad;
        private FormMode mode;
        public EspecialidadDTO Especialidad
        {
            get { return especialidad; }
            set
            {
                especialidad = value;
                this.SetEspecialidad();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public EspecialidadDetallesForm()
        {
            InitializeComponent();
            Mode = FormMode.Add;
        }

        private async void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (await this.ValidateEspecialidad())
            {
                try
                {
                    this.Especialidad.Descripcion = textDescripcion.Text;

                    if (this.Mode == FormMode.Update)
                    {
                        await EspecialidadAPIClient.UpdateAsync(this.Especialidad);
                    }
                    else
                    {
                        await EspecialidadAPIClient.AddAsync(this.Especialidad);
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

        private void SetEspecialidad()
        {
            this.textId.Text = this.Especialidad.Id.ToString();
            this.textDescripcion.Text = this.Especialidad.Descripcion;
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
        private async Task<bool> ValidateEspecialidad()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(textDescripcion.Text))
            {
                MessageBox.Show("La descripcion de la especialidad es obligatoria.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDescripcion.Focus();
                isValid = false;
            }
            return isValid;
        }
    }
}
