namespace Academia.WindowsForms.Views
{
    partial class MateriaDetallesForm
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
            textId = new TextBox();
            labelId = new Label();
            label2 = new Label();
            buttonCancelar = new Button();
            buttonAceptar = new Button();
            textDescripcion = new RichTextBox();
            label1 = new Label();
            textHorasSemanales = new TextBox();
            textHorasTotales = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label11 = new Label();
            label10 = new Label();
            comboBoxEspecialidad = new ComboBox();
            comboBoxPlan = new ComboBox();
            SuspendLayout();
            // 
            // textId
            // 
            textId.Location = new Point(556, 14);
            textId.Name = "textId";
            textId.Size = new Size(68, 23);
            textId.TabIndex = 23;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 12F);
            labelId.Location = new Point(527, 16);
            labelId.Name = "labelId";
            labelId.Size = new Size(23, 21);
            labelId.TabIndex = 22;
            labelId.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(260, 9);
            label2.Name = "label2";
            label2.Size = new Size(126, 39);
            label2.TabIndex = 24;
            label2.Text = "MATERIA";
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(531, 402);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(93, 36);
            buttonCancelar.TabIndex = 48;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(432, 402);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(93, 36);
            buttonAceptar.TabIndex = 47;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(148, 66);
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(487, 158);
            textDescripcion.TabIndex = 50;
            textDescripcion.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(51, 66);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 49;
            label1.Text = "Descripción";
            // 
            // textHorasSemanales
            // 
            textHorasSemanales.Location = new Point(148, 239);
            textHorasSemanales.Name = "textHorasSemanales";
            textHorasSemanales.Size = new Size(487, 23);
            textHorasSemanales.TabIndex = 51;
            // 
            // textHorasTotales
            // 
            textHorasTotales.Location = new Point(148, 275);
            textHorasTotales.Name = "textHorasTotales";
            textHorasTotales.Size = new Size(487, 23);
            textHorasTotales.TabIndex = 52;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 239);
            label3.Name = "label3";
            label3.Size = new Size(130, 21);
            label3.TabIndex = 53;
            label3.Text = "Horas Semanales";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(40, 275);
            label4.Name = "label4";
            label4.Size = new Size(102, 21);
            label4.TabIndex = 54;
            label4.Text = "Horas Totales";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(391, 313);
            label11.Name = "label11";
            label11.Size = new Size(40, 21);
            label11.TabIndex = 58;
            label11.Text = "Plan";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(47, 313);
            label10.Name = "label10";
            label10.Size = new Size(95, 21);
            label10.TabIndex = 57;
            label10.Text = "Especialidad";
            // 
            // comboBoxEspecialidad
            // 
            comboBoxEspecialidad.FormattingEnabled = true;
            comboBoxEspecialidad.Location = new Point(148, 313);
            comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            comboBoxEspecialidad.Size = new Size(198, 23);
            comboBoxEspecialidad.TabIndex = 56;
            comboBoxEspecialidad.SelectedIndexChanged += comboBoxEspecialidad_SelectedValueChanged;
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.FormattingEnabled = true;
            comboBoxPlan.Location = new Point(437, 313);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(198, 23);
            comboBoxPlan.TabIndex = 55;
            // 
            // MateriaDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 450);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(comboBoxEspecialidad);
            Controls.Add(comboBoxPlan);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textHorasTotales);
            Controls.Add(textHorasSemanales);
            Controls.Add(textDescripcion);
            Controls.Add(label1);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(label2);
            Controls.Add(textId);
            Controls.Add(labelId);
            Name = "MateriaDetallesForm";
            Text = "MateriaDetallesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textId;
        private Label labelId;
        private Label label2;
        private Button buttonCancelar;
        private Button buttonAceptar;
        private RichTextBox textDescripcion;
        private Label label1;
        private TextBox textHorasSemanales;
        private TextBox textHorasTotales;
        private Label label3;
        private Label label4;
        private Label label11;
        private Label label10;
        private ComboBox comboBoxEspecialidad;
        private ComboBox comboBoxPlan;
    }
}