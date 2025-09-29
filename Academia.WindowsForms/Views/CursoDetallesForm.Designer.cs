namespace Academia.WindowsForms.Views
{
    partial class CursoDetallesForm
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
            label2 = new Label();
            textId = new TextBox();
            labelId = new Label();
            buttonCancelar = new Button();
            buttonAceptar = new Button();
            textAnioCalendario = new TextBox();
            label1 = new Label();
            textCupo = new TextBox();
            label3 = new Label();
            comboBoxComision = new ComboBox();
            label4 = new Label();
            comboBoxMateria = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(334, 9);
            label2.Name = "label2";
            label2.Size = new Size(105, 39);
            label2.TabIndex = 16;
            label2.Text = "CURSO";
            // 
            // textId
            // 
            textId.Location = new Point(709, 12);
            textId.Name = "textId";
            textId.Size = new Size(68, 23);
            textId.TabIndex = 23;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 12F);
            labelId.Location = new Point(680, 14);
            labelId.Name = "labelId";
            labelId.Size = new Size(23, 21);
            labelId.TabIndex = 22;
            labelId.Text = "Id";
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(684, 185);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(93, 36);
            buttonCancelar.TabIndex = 25;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(585, 185);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(93, 36);
            buttonAceptar.TabIndex = 24;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // textAnioCalendario
            // 
            textAnioCalendario.Location = new Point(156, 64);
            textAnioCalendario.Name = "textAnioCalendario";
            textAnioCalendario.Size = new Size(232, 23);
            textAnioCalendario.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 66);
            label1.Name = "label1";
            label1.Size = new Size(138, 21);
            label1.TabIndex = 29;
            label1.Text = "Año de Calendario";
            // 
            // textCupo
            // 
            textCupo.Location = new Point(545, 64);
            textCupo.Name = "textCupo";
            textCupo.Size = new Size(232, 23);
            textCupo.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(492, 66);
            label3.Name = "label3";
            label3.Size = new Size(47, 21);
            label3.TabIndex = 31;
            label3.Text = "Cupo";
            // 
            // comboBoxComision
            // 
            comboBoxComision.FormattingEnabled = true;
            comboBoxComision.Location = new Point(156, 103);
            comboBoxComision.Name = "comboBoxComision";
            comboBoxComision.Size = new Size(232, 23);
            comboBoxComision.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(74, 105);
            label4.Name = "label4";
            label4.Size = new Size(76, 21);
            label4.TabIndex = 33;
            label4.Text = "Comisión";
            // 
            // comboBoxMateria
            // 
            comboBoxMateria.FormattingEnabled = true;
            comboBoxMateria.Location = new Point(545, 103);
            comboBoxMateria.Name = "comboBoxMateria";
            comboBoxMateria.Size = new Size(232, 23);
            comboBoxMateria.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(476, 105);
            label5.Name = "label5";
            label5.Size = new Size(63, 21);
            label5.TabIndex = 35;
            label5.Text = "Materia";
            // 
            // CursoDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 233);
            Controls.Add(label5);
            Controls.Add(comboBoxMateria);
            Controls.Add(label4);
            Controls.Add(comboBoxComision);
            Controls.Add(label3);
            Controls.Add(textCupo);
            Controls.Add(label1);
            Controls.Add(textAnioCalendario);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(textId);
            Controls.Add(labelId);
            Controls.Add(label2);
            Name = "CursoDetallesForm";
            Text = "CursoDetallesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox textId;
        private Label labelId;
        private Button buttonCancelar;
        private Button buttonAceptar;
        private TextBox textAnioCalendario;
        private Label label1;
        private TextBox textCupo;
        private Label label3;
        private ComboBox comboBoxComision;
        private Label label4;
        private ComboBox comboBoxMateria;
        private Label label5;
    }
}