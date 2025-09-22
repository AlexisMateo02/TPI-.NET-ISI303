using DTOs;
using APIClients;

namespace Academia.WindowsForms.Views
{
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
            ConfigurarBusqueda();
        }

        private void ConfigurarColumnas()
        {
            this.dgvUsuarios.AutoGenerateColumns = false;

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Width = 80
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 200
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Clave",
                HeaderText = "Clave",
                DataPropertyName = "Clave",
                Width = 200,
                Visible = false
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Habilitado",
                HeaderText = "Habilitado",
                DataPropertyName = "Habilitado",
                Width = 100
            });

            this.dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaAlta",
                HeaderText = "Fecha Alta",
                DataPropertyName = "FechaAlta",
                Width = 250,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm:ss"
                }
            });
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            string texto = this.buscarTextBox.Text.Trim();
            if (texto == "Buscar por nombre de usuario")
            {
                texto = "";
            }
            this.GetByCriteriaAndLoad(texto);
        }

        private async void EliminarUsuarioSeleccionado()
        {
            UsuarioDTO usuarioExistente = this.SelectedItem();

            if (usuarioExistente == null)
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombreUsuario = usuarioExistente.Nombre;

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el usuario '{nombreUsuario}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await UsuarioAPIClient.DeleteAsync(usuarioExistente.Id);
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetByCriteriaAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuarioSeleccionado();
        }

        private void CreateUsuario()
        {
            try
            {
                UsuarioDetallesForm usuarioDetalles = new UsuarioDetallesForm();
                UsuarioDTO usuarioNuevo = new UsuarioDTO();
                usuarioDetalles.Mode = FormMode.Add;
                usuarioDetalles.Usuario = usuarioNuevo;
                {
                    if (usuarioDetalles.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Usuario creado exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.GetByCriteriaAndLoad();
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
        }

        private async void EditarUsuarioSeleccionado()
        {
            UsuarioDTO usuarioExistente = this.SelectedItem();

            if (usuarioExistente == null)
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = usuarioExistente.Id;
                UsuarioDetallesForm usuarioDetalles = new UsuarioDetallesForm();
                UsuarioDTO usuarioAModificar = await UsuarioAPIClient.GetAsync(idExistente);
                usuarioDetalles.Mode = FormMode.Update;
                usuarioDetalles.Usuario = usuarioAModificar;
                if (usuarioDetalles.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.GetByCriteriaAndLoad();
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


        private UsuarioDTO SelectedItem()
        {
            if (dgvUsuarios.SelectedRows.Count > 0 &&
                dgvUsuarios.SelectedRows[0].DataBoundItem != null)
            {
                return (UsuarioDTO)dgvUsuarios.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

        private async void GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                this.dgvUsuarios.DataSource = null;

                IEnumerable<UsuarioDTO> usuarios;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    usuarios = await UsuarioAPIClient.GetAllAsync();
                }
                else
                {
                    usuarios = await UsuarioAPIClient.GetByCriteriaAsync(texto);
                }

                this.dgvUsuarios.DataSource = usuarios;

                if (this.dgvUsuarios.Rows.Count > 0)
                {
                    this.dgvUsuarios.Rows[0].Selected = true;
                    this.buttonEliminar.Enabled = true;
                    this.buttonModificar.Enabled = true;
                }
                else
                {
                    this.buttonEliminar.Enabled = false;
                    this.buttonModificar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonEliminar.Enabled = false;
                this.buttonModificar.Enabled = false;
            }
        }

        private void ConfigurarBusqueda()
        {
            buscarTextBox.Text = "Buscar por nombre de usuario";
            buscarTextBox.ForeColor = SystemColors.GrayText;
            buscarTextBox.Enter += BuscarTextBox_Enter;
            buscarTextBox.Leave += BuscarTextBox_Leave;
        }

        private void BuscarTextBox_Enter(object sender, EventArgs e)
        {
            if (buscarTextBox.Text == "Buscar por nombre de usuario")
            {
                buscarTextBox.Text = "";
                buscarTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void BuscarTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(buscarTextBox.Text))
            {
                buscarTextBox.Text = "Buscar por nombre de usuario";
                buscarTextBox.ForeColor = SystemColors.GrayText;
            }
        }
    }
}