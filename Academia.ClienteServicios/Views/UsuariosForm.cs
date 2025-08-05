using Academia.ClienteServicios.Views;
using Academia.Entidades;
using Academia.Negocio;

namespace Academia.ClienteServicios
{
    public partial class UsuariosForm : Form
    {
        private UsuarioControlador usuarioControlador;
        private Usuarios usuarios;

        public UsuariosForm()
        {
            InitializeComponent();
            usuarioControlador = new UsuarioControlador();
            usuarios = new Usuarios();
        }

        private async void GetUsuarios()
        {
            dgvUsuarios.Rows.Clear();

            try
            {
                usuarios = await UsuarioControlador.GetAll();

                if (usuarios != null)
                {
                    foreach (var usuario in usuarios?.ListaUsuarios!)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvUsuarios);
                        row.Cells[0].Value = usuario.IdUsuario;
                        row.Cells[1].Value = usuario.NombreUsuario;
                        row.Cells[2].Value = usuario.Clave;
                        row.Cells[3].Value = usuario.Habilitado ? "Sí" : "No";
                        row.Tag = usuario;
                        dgvUsuarios.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron usuarios.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetUsuarios();
        }

        private async void EliminarUsuarioSeleccionado()
        {
            Usuario usuarioExistente = this.SelectedItem();

            if (usuarioExistente == null)
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombreUsuario = usuarioExistente.NombreUsuario;

                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el usuario '{nombreUsuario}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    bool eliminado = await UsuarioControlador.Delete(usuarioExistente.IdUsuario);

                    if (eliminado)
                    {
                        MessageBox.Show("Usuario eliminado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GetUsuarios();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarUsuarioSeleccionado();
        }

        private async void CreateUsuario()
        {
            try
            {
                using (UsuariosDetallesForm detallesForm = new UsuariosDetallesForm())
                {
                    if (detallesForm.ShowDialog() == DialogResult.OK)
                    {
                        Usuario nuevoUsuario = detallesForm.Usuario;
                        bool creado = await UsuarioControlador.Create(nuevoUsuario);

                        if (creado)
                        {
                            MessageBox.Show("Usuario creado exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CreateUsuario();
            GetUsuarios();
        }

        private async void EditarUsuarioSeleccionado()
        {
            Usuario usuarioExistente = this.SelectedItem();

            if (usuarioExistente == null)
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (UsuariosDetallesForm detallesForm = new UsuariosDetallesForm(usuarioExistente))
                {
                    if (detallesForm.ShowDialog() == DialogResult.OK)
                    {
                        Usuario usuarioModificado = detallesForm.Usuario;
                        bool actualizado = await UsuarioControlador.Update(usuarioModificado);

                        if (actualizado)
                        {
                            MessageBox.Show("Usuario actualizado exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetUsuarios();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonModificar_Click(object sender, EventArgs e)
        {
            EditarUsuarioSeleccionado();
        }


        private Usuario SelectedItem()
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                return (Usuario)dgvUsuarios.SelectedRows[0].Tag;
            }
            else
            {
                return null;
            }
        }
    }
}