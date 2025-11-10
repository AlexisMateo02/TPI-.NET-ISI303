namespace Academia.WindowsForms.Views.AlumnoInscripcion
{
    partial class InscripcionDetallesForm
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
            label5 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxAlumno = new ComboBox();
            comboBoxCondicion = new ComboBox();
            comboBoxCurso = new ComboBox();
            numericNota = new NumericUpDown();
            buttonCancelar = new Button();
            buttonAceptar = new Button();
            labelNota = new Label();
            labelCargoDocente = new Label();
            textCargoDocente = new TextBox();
            labelAlumnoReadOnly = new Label();
            textAlumnoReadOnly = new TextBox();
            labelMateriaReadOnly = new Label();
            textMateriaReadOnly = new TextBox();
            labelCondicionOriginal = new Label();
            textCondicionOriginal = new TextBox();
            labelInfoNota = new Label();
            labelInfoCondicion = new Label();
            panelAdvertencia = new Panel();
            labelAdvertencia = new Label();
            ((System.ComponentModel.ISupportInitialize)numericNota).BeginInit();
            panelAdvertencia.SuspendLayout();
            SuspendLayout();
            // 
            // textId
            // 
            textId.Location = new Point(721, 12);
            textId.Name = "textId";
            textId.Size = new Size(68, 23);
            textId.TabIndex = 14;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 12F);
            labelId.Location = new Point(692, 14);
            labelId.Name = "labelId";
            labelId.Size = new Size(25, 21);
            labelId.TabIndex = 13;
            labelId.Text = "ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(313, 9);
            label5.Name = "label5";
            label5.Size = new Size(179, 39);
            label5.TabIndex = 18;
            label5.Text = "INSCRIPCIÓN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 19;
            label2.Text = "Alumno *";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 199);
            label3.Name = "label3";
            label3.Size = new Size(62, 21);
            label3.TabIndex = 20;
            label3.Text = "Curso *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 268);
            label4.Name = "label4";
            label4.Size = new Size(91, 21);
            label4.TabIndex = 22;
            label4.Text = "Condición *";
            // 
            // comboBoxAlumno
            // 
            comboBoxAlumno.FormattingEnabled = true;
            comboBoxAlumno.Location = new Point(12, 93);
            comboBoxAlumno.Name = "comboBoxAlumno";
            comboBoxAlumno.Size = new Size(381, 23);
            comboBoxAlumno.TabIndex = 23;
            // 
            // comboBoxCondicion
            // 
            comboBoxCondicion.FormattingEnabled = true;
            comboBoxCondicion.Location = new Point(12, 292);
            comboBoxCondicion.Name = "comboBoxCondicion";
            comboBoxCondicion.Size = new Size(381, 23);
            comboBoxCondicion.TabIndex = 24;
            comboBoxCondicion.SelectedIndexChanged += comboBoxCondicion_SelectedIndexChanged;
            // 
            // comboBoxCurso
            // 
            comboBoxCurso.FormattingEnabled = true;
            comboBoxCurso.Location = new Point(12, 223);
            comboBoxCurso.Name = "comboBoxCurso";
            comboBoxCurso.Size = new Size(381, 23);
            comboBoxCurso.TabIndex = 25;
            // 
            // numericNota
            // 
            numericNota.Font = new Font("Segoe UI", 10F);
            numericNota.Location = new Point(408, 290);
            numericNota.Name = "numericNota";
            numericNota.Size = new Size(381, 25);
            numericNota.TabIndex = 26;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(696, 456);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(93, 36);
            buttonCancelar.TabIndex = 28;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(597, 456);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(93, 36);
            buttonAceptar.TabIndex = 27;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // labelNota
            // 
            labelNota.AutoSize = true;
            labelNota.Font = new Font("Segoe UI", 12F);
            labelNota.Location = new Point(408, 268);
            labelNota.Name = "labelNota";
            labelNota.Size = new Size(44, 21);
            labelNota.TabIndex = 29;
            labelNota.Text = "Nota";
            // 
            // labelCargoDocente
            // 
            labelCargoDocente.AutoSize = true;
            labelCargoDocente.Font = new Font("Segoe UI", 12F);
            labelCargoDocente.Location = new Point(410, 69);
            labelCargoDocente.Name = "labelCargoDocente";
            labelCargoDocente.Size = new Size(138, 21);
            labelCargoDocente.TabIndex = 30;
            labelCargoDocente.Text = "Cargo del Docente";
            // 
            // textCargoDocente
            // 
            textCargoDocente.Location = new Point(408, 93);
            textCargoDocente.Name = "textCargoDocente";
            textCargoDocente.Size = new Size(381, 23);
            textCargoDocente.TabIndex = 31;
            // 
            // labelAlumnoReadOnly
            // 
            labelAlumnoReadOnly.AutoSize = true;
            labelAlumnoReadOnly.Font = new Font("Segoe UI", 12F);
            labelAlumnoReadOnly.Location = new Point(12, 130);
            labelAlumnoReadOnly.Name = "labelAlumnoReadOnly";
            labelAlumnoReadOnly.Size = new Size(65, 21);
            labelAlumnoReadOnly.TabIndex = 32;
            labelAlumnoReadOnly.Text = "Alumno";
            // 
            // textAlumnoReadOnly
            // 
            textAlumnoReadOnly.Location = new Point(12, 154);
            textAlumnoReadOnly.Name = "textAlumnoReadOnly";
            textAlumnoReadOnly.Size = new Size(381, 23);
            textAlumnoReadOnly.TabIndex = 33;
            // 
            // labelMateriaReadOnly
            // 
            labelMateriaReadOnly.AutoSize = true;
            labelMateriaReadOnly.Font = new Font("Segoe UI", 12F);
            labelMateriaReadOnly.Location = new Point(408, 130);
            labelMateriaReadOnly.Name = "labelMateriaReadOnly";
            labelMateriaReadOnly.Size = new Size(63, 21);
            labelMateriaReadOnly.TabIndex = 34;
            labelMateriaReadOnly.Text = "Materia";
            // 
            // textMateriaReadOnly
            // 
            textMateriaReadOnly.Location = new Point(408, 154);
            textMateriaReadOnly.Name = "textMateriaReadOnly";
            textMateriaReadOnly.Size = new Size(381, 23);
            textMateriaReadOnly.TabIndex = 35;
            // 
            // labelCondicionOriginal
            // 
            labelCondicionOriginal.AutoSize = true;
            labelCondicionOriginal.Font = new Font("Segoe UI", 12F);
            labelCondicionOriginal.Location = new Point(408, 199);
            labelCondicionOriginal.Name = "labelCondicionOriginal";
            labelCondicionOriginal.Size = new Size(140, 21);
            labelCondicionOriginal.TabIndex = 36;
            labelCondicionOriginal.Text = "Condición Original";
            // 
            // textCondicionOriginal
            // 
            textCondicionOriginal.Location = new Point(408, 223);
            textCondicionOriginal.Name = "textCondicionOriginal";
            textCondicionOriginal.Size = new Size(381, 23);
            textCondicionOriginal.TabIndex = 37;
            // 
            // labelInfoNota
            // 
            labelInfoNota.AutoSize = true;
            labelInfoNota.Font = new Font("Segoe UI", 9F);
            labelInfoNota.ForeColor = SystemColors.ControlDarkDark;
            labelInfoNota.Location = new Point(12, 345);
            labelInfoNota.Name = "labelInfoNota";
            labelInfoNota.Size = new Size(54, 15);
            labelInfoNota.TabIndex = 38;
            labelInfoNota.Text = "InfoNota";
            // 
            // labelInfoCondicion
            // 
            labelInfoCondicion.AutoSize = true;
            labelInfoCondicion.Font = new Font("Segoe UI", 9F);
            labelInfoCondicion.ForeColor = SystemColors.ControlDarkDark;
            labelInfoCondicion.Location = new Point(12, 324);
            labelInfoCondicion.Name = "labelInfoCondicion";
            labelInfoCondicion.Size = new Size(83, 15);
            labelInfoCondicion.TabIndex = 39;
            labelInfoCondicion.Text = "InfoCondicion";
            // 
            // panelAdvertencia
            // 
            panelAdvertencia.Controls.Add(labelAdvertencia);
            panelAdvertencia.Location = new Point(12, 376);
            panelAdvertencia.Name = "panelAdvertencia";
            panelAdvertencia.Size = new Size(777, 69);
            panelAdvertencia.TabIndex = 40;
            panelAdvertencia.Visible = false;
            // 
            // labelAdvertencia
            // 
            labelAdvertencia.AutoSize = true;
            labelAdvertencia.Font = new Font("Segoe UI", 12F);
            labelAdvertencia.Location = new Point(7, 6);
            labelAdvertencia.Name = "labelAdvertencia";
            labelAdvertencia.Size = new Size(92, 21);
            labelAdvertencia.TabIndex = 41;
            labelAdvertencia.Text = "Advertencia";
            // 
            // InscripcionDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 504);
            Controls.Add(labelInfoNota);
            Controls.Add(labelInfoCondicion);
            Controls.Add(panelAdvertencia);
            Controls.Add(textCondicionOriginal);
            Controls.Add(labelCondicionOriginal);
            Controls.Add(textMateriaReadOnly);
            Controls.Add(labelMateriaReadOnly);
            Controls.Add(textAlumnoReadOnly);
            Controls.Add(labelAlumnoReadOnly);
            Controls.Add(textCargoDocente);
            Controls.Add(labelCargoDocente);
            Controls.Add(labelNota);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(numericNota);
            Controls.Add(comboBoxCurso);
            Controls.Add(comboBoxCondicion);
            Controls.Add(comboBoxAlumno);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(textId);
            Controls.Add(labelId);
            Name = "InscripcionDetallesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscripcion";
            ((System.ComponentModel.ISupportInitialize)numericNota).EndInit();
            panelAdvertencia.ResumeLayout(false);
            panelAdvertencia.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textId;
        private Label labelId;
        private Label label5;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxAlumno;
        private ComboBox comboBoxCondicion;
        private ComboBox comboBoxCurso;
        private NumericUpDown numericNota;
        private Button buttonCancelar;
        private Button buttonAceptar;
        private Label labelNota;
        private Label labelCargoDocente;
        private TextBox textCargoDocente;
        private Label labelAlumnoReadOnly;
        private TextBox textAlumnoReadOnly;
        private Label labelMateriaReadOnly;
        private TextBox textMateriaReadOnly;
        private Label labelCondicionOriginal;
        private TextBox textCondicionOriginal;
        private Label labelInfoNota;
        private Label labelInfoCondicion;
        private Panel panelAdvertencia;
        private Label labelAdvertencia;
    }
}