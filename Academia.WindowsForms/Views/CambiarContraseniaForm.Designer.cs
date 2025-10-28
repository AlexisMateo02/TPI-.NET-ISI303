namespace Academia.WindowsForms.Views
{
    partial class CambiarContraseniaForm
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
            components = new System.ComponentModel.Container();
            label2 = new Label();
            checkBoxMostrar = new CheckBox();
            Clave = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtNuevaClave = new TextBox();
            txtConfirmarClave = new TextBox();
            txtClaveActual = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(455, 19);
            label2.Name = "label2";
            label2.Size = new Size(186, 63);
            label2.TabIndex = 1;
            label2.Text = "Requisitos de contraseña:\r\n • Mínimo 6 caracteres\r\n • Diferente a la actual";
            // 
            // checkBoxMostrar
            // 
            checkBoxMostrar.AutoSize = true;
            checkBoxMostrar.Font = new Font("Segoe UI", 15F);
            checkBoxMostrar.Location = new Point(48, 258);
            checkBoxMostrar.Name = "checkBoxMostrar";
            checkBoxMostrar.Size = new Size(208, 32);
            checkBoxMostrar.TabIndex = 11;
            checkBoxMostrar.Text = "Mostrar contraseñas";
            checkBoxMostrar.UseVisualStyleBackColor = true;
            checkBoxMostrar.CheckedChanged += checkBoxMostrar_CheckedChanged;
            // 
            // Clave
            // 
            Clave.AutoSize = true;
            Clave.Font = new Font("Segoe UI", 15F);
            Clave.Location = new Point(137, 101);
            Clave.Name = "Clave";
            Clave.Size = new Size(167, 28);
            Clave.TabIndex = 12;
            Clave.Text = "Contraseña actual";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(137, 152);
            label3.Name = "label3";
            label3.Size = new Size(167, 28);
            label3.TabIndex = 13;
            label3.Text = "Contraseña nueva";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(48, 204);
            label4.Name = "label4";
            label4.Size = new Size(256, 28);
            label4.TabIndex = 14;
            label4.Text = "Confirmar contraseña nueva";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(63, 34);
            label1.Name = "label1";
            label1.Size = new Size(334, 39);
            label1.TabIndex = 17;
            label1.Text = "CAMBIO DE CONTRASEÑA";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(531, 253);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 37);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(407, 253);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(118, 37);
            btnAceptar.TabIndex = 18;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtNuevaClave
            // 
            txtNuevaClave.Location = new Point(317, 157);
            txtNuevaClave.Name = "txtNuevaClave";
            txtNuevaClave.Size = new Size(324, 23);
            txtNuevaClave.TabIndex = 20;
            // 
            // txtConfirmarClave
            // 
            txtConfirmarClave.Location = new Point(317, 209);
            txtConfirmarClave.Name = "txtConfirmarClave";
            txtConfirmarClave.Size = new Size(324, 23);
            txtConfirmarClave.TabIndex = 21;
            // 
            // txtClaveActual
            // 
            txtClaveActual.Location = new Point(317, 106);
            txtClaveActual.Name = "txtClaveActual";
            txtClaveActual.Size = new Size(324, 23);
            txtClaveActual.TabIndex = 22;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            // 
            // CambiarContraseniaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 314);
            Controls.Add(txtClaveActual);
            Controls.Add(txtConfirmarClave);
            Controls.Add(txtNuevaClave);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Clave);
            Controls.Add(checkBoxMostrar);
            Controls.Add(label2);
            Name = "CambiarContraseniaForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private CheckBox checkBoxMostrar;
        private Label Clave;
        private Label label3;
        private Label label4;
        private Label label1;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtNuevaClave;
        private TextBox txtConfirmarClave;
        private TextBox txtClaveActual;
        private ErrorProvider errorProvider1;
    }
}