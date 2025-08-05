using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.ClienteServicios.Views
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
