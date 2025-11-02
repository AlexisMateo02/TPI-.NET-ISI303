namespace Academia.WindowsForms.Views.Curso
{
    partial class CursosForm
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
            dgvCursos = new DataGridView();
            buttonListar = new Button();
            buttonEliminar = new Button();
            buttonModificar = new Button();
            buttonAgregar = new Button();
            buttonReporte = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            SuspendLayout();
            // 
            // dgvCursos
            // 
            dgvCursos.AllowUserToAddRows = false;
            dgvCursos.AllowUserToDeleteRows = false;
            dgvCursos.AllowUserToOrderColumns = true;
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location = new Point(12, 12);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.Size = new Size(665, 310);
            dgvCursos.TabIndex = 6;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(475, 341);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(95, 33);
            buttonListar.TabIndex = 19;
            buttonListar.Text = "Listar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(172, 341);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(95, 33);
            buttonEliminar.TabIndex = 18;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(273, 341);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(95, 33);
            buttonModificar.TabIndex = 17;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(374, 341);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(95, 33);
            buttonAgregar.TabIndex = 16;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonReporte
            // 
            buttonReporte.Location = new Point(576, 341);
            buttonReporte.Name = "buttonReporte";
            buttonReporte.Size = new Size(101, 33);
            buttonReporte.TabIndex = 20;
            buttonReporte.Text = "Generar Reporte";
            buttonReporte.UseVisualStyleBackColor = true;
            buttonReporte.Click += buttonReporte_Click;
            // 
            // CursosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 386);
            Controls.Add(buttonReporte);
            Controls.Add(buttonListar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(dgvCursos);
            Name = "CursosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cursos";
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCursos;
        private Button buttonListar;
        private Button buttonEliminar;
        private Button buttonModificar;
        private Button buttonAgregar;
        private Button buttonReporte;
    }
}