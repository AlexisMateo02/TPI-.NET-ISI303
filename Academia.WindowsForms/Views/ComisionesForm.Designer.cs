namespace Academia.WindowsForms.Views
{
    partial class ComisionesForm
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
            dgvComisiones = new DataGridView();
            buttonListar = new Button();
            buttonEliminar = new Button();
            buttonModificar = new Button();
            buttonAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvComisiones).BeginInit();
            SuspendLayout();
            // 
            // dgvComisiones
            // 
            dgvComisiones.AllowUserToAddRows = false;
            dgvComisiones.AllowUserToDeleteRows = false;
            dgvComisiones.AllowUserToOrderColumns = true;
            dgvComisiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComisiones.Location = new Point(12, 12);
            dgvComisiones.Name = "dgvComisiones";
            dgvComisiones.ReadOnly = true;
            dgvComisiones.Size = new Size(660, 277);
            dgvComisiones.TabIndex = 1;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(488, 295);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(120, 33);
            buttonListar.TabIndex = 15;
            buttonListar.Text = "Listar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(82, 295);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(120, 32);
            buttonEliminar.TabIndex = 14;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(218, 295);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(120, 33);
            buttonModificar.TabIndex = 13;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(353, 295);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(120, 33);
            buttonAgregar.TabIndex = 12;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // ComisionesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 339);
            Controls.Add(buttonListar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(dgvComisiones);
            Name = "ComisionesForm";
            Text = "ComisionesForm";
            ((System.ComponentModel.ISupportInitialize)dgvComisiones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvComisiones;
        private Button buttonListar;
        private Button buttonEliminar;
        private Button buttonModificar;
        private Button buttonAgregar;
    }
}