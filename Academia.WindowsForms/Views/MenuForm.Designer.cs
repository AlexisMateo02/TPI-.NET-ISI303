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
            buttonPlan = new Button();
            SuspendLayout();
            // 
            // buttonUsuario
            // 
            buttonUsuario.BackColor = SystemColors.ButtonFace;
            buttonUsuario.Font = new Font("Segoe UI", 12F);
            buttonUsuario.Location = new Point(41, 75);
            buttonUsuario.Name = "buttonUsuario";
            buttonUsuario.Size = new Size(163, 35);
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
            menu.Location = new Point(12, 9);
            menu.Name = "menu";
            menu.Size = new Size(222, 53);
            menu.TabIndex = 1;
            menu.Text = "     Menú     ";
            // 
            // buttonEspecialidad
            // 
            buttonEspecialidad.BackColor = SystemColors.ButtonFace;
            buttonEspecialidad.Font = new Font("Segoe UI", 12F);
            buttonEspecialidad.Location = new Point(41, 125);
            buttonEspecialidad.Name = "buttonEspecialidad";
            buttonEspecialidad.Size = new Size(163, 35);
            buttonEspecialidad.TabIndex = 2;
            buttonEspecialidad.Text = "Especialidad";
            buttonEspecialidad.UseVisualStyleBackColor = false;
            buttonEspecialidad.Click += buttonEspecialidad_Click;
            // 
            // buttonPlan
            // 
            buttonPlan.BackColor = SystemColors.ButtonFace;
            buttonPlan.Font = new Font("Segoe UI", 12F);
            buttonPlan.Location = new Point(41, 175);
            buttonPlan.Name = "buttonPlan";
            buttonPlan.Size = new Size(163, 35);
            buttonPlan.TabIndex = 3;
            buttonPlan.Text = "Plan";
            buttonPlan.UseVisualStyleBackColor = false;
            buttonPlan.Click += buttonPlan_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(247, 224);
            Controls.Add(buttonPlan);
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
        private Button buttonPlan;
    }
}