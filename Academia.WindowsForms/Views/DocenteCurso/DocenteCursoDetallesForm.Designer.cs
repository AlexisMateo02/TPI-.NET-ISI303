namespace Academia.WindowsForms.Views.DocenteCurso
{
    partial class DocenteCursoDetallesForm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBoxDocente = new ComboBox();
            comboBoxCargo = new ComboBox();
            comboBoxCurso = new ComboBox();
            buttonCancelar = new Button();
            buttonAceptar = new Button();
            SuspendLayout();
            // 
            // textId
            // 
            textId.Location = new Point(720, 12);
            textId.Name = "textId";
            textId.Size = new Size(68, 23);
            textId.TabIndex = 12;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 12F);
            labelId.Location = new Point(691, 14);
            labelId.Name = "labelId";
            labelId.Size = new Size(25, 21);
            labelId.TabIndex = 11;
            labelId.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 14;
            label2.Text = "Cargo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(210, 76);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 15;
            label3.Text = "Docente";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(596, 76);
            label4.Name = "label4";
            label4.Size = new Size(51, 21);
            label4.TabIndex = 16;
            label4.Text = "Curso";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(345, 14);
            label5.Name = "label5";
            label5.Size = new Size(130, 39);
            label5.TabIndex = 17;
            label5.Text = "DICTADO";
            // 
            // comboBoxDocente
            // 
            comboBoxDocente.FormattingEnabled = true;
            comboBoxDocente.Location = new Point(210, 100);
            comboBoxDocente.Name = "comboBoxDocente";
            comboBoxDocente.Size = new Size(380, 23);
            comboBoxDocente.TabIndex = 18;
            // 
            // comboBoxCargo
            // 
            comboBoxCargo.FormattingEnabled = true;
            comboBoxCargo.Location = new Point(12, 100);
            comboBoxCargo.Name = "comboBoxCargo";
            comboBoxCargo.Size = new Size(192, 23);
            comboBoxCargo.TabIndex = 19;
            // 
            // comboBoxCurso
            // 
            comboBoxCurso.FormattingEnabled = true;
            comboBoxCurso.Location = new Point(596, 100);
            comboBoxCurso.Name = "comboBoxCurso";
            comboBoxCurso.Size = new Size(192, 23);
            comboBoxCurso.TabIndex = 20;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(695, 237);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(93, 36);
            buttonCancelar.TabIndex = 22;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(596, 237);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(93, 36);
            buttonAceptar.TabIndex = 21;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // DocenteCursoDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 285);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(comboBoxCurso);
            Controls.Add(comboBoxCargo);
            Controls.Add(comboBoxDocente);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textId);
            Controls.Add(labelId);
            Name = "DocenteCursoDetallesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dictado";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textId;
        private Label labelId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxDocente;
        private ComboBox comboBoxCargo;
        private ComboBox comboBoxCurso;
        private Button buttonCancelar;
        private Button buttonAceptar;
    }
}