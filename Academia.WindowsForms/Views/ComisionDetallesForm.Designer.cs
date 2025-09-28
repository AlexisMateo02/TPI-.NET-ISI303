namespace Academia.WindowsForms.Views
{
    partial class ComisionDetallesForm
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
            textAnioEspecialidad = new TextBox();
            textId = new TextBox();
            labelId = new Label();
            label2 = new Label();
            label1 = new Label();
            textDescripcion = new RichTextBox();
            label3 = new Label();
            label11 = new Label();
            label10 = new Label();
            comboBoxEspecialidad = new ComboBox();
            comboBoxPlan = new ComboBox();
            buttonCancelar = new Button();
            buttonAceptar = new Button();
            SuspendLayout();
            // 
            // textAnioEspecialidad
            // 
            textAnioEspecialidad.Location = new Point(164, 234);
            textAnioEspecialidad.Name = "textAnioEspecialidad";
            textAnioEspecialidad.Size = new Size(487, 23);
            textAnioEspecialidad.TabIndex = 22;
            // 
            // textId
            // 
            textId.Location = new Point(583, 12);
            textId.Name = "textId";
            textId.Size = new Size(68, 23);
            textId.TabIndex = 21;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 12F);
            labelId.Location = new Point(554, 14);
            labelId.Name = "labelId";
            labelId.Size = new Size(23, 21);
            labelId.TabIndex = 20;
            labelId.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(244, 9);
            label2.Name = "label2";
            label2.Size = new Size(147, 39);
            label2.TabIndex = 19;
            label2.Text = "COMISIÓN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(67, 60);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 29;
            label1.Text = "Descripción";
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(164, 60);
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(487, 158);
            textDescripcion.TabIndex = 30;
            textDescripcion.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(10, 236);
            label3.Name = "label3";
            label3.Size = new Size(148, 21);
            label3.TabIndex = 31;
            label3.Text = "Año de Especialidad";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(407, 276);
            label11.Name = "label11";
            label11.Size = new Size(40, 21);
            label11.TabIndex = 44;
            label11.Text = "Plan";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(63, 276);
            label10.Name = "label10";
            label10.Size = new Size(95, 21);
            label10.TabIndex = 43;
            label10.Text = "Especialidad";
            // 
            // comboBoxEspecialidad
            // 
            comboBoxEspecialidad.FormattingEnabled = true;
            comboBoxEspecialidad.Location = new Point(164, 274);
            comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            comboBoxEspecialidad.Size = new Size(198, 23);
            comboBoxEspecialidad.TabIndex = 42;
            comboBoxEspecialidad.SelectedIndexChanged += comboBoxEspecialidad_SelectedValueChanged;
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.FormattingEnabled = true;
            comboBoxPlan.Location = new Point(453, 274);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(198, 23);
            comboBoxPlan.TabIndex = 41;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(558, 345);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(93, 36);
            buttonCancelar.TabIndex = 46;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(459, 345);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(93, 36);
            buttonAceptar.TabIndex = 45;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // ComisionDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 393);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(comboBoxEspecialidad);
            Controls.Add(comboBoxPlan);
            Controls.Add(label3);
            Controls.Add(textDescripcion);
            Controls.Add(label1);
            Controls.Add(textAnioEspecialidad);
            Controls.Add(textId);
            Controls.Add(labelId);
            Controls.Add(label2);
            Name = "ComisionDetallesForm";
            Text = "ComisionDetallesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textAnioEspecialidad;
        private TextBox textId;
        private Label labelId;
        private Label label2;
        private Label label1;
        private RichTextBox textDescripcion;
        private Label label3;
        private Label label11;
        private Label label10;
        private ComboBox comboBoxEspecialidad;
        private ComboBox comboBoxPlan;
        private Button buttonCancelar;
        private Button buttonAceptar;
    }
}