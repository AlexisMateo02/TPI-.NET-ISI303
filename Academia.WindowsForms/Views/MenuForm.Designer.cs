namespace Academia.WindowsForms.Views
{
    partial class MenuForm
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
            buttonUsuario = new Button();
            menu = new Label();
            buttonEspecialidad = new Button();
            SuspendLayout();
            // 
            // buttonUsuario
            // 
            buttonUsuario.BackColor = SystemColors.ButtonFace;
            buttonUsuario.Font = new Font("Segoe UI", 20F);
            buttonUsuario.Location = new Point(26, 91);
            buttonUsuario.Name = "buttonUsuario";
            buttonUsuario.Size = new Size(171, 66);
            buttonUsuario.TabIndex = 0;
            buttonUsuario.Text = "Usuario";
            buttonUsuario.UseVisualStyleBackColor = false;
            buttonUsuario.Click += buttonUsuario_Click;
            // 
            // menu
            // 
            menu.AutoSize = true;
            menu.BackColor = SystemColors.MenuHighlight;
            menu.BorderStyle = BorderStyle.Fixed3D;
            menu.Font = new Font("Segoe UI", 28F);
            menu.Location = new Point(138, 21);
            menu.Name = "menu";
            menu.Size = new Size(122, 53);
            menu.TabIndex = 1;
            menu.Text = "Menú";
            // 
            // buttonEspecialidad
            // 
            buttonEspecialidad.BackColor = SystemColors.ButtonFace;
            buttonEspecialidad.Font = new Font("Segoe UI", 20F);
            buttonEspecialidad.Location = new Point(203, 91);
            buttonEspecialidad.Name = "buttonEspecialidad";
            buttonEspecialidad.Size = new Size(175, 66);
            buttonEspecialidad.TabIndex = 2;
            buttonEspecialidad.Text = "Especialidad";
            buttonEspecialidad.UseVisualStyleBackColor = false;
            buttonEspecialidad.Click += buttonEspecialidad_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(400, 185);
            Controls.Add(buttonEspecialidad);
            Controls.Add(menu);
            Controls.Add(buttonUsuario);
            Name = "MenuForm";
            Text = "MenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonUsuario;
        private Label menu;
        private Button buttonEspecialidad;
    }
}