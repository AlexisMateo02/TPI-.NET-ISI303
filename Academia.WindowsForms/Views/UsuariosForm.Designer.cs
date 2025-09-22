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
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
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
            dgvUsuarios.Size = new Size(692, 277);
            dgvUsuarios.TabIndex = 0;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(627, 19);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(81, 23);
            buttonListar.TabIndex = 1;
            buttonListar.Text = "Buscar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(330, 351);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(115, 47);
            buttonEliminar.TabIndex = 2;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(597, 351);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(111, 47);
            buttonAgregar.TabIndex = 3;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(466, 351);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(111, 47);
            buttonModificar.TabIndex = 4;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(25, 19);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.Size = new Size(587, 23);
            buscarTextBox.TabIndex = 5;
            buscarTextBox.Text = "Buscar por nombre de usuario";
            // 
            // UsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 422);
            Controls.Add(buscarTextBox);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonListar);
            Controls.Add(dgvUsuarios);
            Name = "UsuariosForm";
            Text = "ABMUsuariosForm";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
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
    }
}