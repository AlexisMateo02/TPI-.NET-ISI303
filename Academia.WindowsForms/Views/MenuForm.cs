namespace Academia.WindowsForms.Views
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void buttonUsuario_Click(object sender, EventArgs e)
        {
            using (UsuariosForm form = new UsuariosForm())
            {
                form.ShowDialog();
            }
        }

        private void buttonEspecialidad_Click(object sender, EventArgs e)
        {
            using (EspecialidadesForm form = new EspecialidadesForm())
            {
                form.ShowDialog();
            }
        }
    }
}
