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
            buttonPersona = new Button();
            buttonComision = new Button();
            buttonMateria = new Button();
            buttonCurso = new Button();
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
            buttonEspecialidad.Location = new Point(41, 173);
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
            buttonPlan.Location = new Point(41, 223);
            buttonPlan.Name = "buttonPlan";
            buttonPlan.Size = new Size(163, 35);
            buttonPlan.TabIndex = 3;
            buttonPlan.Text = "Plan";
            buttonPlan.UseVisualStyleBackColor = false;
            buttonPlan.Click += buttonPlan_Click;
            // 
            // buttonPersona
            // 
            buttonPersona.BackColor = SystemColors.ButtonFace;
            buttonPersona.Font = new Font("Segoe UI", 12F);
            buttonPersona.Location = new Point(41, 123);
            buttonPersona.Name = "buttonPersona";
            buttonPersona.Size = new Size(163, 35);
            buttonPersona.TabIndex = 4;
            buttonPersona.Text = "Persona";
            buttonPersona.UseVisualStyleBackColor = false;
            buttonPersona.Click += buttonPersona_Click;
            // 
            // buttonComision
            // 
            buttonComision.BackColor = SystemColors.ButtonFace;
            buttonComision.Font = new Font("Segoe UI", 12F);
            buttonComision.Location = new Point(41, 273);
            buttonComision.Name = "buttonComision";
            buttonComision.Size = new Size(163, 35);
            buttonComision.TabIndex = 5;
            buttonComision.Text = "Comisión";
            buttonComision.UseVisualStyleBackColor = false;
            buttonComision.Click += buttonComision_Click;
            // 
            // buttonMateria
            // 
            buttonMateria.BackColor = SystemColors.ButtonFace;
            buttonMateria.Font = new Font("Segoe UI", 12F);
            buttonMateria.Location = new Point(41, 324);
            buttonMateria.Name = "buttonMateria";
            buttonMateria.Size = new Size(163, 35);
            buttonMateria.TabIndex = 6;
            buttonMateria.Text = "Materia";
            buttonMateria.UseVisualStyleBackColor = false;
            buttonMateria.Click += buttonMateria_Click;
            // 
            // buttonCurso
            // 
            buttonCurso.BackColor = SystemColors.ButtonFace;
            buttonCurso.Font = new Font("Segoe UI", 12F);
            buttonCurso.Location = new Point(41, 378);
            buttonCurso.Name = "buttonCurso";
            buttonCurso.Size = new Size(163, 35);
            buttonCurso.TabIndex = 7;
            buttonCurso.Text = "Curso";
            buttonCurso.UseVisualStyleBackColor = false;
            buttonCurso.Click += buttonCurso_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(247, 432);
            Controls.Add(buttonCurso);
            Controls.Add(buttonMateria);
            Controls.Add(buttonComision);
            Controls.Add(buttonPersona);
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
        private Button buttonPersona;
        private Button buttonComision;
        private Button buttonMateria;
        private Button buttonCurso;
    }
}