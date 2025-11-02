namespace Academia.WindowsForms.Views.Materia
{
    partial class MateriasForm
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
            dgvMaterias = new DataGridView();
            buttonEliminar = new Button();
            buttonModificar = new Button();
            buttonAgregar = new Button();
            buttonListar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            SuspendLayout();
            // 
            // dgvMaterias
            // 
            dgvMaterias.AllowUserToAddRows = false;
            dgvMaterias.AllowUserToDeleteRows = false;
            dgvMaterias.AllowUserToOrderColumns = true;
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Location = new Point(12, 12);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.Size = new Size(719, 325);
            dgvMaterias.TabIndex = 10;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(298, 352);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(93, 33);
            buttonEliminar.TabIndex = 14;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(408, 352);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(93, 33);
            buttonModificar.TabIndex = 13;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(520, 352);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(93, 33);
            buttonAgregar.TabIndex = 12;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(629, 352);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(93, 33);
            buttonListar.TabIndex = 11;
            buttonListar.Text = "Listar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // MateriasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(745, 399);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonListar);
            Controls.Add(dgvMaterias);
            Name = "MateriasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Materias";
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMaterias;
        private Button buttonEliminar;
        private Button buttonModificar;
        private Button buttonAgregar;
        private Button buttonListar;
    }
}