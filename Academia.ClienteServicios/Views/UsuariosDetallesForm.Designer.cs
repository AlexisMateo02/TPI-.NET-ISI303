namespace Academia.ClienteServicios.Views
{
    partial class UsuariosDetallesForm
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
            SuspendLayout();
            // 
            // textNombre
            // 
            textNombre.Location = new Point(152, 39);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(315, 23);
            textNombre.TabIndex = 1;
            // 
            // textClave
            // 
            textClave.Location = new Point(152, 106);
            textClave.Name = "textClave";
            textClave.Size = new Size(315, 23);
            textClave.TabIndex = 2;
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Font = new Font("Segoe UI", 15F);
            Nombre.Location = new Point(25, 34);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(85, 28);
            Nombre.TabIndex = 5;
            Nombre.Text = "Nombre";
            // 
            // Clave
            // 
            Clave.AutoSize = true;
            Clave.Font = new Font("Segoe UI", 15F);
            Clave.Location = new Point(25, 101);
            Clave.Name = "Clave";
            Clave.Size = new Size(59, 28);
            Clave.TabIndex = 6;
            Clave.Text = "Clave";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(106, 221);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(122, 51);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(281, 221);
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
            checkHabilitado.Location = new Point(25, 160);
            checkHabilitado.Name = "checkHabilitado";
            checkHabilitado.Size = new Size(123, 32);
            checkHabilitado.TabIndex = 10;
            checkHabilitado.Text = "Habilitado";
            checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // UsuariosDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 313);
            Controls.Add(checkHabilitado);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(Clave);
            Controls.Add(Nombre);
            Controls.Add(textClave);
            Controls.Add(textNombre);
            Name = "UsuariosDetallesForm";
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
    }
}