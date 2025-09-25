namespace Academia.WindowsForms.Views
{
    partial class PlanDetallesForm
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
            buttonCancelar = new Button();
            buttonAceptar = new Button();
            textIdPlan = new TextBox();
            labelIdPlan = new Label();
            label1 = new Label();
            textDescripcion = new RichTextBox();
            comboBoxEspecialidad = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(596, 323);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(93, 36);
            buttonCancelar.TabIndex = 7;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(695, 323);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(93, 36);
            buttonAceptar.TabIndex = 6;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // textIdPlan
            // 
            textIdPlan.Location = new Point(720, 12);
            textIdPlan.Name = "textIdPlan";
            textIdPlan.Size = new Size(68, 23);
            textIdPlan.TabIndex = 10;
            // 
            // labelIdPlan
            // 
            labelIdPlan.AutoSize = true;
            labelIdPlan.Font = new Font("Segoe UI", 12F);
            labelIdPlan.Location = new Point(691, 14);
            labelIdPlan.Name = "labelIdPlan";
            labelIdPlan.Size = new Size(23, 21);
            labelIdPlan.TabIndex = 9;
            labelIdPlan.Text = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(17, 68);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 8;
            label1.Text = "Descripción";
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(17, 92);
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(564, 276);
            textDescripcion.TabIndex = 11;
            textDescripcion.Text = "";
            // 
            // comboBoxEspecialidad
            // 
            comboBoxEspecialidad.FormattingEnabled = true;
            comboBoxEspecialidad.Location = new Point(596, 92);
            comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            comboBoxEspecialidad.Size = new Size(192, 23);
            comboBoxEspecialidad.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(360, 23);
            label2.Name = "label2";
            label2.Size = new Size(85, 39);
            label2.TabIndex = 13;
            label2.Text = "PLAN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(596, 68);
            label3.Name = "label3";
            label3.Size = new Size(95, 21);
            label3.TabIndex = 14;
            label3.Text = "Especialidad";
            // 
            // PlanDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 378);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxEspecialidad);
            Controls.Add(textDescripcion);
            Controls.Add(textIdPlan);
            Controls.Add(labelIdPlan);
            Controls.Add(label1);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Name = "PlanDetallesForm";
            Text = "PlanDetallesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancelar;
        private Button buttonAceptar;
        private TextBox textIdPlan;
        private Label labelIdPlan;
        private Label label1;
        private RichTextBox textDescripcion;
        private ComboBox comboBoxEspecialidad;
        private Label label2;
        private Label label3;
    }
}