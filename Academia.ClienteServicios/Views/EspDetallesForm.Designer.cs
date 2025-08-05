namespace Academia.ClienteServicios.Views
{
    partial class EspDetallesForm
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
            textDesc = new RichTextBox();
            label1 = new Label();
            buttonAceptar = new Button();
            buttonCancelar = new Button();
            SuspendLayout();
            // 
            // textDesc
            // 
            textDesc.Location = new Point(32, 70);
            textDesc.Name = "textDesc";
            textDesc.Size = new Size(425, 184);
            textDesc.TabIndex = 0;
            textDesc.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(59, 24);
            label1.Name = "label1";
            label1.Size = new Size(114, 28);
            label1.TabIndex = 1;
            label1.Text = "Descripción";
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(197, 24);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(103, 37);
            buttonAceptar.TabIndex = 2;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(320, 24);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(98, 37);
            buttonCancelar.TabIndex = 3;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // EspDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 302);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(label1);
            Controls.Add(textDesc);
            Name = "EspDetallesForm";
            Text = "EspDetallesForm";
            Load += EspDetallesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textDesc;
        private Label label1;
        private Button buttonAceptar;
        private Button buttonCancelar;
    }
}