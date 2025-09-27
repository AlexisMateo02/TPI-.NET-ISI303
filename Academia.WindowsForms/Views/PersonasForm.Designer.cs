namespace Academia.WindowsForms.Views
{
    partial class PersonasForm
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
            buttonEliminar = new Button();
            buttonModificar = new Button();
            buttonAgregar = new Button();
            buttonListarAlumnos = new Button();
            dgvPersonas = new DataGridView();
            buttonListarDocentes = new Button();
            buttonListar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            SuspendLayout();
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(831, 294);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(149, 33);
            buttonEliminar.TabIndex = 9;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(831, 240);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(149, 33);
            buttonModificar.TabIndex = 8;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(831, 188);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(149, 33);
            buttonAgregar.TabIndex = 7;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonListarAlumnos
            // 
            buttonListarAlumnos.Location = new Point(831, 85);
            buttonListarAlumnos.Name = "buttonListarAlumnos";
            buttonListarAlumnos.Size = new Size(149, 33);
            buttonListarAlumnos.TabIndex = 6;
            buttonListarAlumnos.Text = "Listar Alumnos";
            buttonListarAlumnos.UseVisualStyleBackColor = true;
            buttonListarAlumnos.Click += buttonListarAlumnos_Click;
            // 
            // dgvPersonas
            // 
            dgvPersonas.AllowUserToAddRows = false;
            dgvPersonas.AllowUserToDeleteRows = false;
            dgvPersonas.AllowUserToOrderColumns = true;
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Location = new Point(12, 12);
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.Size = new Size(799, 341);
            dgvPersonas.TabIndex = 5;
            // 
            // buttonListarDocentes
            // 
            buttonListarDocentes.Location = new Point(831, 137);
            buttonListarDocentes.Name = "buttonListarDocentes";
            buttonListarDocentes.Size = new Size(149, 33);
            buttonListarDocentes.TabIndex = 10;
            buttonListarDocentes.Text = "Listar Docentes";
            buttonListarDocentes.UseVisualStyleBackColor = true;
            buttonListarDocentes.Click += buttonListarDocentes_Click;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(831, 33);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(149, 33);
            buttonListar.TabIndex = 11;
            buttonListar.Text = "Listar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // PersonasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 367);
            Controls.Add(buttonListar);
            Controls.Add(buttonListarDocentes);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonListarAlumnos);
            Controls.Add(dgvPersonas);
            Name = "PersonasForm";
            Text = "PersonasForm";
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonEliminar;
        private Button buttonModificar;
        private Button buttonAgregar;
        private Button buttonListarAlumnos;
        private DataGridView dgvPersonas;
        private Button buttonListarDocentes;
        private Button buttonListar;
    }
}