using Academia.Entidades;
using System.Windows.Forms;

namespace Academia.WindowsForms.Views
{
    public partial class UsuariosDetallesForm : Form
    {
        public Usuario Usuario { get; set; }
        public bool EsNuevoUsuario { get; set; }
        public UsuariosDetallesForm()
        {
            InitializeComponent();
            Usuario = new Usuario();
            EsNuevoUsuario = true;
        }
        public UsuariosDetallesForm(Usuario usuario)
        {
            InitializeComponent();
            Usuario = usuario;
            EsNuevoUsuario = false;
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (!EsNuevoUsuario && Usuario != null)
            {
                textNombre.Text = Usuario.NombreUsuario;
                textClave.Text = Usuario.Clave;
                checkHabilitado.Checked = Usuario.Habilitado;
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textClave.Text))
            {
                MessageBox.Show("La clave es obligatoria.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textClave.Focus();
                return false;
            }
            if (textClave.Text.Length < 4)
            {
                MessageBox.Show("La clave debe tener al menos 4 caracteres.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textClave.Focus();
                return false;
            }
            return true;
        }

        private void GuardarDatos()
        {
            Usuario.NombreUsuario = textNombre.Text.Trim();
            Usuario.Clave = textClave.Text;
            Usuario.Habilitado = checkHabilitado.Checked;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                GuardarDatos();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UsuariosDetallesForm_Load(object sender, EventArgs e)
        {
            if (EsNuevoUsuario)
            {
                this.Text = "Nuevo Usuario";
                checkHabilitado.Checked = true;
            }
            else
            {
                this.Text = "Editar Usuario";
            }
        }
    }
}
