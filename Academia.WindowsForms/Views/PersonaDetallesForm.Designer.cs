namespace Academia.WindowsForms.Views
{
    partial class PersonaDetallesForm
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
            textNombre = new TextBox();
            textApellido = new TextBox();
            textDireccion = new TextBox();
            pickerFechaNac = new DateTimePicker();
            textEmail = new TextBox();
            textTelefono = new TextBox();
            comboBoxTipoPersona = new ComboBox();
            textLegajo = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            comboBoxPlan = new ComboBox();
            comboBoxEspecialidad = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(340, 9);
            label2.Name = "label2";
            label2.Size = new Size(135, 39);
            label2.TabIndex = 15;
            label2.Text = "PERSONA";
            // 
            // textId
            // 
            textId.Location = new Point(717, 13);
            textId.Name = "textId";
            textId.Size = new Size(68, 23);
            textId.TabIndex = 17;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 12F);
            labelId.Location = new Point(688, 15);
            labelId.Name = "labelId";
            labelId.Size = new Size(23, 21);
            labelId.TabIndex = 16;
            labelId.Text = "Id";
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(695, 414);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(93, 36);
            buttonCancelar.TabIndex = 19;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(596, 414);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(93, 36);
            buttonAceptar.TabIndex = 18;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(164, 106);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(621, 23);
            textNombre.TabIndex = 21;
            // 
            // textApellido
            // 
            textApellido.Location = new Point(164, 144);
            textApellido.Name = "textApellido";
            textApellido.Size = new Size(621, 23);
            textApellido.TabIndex = 22;
            // 
            // textDireccion
            // 
            textDireccion.Location = new Point(164, 186);
            textDireccion.Name = "textDireccion";
            textDireccion.Size = new Size(621, 23);
            textDireccion.TabIndex = 23;
            // 
            // pickerFechaNac
            // 
            pickerFechaNac.Location = new Point(164, 314);
            pickerFechaNac.Name = "pickerFechaNac";
            pickerFechaNac.Size = new Size(257, 23);
            pickerFechaNac.TabIndex = 24;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(164, 227);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(621, 23);
            textEmail.TabIndex = 25;
            // 
            // textTelefono
            // 
            textTelefono.Location = new Point(164, 270);
            textTelefono.Name = "textTelefono";
            textTelefono.Size = new Size(621, 23);
            textTelefono.TabIndex = 26;
            // 
            // comboBoxTipoPersona
            // 
            comboBoxTipoPersona.FormattingEnabled = true;
            comboBoxTipoPersona.Location = new Point(578, 314);
            comboBoxTipoPersona.Name = "comboBoxTipoPersona";
            comboBoxTipoPersona.Size = new Size(207, 23);
            comboBoxTipoPersona.TabIndex = 27;
            // 
            // textLegajo
            // 
            textLegajo.Location = new Point(164, 65);
            textLegajo.Name = "textLegajo";
            textLegajo.Size = new Size(621, 23);
            textLegajo.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(102, 67);
            label1.Name = "label1";
            label1.Size = new Size(56, 21);
            label1.TabIndex = 28;
            label1.Text = "Legajo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(90, 108);
            label3.Name = "label3";
            label3.Size = new Size(68, 21);
            label3.TabIndex = 29;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(91, 146);
            label4.Name = "label4";
            label4.Size = new Size(67, 21);
            label4.TabIndex = 30;
            label4.Text = "Apellido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(452, 316);
            label5.Name = "label5";
            label5.Size = new Size(120, 21);
            label5.TabIndex = 31;
            label5.Text = "Tipo de Persona";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(83, 188);
            label6.Name = "label6";
            label6.Size = new Size(75, 21);
            label6.TabIndex = 32;
            label6.Text = "Dirección";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(110, 229);
            label7.Name = "label7";
            label7.Size = new Size(48, 21);
            label7.TabIndex = 33;
            label7.Text = "Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(90, 272);
            label8.Name = "label8";
            label8.Size = new Size(68, 21);
            label8.TabIndex = 35;
            label8.Text = "Teléfono";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(3, 316);
            label9.Name = "label9";
            label9.Size = new Size(155, 21);
            label9.TabIndex = 36;
            label9.Text = "Fecha de Nacimiento";
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.FormattingEnabled = true;
            comboBoxPlan.Location = new Point(578, 359);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(207, 23);
            comboBoxPlan.TabIndex = 37;
            // 
            // comboBoxEspecialidad
            // 
            comboBoxEspecialidad.FormattingEnabled = true;
            comboBoxEspecialidad.Location = new Point(164, 359);
            comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            comboBoxEspecialidad.Size = new Size(257, 23);
            comboBoxEspecialidad.TabIndex = 38;
            comboBoxEspecialidad.SelectedIndexChanged += comboBoxEspecialidad_SelectedValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(63, 361);
            label10.Name = "label10";
            label10.Size = new Size(95, 21);
            label10.TabIndex = 39;
            label10.Text = "Especialidad";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(532, 361);
            label11.Name = "label11";
            label11.Size = new Size(40, 21);
            label11.TabIndex = 40;
            label11.Text = "Plan";
            // 
            // PersonaDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 465);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(comboBoxEspecialidad);
            Controls.Add(comboBoxPlan);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(comboBoxTipoPersona);
            Controls.Add(textTelefono);
            Controls.Add(textEmail);
            Controls.Add(pickerFechaNac);
            Controls.Add(textDireccion);
            Controls.Add(textApellido);
            Controls.Add(textNombre);
            Controls.Add(textLegajo);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(textId);
            Controls.Add(labelId);
            Controls.Add(label2);
            Name = "PersonaDetallesForm";
            Text = "PersonaDetallesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox textId;
        private Label labelId;
        private Button buttonCancelar;
        private Button buttonAceptar;
        private TextBox textNombre;
        private TextBox textApellido;
        private TextBox textDireccion;
        private DateTimePicker pickerFechaNac;
        private TextBox textEmail;
        private TextBox textTelefono;
        private ComboBox comboBoxTipoPersona;
        private TextBox textLegajo;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox comboBoxPlan;
        private ComboBox comboBoxEspecialidad;
        private Label label10;
        private Label label11;
    }
}