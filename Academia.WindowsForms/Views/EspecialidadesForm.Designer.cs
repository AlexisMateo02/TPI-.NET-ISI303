namespace Academia.WindowsForms.Views
{
    partial class EspecialidadesForm
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
            dgvEspecialidades = new DataGridView();
            buttonListar = new Button();
            buttonAgregar = new Button();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).BeginInit();
            SuspendLayout();
            // 
            // dgvEspecialidades
            // 
            dgvEspecialidades.AllowUserToAddRows = false;
            dgvEspecialidades.AllowUserToDeleteRows = false;
            dgvEspecialidades.AllowUserToOrderColumns = true;
            dgvEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEspecialidades.Location = new Point(12, 12);
            dgvEspecialidades.Name = "dgvEspecialidades";
            dgvEspecialidades.Size = new Size(701, 325);
            dgvEspecialidades.TabIndex = 0;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(609, 355);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(93, 33);
            buttonListar.TabIndex = 1;
            buttonListar.Text = "Listar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(497, 355);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(93, 33);
            buttonAgregar.TabIndex = 2;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(385, 355);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(93, 33);
            buttonModificar.TabIndex = 3;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(275, 355);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(93, 33);
            buttonEliminar.TabIndex = 4;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // EspecialidadesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 401);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonListar);
            Controls.Add(dgvEspecialidades);
            Name = "EspecialidadesForm";
            Text = "EspecialidadesForm";
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEspecialidades;
        private Button buttonListar;
        private Button buttonAgregar;
        private Button buttonModificar;
        private Button buttonEliminar;
    }
}