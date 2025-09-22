namespace Academia.WindowsForms.Views
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
            textNombre = new TextBox();
            textClave = new TextBox();
            Nombre = new Label();
            Clave = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            checkHabilitado = new CheckBox();
            idLabel = new Label();
            textId = new TextBox();
            fechaAltaLabel = new Label();
            textFechaAlta = new TextBox();
            SuspendLayout();
            // 
            // textNombre
            // 
            textNombre.Location = new Point(152, 70);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(315, 23);
            textNombre.TabIndex = 1;
            // 
            // textClave
            // 
            textClave.Location = new Point(152, 123);
            textClave.Name = "textClave";
            textClave.Size = new Size(315, 23);
            textClave.TabIndex = 2;
            textClave.UseSystemPasswordChar = true;
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Font = new Font("Segoe UI", 15F);
            Nombre.Location = new Point(25, 65);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(85, 28);
            Nombre.TabIndex = 5;
            Nombre.Text = "Nombre";
            // 
            // Clave
            // 
            Clave.AutoSize = true;
            Clave.Font = new Font("Segoe UI", 15F);
            Clave.Location = new Point(25, 115);
            Clave.Name = "Clave";
            Clave.Size = new Size(59, 28);
            Clave.TabIndex = 6;
            Clave.Text = "Clave";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(345, 274);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(122, 51);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(486, 274);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(122, 51);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // checkHabilitado
            // 
            checkHabilitado.AutoSize = true;
            checkHabilitado.Font = new Font("Segoe UI", 15F);
            checkHabilitado.Location = new Point(25, 224);
            checkHabilitado.Name = "checkHabilitado";
            checkHabilitado.Size = new Size(123, 32);
            checkHabilitado.TabIndex = 10;
            checkHabilitado.Text = "Habilitado";
            checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI", 15F);
            idLabel.Location = new Point(25, 17);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(29, 28);
            idLabel.TabIndex = 13;
            idLabel.Text = "Id";
            // 
            // textId
            // 
            textId.Location = new Point(152, 22);
            textId.Name = "textId";
            textId.Size = new Size(315, 23);
            textId.TabIndex = 12;
            // 
            // fechaAltaLabel
            // 
            fechaAltaLabel.AutoSize = true;
            fechaAltaLabel.Font = new Font("Segoe UI", 15F);
            fechaAltaLabel.Location = new Point(25, 172);
            fechaAltaLabel.Name = "fechaAltaLabel";
            fechaAltaLabel.Size = new Size(102, 28);
            fechaAltaLabel.TabIndex = 15;
            fechaAltaLabel.Text = "Fecha Alta";
            // 
            // textFechaAlta
            // 
            textFechaAlta.Location = new Point(152, 177);
            textFechaAlta.Name = "textFechaAlta";
            textFechaAlta.Size = new Size(315, 23);
            textFechaAlta.TabIndex = 14;
            // 
            // UsuarioDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 350);
            Controls.Add(fechaAltaLabel);
            Controls.Add(textFechaAlta);
            Controls.Add(idLabel);
            Controls.Add(textId);
            Controls.Add(checkHabilitado);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(Clave);
            Controls.Add(Nombre);
            Controls.Add(textClave);
            Controls.Add(textNombre);
            Name = "UsuarioDetallesForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textNombre;
        private TextBox textClave;
        private Label Nombre;
        private Label Clave;
        private Button btnAceptar;
        private Button btnCancelar;
        private CheckBox checkHabilitado;
        private Label idLabel;
        private TextBox textId;
        private Label fechaAltaLabel;
        private TextBox textFechaAlta;
    }
}