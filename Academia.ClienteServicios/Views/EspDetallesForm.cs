using Academia.Entidades;
using System.Windows.Forms;

namespace Academia.ClienteServicios.Views
{
    public partial class EspDetallesForm : Form
    {
        public Especialidad Especialidad { get; set; }
        public bool EsNuevaEspecialidad { get; set; }
        public EspDetallesForm()
        {
            InitializeComponent();
            Especialidad = new Especialidad();
            EsNuevaEspecialidad = true;
        }

        public EspDetallesForm(Especialidad especialidad)
        {
            InitializeComponent();
            Especialidad = especialidad;
            EsNuevaEspecialidad = false;
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (!EsNuevaEspecialidad && Especialidad != null)
            {
                textDesc.Text = Especialidad.DescEspecialidad;
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textDesc.Text))
            {
                MessageBox.Show("La descripción de la especialidad es obligatoria.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDesc.Focus();
                return false;
            }
            return true;
        }

        private void GuardarDatos()
        {
            Especialidad.DescEspecialidad = textDesc.Text.Trim();
        }

        private void EspDetallesForm_Load(object sender, EventArgs e)
        {
            if (EsNuevaEspecialidad)
            {
                this.Text = "Nueva Especialidad";
            }
            else
            {
                this.Text = "Editar Especialidad";
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                GuardarDatos();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
