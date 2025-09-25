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
            label2 = new Label();
            SuspendLayout();
            // 
            // textNombre
            // 
            textNombre.Location = new Point(152, 84);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(315, 23);
            textNombre.TabIndex = 1;
            // 
            // textClave
            // 
            textClave.Location = new Point(152, 137);
            textClave.Name = "textClave";
            textClave.Size = new Size(315, 23);
            textClave.TabIndex = 2;
            textClave.UseSystemPasswordChar = true;
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Font = new Font("Segoe UI", 15F);
            Nombre.Location = new Point(25, 79);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(85, 28);
            Nombre.TabIndex = 5;
            Nombre.Text = "Nombre";
            // 
            // Clave
            // 
            Clave.AutoSize = true;
            Clave.Font = new Font("Segoe UI", 15F);
            Clave.Location = new Point(25, 129);
            Clave.Name = "Clave";
            Clave.Size = new Size(59, 28);
            Clave.TabIndex = 6;
            Clave.Text = "Clave";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(355, 278);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(122, 51);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(496, 278);
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
            checkHabilitado.Location = new Point(25, 238);
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
            idLabel.Location = new Point(529, 12);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(23, 21);
            idLabel.TabIndex = 13;
            idLabel.Text = "Id";
            // 
            // textId
            // 
            textId.Location = new Point(558, 12);
            textId.Name = "textId";
            textId.Size = new Size(73, 23);
            textId.TabIndex = 12;
            // 
            // fechaAltaLabel
            // 
            fechaAltaLabel.AutoSize = true;
            fechaAltaLabel.Font = new Font("Segoe UI", 15F);
            fechaAltaLabel.Location = new Point(25, 186);
            fechaAltaLabel.Name = "fechaAltaLabel";
            fechaAltaLabel.Size = new Size(102, 28);
            fechaAltaLabel.TabIndex = 15;
            fechaAltaLabel.Text = "Fecha Alta";
            // 
            // textFechaAlta
            // 
            textFechaAlta.Location = new Point(152, 191);
            textFechaAlta.Name = "textFechaAlta";
            textFechaAlta.Size = new Size(315, 23);
            textFechaAlta.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(247, 12);
            label2.Name = "label2";
            label2.Size = new Size(130, 39);
            label2.TabIndex = 16;
            label2.Text = "USUARIO";
            // 
            // UsuarioDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 350);
            Controls.Add(label2);
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
        private Label label2;
    }
}