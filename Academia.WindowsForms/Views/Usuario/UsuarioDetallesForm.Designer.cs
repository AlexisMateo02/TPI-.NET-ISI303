namespace Academia.WindowsForms.Views.Usuario
{
    partial class UsuarioDetallesForm
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
            textNombreUsuario = new TextBox();
            textClave = new TextBox();
            Nombre = new Label();
            labelClave = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            checkHabilitado = new CheckBox();
            idLabel = new Label();
            textId = new TextBox();
            fechaAltaLabel = new Label();
            textFechaAlta = new TextBox();
            label2 = new Label();
            label1 = new Label();
            listBoxPersona = new ListBox();
            comboBoxRol = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // textNombreUsuario
            // 
            textNombreUsuario.Location = new Point(219, 109);
            textNombreUsuario.Name = "textNombreUsuario";
            textNombreUsuario.Size = new Size(324, 23);
            textNombreUsuario.TabIndex = 1;
            // 
            // textClave
            // 
            textClave.Location = new Point(219, 153);
            textClave.Name = "textClave";
            textClave.Size = new Size(324, 23);
            textClave.TabIndex = 2;
            textClave.UseSystemPasswordChar = true;
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Font = new Font("Segoe UI", 15F);
            Nombre.Location = new Point(16, 104);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(197, 28);
            Nombre.TabIndex = 5;
            Nombre.Text = "Nombre de Usuario *";
            // 
            // labelClave
            // 
            labelClave.AutoSize = true;
            labelClave.Font = new Font("Segoe UI", 15F);
            labelClave.Location = new Point(90, 148);
            labelClave.Name = "labelClave";
            labelClave.Size = new Size(123, 28);
            labelClave.TabIndex = 6;
            labelClave.Text = "Contraseña *";
            labelClave.TextAlign = ContentAlignment.TopRight;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(316, 448);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(118, 37);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(440, 448);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 37);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // checkHabilitado
            // 
            checkHabilitado.AutoSize = true;
            checkHabilitado.Font = new Font("Segoe UI", 15F);
            checkHabilitado.Location = new Point(32, 280);
            checkHabilitado.Name = "checkHabilitado";
            checkHabilitado.Size = new Size(123, 32);
            checkHabilitado.TabIndex = 10;
            checkHabilitado.Text = "Habilitado";
            checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI", 12F);
            idLabel.Location = new Point(225, 25);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(23, 21);
            idLabel.TabIndex = 13;
            idLabel.Text = "Id";
            // 
            // textId
            // 
            textId.Location = new Point(254, 23);
            textId.Name = "textId";
            textId.Size = new Size(289, 23);
            textId.TabIndex = 12;
            // 
            // fechaAltaLabel
            // 
            fechaAltaLabel.AutoSize = true;
            fechaAltaLabel.Font = new Font("Segoe UI", 12F);
            fechaAltaLabel.Location = new Point(167, 65);
            fechaAltaLabel.Name = "fechaAltaLabel";
            fechaAltaLabel.Size = new Size(81, 21);
            fechaAltaLabel.TabIndex = 15;
            fechaAltaLabel.Text = "Fecha Alta";
            // 
            // textFechaAlta
            // 
            textFechaAlta.Location = new Point(254, 63);
            textFechaAlta.Name = "textFechaAlta";
            textFechaAlta.Size = new Size(289, 23);
            textFechaAlta.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(16, 25);
            label2.Name = "label2";
            label2.Size = new Size(130, 39);
            label2.TabIndex = 16;
            label2.Text = "USUARIO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(32, 230);
            label1.Name = "label1";
            label1.Size = new Size(181, 28);
            label1.TabIndex = 18;
            label1.Text = "Apellido, Nombre *";
            // 
            // listBoxPersona
            // 
            listBoxPersona.FormattingEnabled = true;
            listBoxPersona.ItemHeight = 15;
            listBoxPersona.Location = new Point(219, 230);
            listBoxPersona.Name = "listBoxPersona";
            listBoxPersona.Size = new Size(324, 124);
            listBoxPersona.TabIndex = 19;
            // 
            // comboBoxRol
            // 
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Location = new Point(32, 357);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(145, 23);
            comboBoxRol.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(32, 326);
            label3.Name = "label3";
            label3.Size = new Size(40, 28);
            label3.TabIndex = 21;
            label3.Text = "Rol";
            // 
            // UsuarioDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 497);
            Controls.Add(label3);
            Controls.Add(comboBoxRol);
            Controls.Add(listBoxPersona);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(fechaAltaLabel);
            Controls.Add(textFechaAlta);
            Controls.Add(idLabel);
            Controls.Add(textId);
            Controls.Add(checkHabilitado);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(labelClave);
            Controls.Add(Nombre);
            Controls.Add(textClave);
            Controls.Add(textNombreUsuario);
            Name = "UsuarioDetallesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textNombreUsuario;
        private TextBox textClave;
        private Label Nombre;
        private Label labelClave;
        private Button btnAceptar;
        private Button btnCancelar;
        private CheckBox checkHabilitado;
        private Label idLabel;
        private TextBox textId;
        private Label fechaAltaLabel;
        private TextBox textFechaAlta;
        private Label label2;
        private Label label1;
        private ListBox listBoxPersona;
        private ComboBox comboBoxRol;
        private Label label3;
    }
}