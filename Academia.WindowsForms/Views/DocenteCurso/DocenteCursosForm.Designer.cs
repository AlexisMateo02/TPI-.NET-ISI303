namespace Academia.WindowsForms.Views.DocenteCurso
{
    partial class DocenteCursosForm
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
            dgvDocenteCursos = new DataGridView();
            buttonEliminar = new Button();
            buttonModificar = new Button();
            buttonAgregar = new Button();
            buttonListar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDocenteCursos).BeginInit();
            SuspendLayout();
            // 
            // dgvDocenteCursos
            // 
            dgvDocenteCursos.AllowUserToAddRows = false;
            dgvDocenteCursos.AllowUserToDeleteRows = false;
            dgvDocenteCursos.AllowUserToOrderColumns = true;
            dgvDocenteCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDocenteCursos.Location = new Point(12, 12);
            dgvDocenteCursos.Name = "dgvDocenteCursos";
            dgvDocenteCursos.Size = new Size(733, 382);
            dgvDocenteCursos.TabIndex = 0;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(323, 410);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(101, 33);
            buttonEliminar.TabIndex = 12;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(430, 411);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(101, 33);
            buttonModificar.TabIndex = 11;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(537, 411);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(101, 33);
            buttonAgregar.TabIndex = 10;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(644, 410);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(101, 33);
            buttonListar.TabIndex = 9;
            buttonListar.Text = "Listar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // DocenteCursosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 455);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonListar);
            Controls.Add(dgvDocenteCursos);
            Name = "DocenteCursosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dictados";
            ((System.ComponentModel.ISupportInitialize)dgvDocenteCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDocenteCursos;
        private Button buttonEliminar;
        private Button buttonModificar;
        private Button buttonAgregar;
        private Button buttonListar;
    }
}