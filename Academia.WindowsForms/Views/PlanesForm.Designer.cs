namespace Academia.WindowsForms.Views
{
    partial class PlanesForm
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
            buttonListar = new Button();
            dgvPlanes = new DataGridView();
            buttonReporte = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).BeginInit();
            SuspendLayout();
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(401, 355);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(101, 33);
            buttonEliminar.TabIndex = 8;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(508, 355);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(101, 33);
            buttonModificar.TabIndex = 7;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(615, 355);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(101, 33);
            buttonAgregar.TabIndex = 6;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(829, 355);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(101, 33);
            buttonListar.TabIndex = 5;
            buttonListar.Text = "Listar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // dgvPlanes
            // 
            dgvPlanes.AllowUserToAddRows = false;
            dgvPlanes.AllowUserToDeleteRows = false;
            dgvPlanes.AllowUserToOrderColumns = true;
            dgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlanes.Location = new Point(12, 12);
            dgvPlanes.Name = "dgvPlanes";
            dgvPlanes.Size = new Size(923, 325);
            dgvPlanes.TabIndex = 9;
            // 
            // buttonReporte
            // 
            buttonReporte.Location = new Point(722, 355);
            buttonReporte.Name = "buttonReporte";
            buttonReporte.Size = new Size(101, 33);
            buttonReporte.TabIndex = 10;
            buttonReporte.Text = "Generar reporte";
            buttonReporte.UseVisualStyleBackColor = true;
            buttonReporte.Click += buttonReporte_Click;
            // 
            // PlanesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 403);
            Controls.Add(buttonReporte);
            Controls.Add(dgvPlanes);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonListar);
            Name = "PlanesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Planes";
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonEliminar;
        private Button buttonModificar;
        private Button buttonAgregar;
        private Button buttonListar;
        private DataGridView dgvPlanes;
        private Button buttonReporte;
    }
}