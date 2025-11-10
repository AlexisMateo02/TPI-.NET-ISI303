namespace Academia.WindowsForms.Views.AlumnoInscripcion
{
    partial class InscripcionesForm
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
            dgvInscripciones = new DataGridView();
            buttonCalificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            SuspendLayout();
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(12, 407);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(162, 33);
            buttonEliminar.TabIndex = 17;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(180, 407);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(162, 33);
            buttonModificar.TabIndex = 16;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(348, 407);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(162, 33);
            buttonAgregar.TabIndex = 15;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(516, 407);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(160, 33);
            buttonListar.TabIndex = 14;
            buttonListar.Text = "Listar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // dgvInscripciones
            // 
            dgvInscripciones.AllowUserToAddRows = false;
            dgvInscripciones.AllowUserToDeleteRows = false;
            dgvInscripciones.AllowUserToOrderColumns = true;
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Location = new Point(12, 12);
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.Size = new Size(831, 382);
            dgvInscripciones.TabIndex = 13;
            // 
            // buttonCalificar
            // 
            buttonCalificar.Location = new Point(682, 407);
            buttonCalificar.Name = "buttonCalificar";
            buttonCalificar.Size = new Size(161, 33);
            buttonCalificar.TabIndex = 18;
            buttonCalificar.Text = "Calificar";
            buttonCalificar.UseVisualStyleBackColor = true;
            buttonCalificar.Click += buttonCalificar_Click;
            // 
            // InscripcionesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 452);
            Controls.Add(buttonCalificar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonListar);
            Controls.Add(dgvInscripciones);
            Name = "InscripcionesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscripciones";
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonEliminar;
        private Button buttonModificar;
        private Button buttonAgregar;
        private Button buttonListar;
        private DataGridView dgvInscripciones;
        private Button buttonCalificar;
    }
}