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
            this.Hide();
            using (UsuariosForm form = new UsuariosForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void buttonEspecialidad_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (EspecialidadesForm form = new EspecialidadesForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }
    }
}
