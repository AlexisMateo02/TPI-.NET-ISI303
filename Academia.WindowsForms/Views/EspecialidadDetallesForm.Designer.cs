namespace Academia.WindowsForms.Views
{
    partial class EspecialidadDetallesForm
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
            textDescripcion = new RichTextBox();
            label1 = new Label();
            labelId = new Label();
            textId = new TextBox();
            buttonAceptar = new Button();
            buttonCancelar = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(12, 94);
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(682, 250);
            textDescripcion.TabIndex = 0;
            textDescripcion.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 1;
            label1.Text = "Descripción";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 12F);
            labelId.Location = new Point(597, 14);
            labelId.Name = "labelId";
            labelId.Size = new Size(23, 21);
            labelId.TabIndex = 2;
            labelId.Text = "Id";
            // 
            // textId
            // 
            textId.Location = new Point(626, 12);
            textId.Name = "textId";
            textId.Size = new Size(68, 23);
            textId.TabIndex = 3;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(601, 350);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(93, 36);
            buttonAceptar.TabIndex = 4;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(492, 350);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(93, 36);
            buttonCancelar.TabIndex = 5;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(260, 23);
            label2.Name = "label2";
            label2.Size = new Size(191, 39);
            label2.TabIndex = 14;
            label2.Text = "ESPECIALIDAD";
            // 
            // EspecialidadDetallesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 398);
            Controls.Add(label2);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(textId);
            Controls.Add(labelId);
            Controls.Add(label1);
            Controls.Add(textDescripcion);
            Name = "EspecialidadDetallesForm";
            Text = "EspecialidadDetallesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textDescripcion;
        private Label label1;
        private Label labelId;
        private TextBox textId;
        private Button buttonAceptar;
        private Button buttonCancelar;
        private Label label2;
    }
}