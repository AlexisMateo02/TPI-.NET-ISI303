namespace Academia.ClienteServicios
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
            Id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Clave = new DataGridViewTextBoxColumn();
            Habilitado = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            buttonAgregar = new Button();
            buttonModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, Clave, Habilitado });
            dgvUsuarios.Location = new Point(89, 33);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(495, 277);
            dgvUsuarios.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Clave
            // 
            Clave.HeaderText = "Clave";
            Clave.Name = "Clave";
            Clave.ReadOnly = true;
            // 
            // Habilitado
            // 
            Habilitado.HeaderText = "Habilitado";
            Habilitado.Name = "Habilitado";
            Habilitado.ReadOnly = true;
            // 
            // button1
            // 
            button1.Location = new Point(89, 341);
            button1.Name = "button1";
            button1.Size = new Size(104, 47);
            button1.TabIndex = 1;
            button1.Text = "Listar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(339, 341);
            button2.Name = "button2";
            button2.Size = new Size(115, 47);
            button2.TabIndex = 2;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(211, 341);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(111, 47);
            buttonAgregar.TabIndex = 3;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(473, 341);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(111, 47);
            buttonModificar.TabIndex = 4;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // UsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 431);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvUsuarios);
            Name = "UsuariosForm";
            Text = "ABMUsuariosForm";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn Habilitado;
        private Button button1;
        private Button button2;
        private Button buttonAgregar;
        private Button buttonModificar;
    }
}