namespace Academia.WindowsForms.Views
{
    partial class UsuariosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvUsuarios = new DataGridView();
            buttonListar = new Button();
            buttonEliminar = new Button();
            buttonAgregar = new Button();
            buttonModificar = new Button();
            buscarTextBox = new TextBox();
            panelMiInfo = new Panel();
            buttonCambiarContrasenia = new Button();
            labelTitulo = new Label();
            groupBoxInfo = new GroupBox();
            labelLegajo = new Label();
            labelPersona = new Label();
            labelFechaAlta = new Label();
            labelEstado = new Label();
            labelRol = new Label();
            labelUsuario = new Label();
            labelUsuarioValue = new Label();
            labelFechaAltaValue = new Label();
            labelEstadoValue = new Label();
            labelPersonaValue = new Label();
            labelLegajoValue = new Label();
            labelRolValue = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            panelMiInfo.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToOrderColumns = true;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(25, 58);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(653, 277);
            dgvUsuarios.TabIndex = 0;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(593, 19);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(81, 23);
            buttonListar.TabIndex = 1;
            buttonListar.Text = "Buscar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(296, 346);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(115, 35);
            buttonEliminar.TabIndex = 2;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(563, 346);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(111, 35);
            buttonAgregar.TabIndex = 3;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(432, 346);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(111, 35);
            buttonModificar.TabIndex = 4;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(25, 19);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.Size = new Size(562, 23);
            buscarTextBox.TabIndex = 5;
            buscarTextBox.Text = "Buscar por nombre de usuario";
            // 
            // panelMiInfo
            // 
            panelMiInfo.Controls.Add(buttonCambiarContrasenia);
            panelMiInfo.Controls.Add(labelTitulo);
            panelMiInfo.Controls.Add(groupBoxInfo);
            panelMiInfo.Location = new Point(0, 2);
            panelMiInfo.Name = "panelMiInfo";
            panelMiInfo.Size = new Size(701, 390);
            panelMiInfo.TabIndex = 6;
            // 
            // buttonCambiarContrasenia
            // 
            buttonCambiarContrasenia.Location = new Point(492, 327);
            buttonCambiarContrasenia.Name = "buttonCambiarContrasenia";
            buttonCambiarContrasenia.Size = new Size(186, 41);
            buttonCambiarContrasenia.TabIndex = 18;
            buttonCambiarContrasenia.Text = "Cambiar contraseña";
            buttonCambiarContrasenia.UseVisualStyleBackColor = true;
            buttonCambiarContrasenia.Click += buttonCambiarContrasenia_Click_1;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.BorderStyle = BorderStyle.Fixed3D;
            labelTitulo.Font = new Font("Segoe UI", 20F);
            labelTitulo.Location = new Point(39, 15);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(168, 39);
            labelTitulo.TabIndex = 17;
            labelTitulo.Text = "MI USUARIO";
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.Controls.Add(labelRolValue);
            groupBoxInfo.Controls.Add(labelLegajoValue);
            groupBoxInfo.Controls.Add(labelPersonaValue);
            groupBoxInfo.Controls.Add(labelEstadoValue);
            groupBoxInfo.Controls.Add(labelFechaAltaValue);
            groupBoxInfo.Controls.Add(labelUsuarioValue);
            groupBoxInfo.Controls.Add(labelLegajo);
            groupBoxInfo.Controls.Add(labelPersona);
            groupBoxInfo.Controls.Add(labelFechaAlta);
            groupBoxInfo.Controls.Add(labelEstado);
            groupBoxInfo.Controls.Add(labelRol);
            groupBoxInfo.Controls.Add(labelUsuario);
            groupBoxInfo.Location = new Point(39, 82);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Size = new Size(623, 227);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            // 
            // labelLegajo
            // 
            labelLegajo.AutoSize = true;
            labelLegajo.Font = new Font("Segoe UI", 13F);
            labelLegajo.Location = new Point(293, 103);
            labelLegajo.Name = "labelLegajo";
            labelLegajo.Size = new Size(68, 25);
            labelLegajo.TabIndex = 5;
            labelLegajo.Text = "Legajo:";
            // 
            // labelPersona
            // 
            labelPersona.AutoSize = true;
            labelPersona.Font = new Font("Segoe UI", 13F);
            labelPersona.Location = new Point(293, 47);
            labelPersona.Name = "labelPersona";
            labelPersona.Size = new Size(78, 25);
            labelPersona.TabIndex = 4;
            labelPersona.Text = "Persona:";
            // 
            // labelFechaAlta
            // 
            labelFechaAlta.AutoSize = true;
            labelFechaAlta.Font = new Font("Segoe UI", 13F);
            labelFechaAlta.Location = new Point(28, 103);
            labelFechaAlta.Name = "labelFechaAlta";
            labelFechaAlta.Size = new Size(97, 25);
            labelFechaAlta.TabIndex = 3;
            labelFechaAlta.Text = "Fecha Alta:";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Font = new Font("Segoe UI", 13F);
            labelEstado.Location = new Point(28, 157);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(70, 25);
            labelEstado.TabIndex = 2;
            labelEstado.Text = "Estado:";
            // 
            // labelRol
            // 
            labelRol.AutoSize = true;
            labelRol.Font = new Font("Segoe UI", 13F);
            labelRol.Location = new Point(293, 157);
            labelRol.Name = "labelRol";
            labelRol.Size = new Size(41, 25);
            labelRol.TabIndex = 1;
            labelRol.Text = "Rol:";
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Font = new Font("Segoe UI", 13F);
            labelUsuario.Location = new Point(28, 47);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(76, 25);
            labelUsuario.TabIndex = 0;
            labelUsuario.Text = "Usuario:";
            // 
            // labelUsuarioValue
            // 
            labelUsuarioValue.AutoSize = true;
            labelUsuarioValue.Font = new Font("Segoe UI", 13F);
            labelUsuarioValue.Location = new Point(110, 47);
            labelUsuarioValue.Name = "labelUsuarioValue";
            labelUsuarioValue.Size = new Size(72, 25);
            labelUsuarioValue.TabIndex = 6;
            labelUsuarioValue.Text = "Usuario";
            // 
            // labelFechaAltaValue
            // 
            labelFechaAltaValue.AutoSize = true;
            labelFechaAltaValue.Font = new Font("Segoe UI", 13F);
            labelFechaAltaValue.Location = new Point(131, 103);
            labelFechaAltaValue.Name = "labelFechaAltaValue";
            labelFechaAltaValue.Size = new Size(93, 25);
            labelFechaAltaValue.TabIndex = 7;
            labelFechaAltaValue.Text = "Fecha Alta";
            // 
            // labelEstadoValue
            // 
            labelEstadoValue.AutoSize = true;
            labelEstadoValue.Font = new Font("Segoe UI", 13F);
            labelEstadoValue.Location = new Point(104, 157);
            labelEstadoValue.Name = "labelEstadoValue";
            labelEstadoValue.Size = new Size(66, 25);
            labelEstadoValue.TabIndex = 8;
            labelEstadoValue.Text = "Estado";
            // 
            // labelPersonaValue
            // 
            labelPersonaValue.AutoSize = true;
            labelPersonaValue.Font = new Font("Segoe UI", 13F);
            labelPersonaValue.Location = new Point(377, 47);
            labelPersonaValue.Name = "labelPersonaValue";
            labelPersonaValue.Size = new Size(74, 25);
            labelPersonaValue.TabIndex = 9;
            labelPersonaValue.Text = "Persona";
            // 
            // labelLegajoValue
            // 
            labelLegajoValue.AutoSize = true;
            labelLegajoValue.Font = new Font("Segoe UI", 13F);
            labelLegajoValue.Location = new Point(367, 103);
            labelLegajoValue.Name = "labelLegajoValue";
            labelLegajoValue.Size = new Size(64, 25);
            labelLegajoValue.TabIndex = 10;
            labelLegajoValue.Text = "Legajo";
            // 
            // labelRolValue
            // 
            labelRolValue.AutoSize = true;
            labelRolValue.Font = new Font("Segoe UI", 13F);
            labelRolValue.Location = new Point(340, 157);
            labelRolValue.Name = "labelRolValue";
            labelRolValue.Size = new Size(37, 25);
            labelRolValue.TabIndex = 11;
            labelRolValue.Text = "Rol";
            // 
            // UsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 392);
            Controls.Add(panelMiInfo);
            Controls.Add(buscarTextBox);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonListar);
            Controls.Add(dgvUsuarios);
            Name = "UsuariosForm";
            Text = "ABMUsuariosForm";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            panelMiInfo.ResumeLayout(false);
            panelMiInfo.PerformLayout();
            groupBoxInfo.ResumeLayout(false);
            groupBoxInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button buttonListar;
        private Button buttonEliminar;
        private Button buttonAgregar;
        private Button buttonModificar;
        private TextBox buscarTextBox;
        private Panel panelMiInfo;
        private GroupBox groupBoxInfo;
        private Label labelTitulo;
        private Label labelUsuario;
        private Label labelRol;
        private Label labelEstado;
        private Label labelFechaAlta;
        private Label labelPersona;
        private Label labelLegajo;
        private Button buttonCambiarContrasenia;
        private Label labelRolValue;
        private Label labelLegajoValue;
        private Label labelPersonaValue;
        private Label labelEstadoValue;
        private Label labelFechaAltaValue;
        private Label labelUsuarioValue;
    }
}