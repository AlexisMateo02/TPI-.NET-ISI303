namespace Academia.WindowsForms.Views.Menu
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
            labelRol = new Label();
            labelRolDisplay = new Label();
            labelUsuario = new Label();
            buttonCerrarSesion = new Button();
            buttonSalir = new Button();
            buttonDocenteCurso = new Button();
            buttonInscripcion = new Button();
            SuspendLayout();
            // 
            // buttonUsuario
            // 
            buttonUsuario.BackColor = SystemColors.ButtonFace;
            buttonUsuario.Font = new Font("Segoe UI", 12F);
            buttonUsuario.Location = new Point(41, 75);
            buttonUsuario.Name = "buttonUsuario";
            buttonUsuario.Size = new Size(381, 35);
            buttonUsuario.TabIndex = 0;
            buttonUsuario.Text = "Usuario";
            buttonUsuario.UseVisualStyleBackColor = false;
            buttonUsuario.Click += buttonUsuario_Click;
            // 
            // menu
            // 
            menu.AutoSize = true;
            menu.BackColor = Color.GhostWhite;
            menu.BorderStyle = BorderStyle.Fixed3D;
            menu.Font = new Font("Segoe UI", 28F);
            menu.Location = new Point(364, 8);
            menu.Name = "menu";
            menu.Size = new Size(131, 53);
            menu.TabIndex = 1;
            menu.Text = "MENÚ";
            // 
            // buttonEspecialidad
            // 
            buttonEspecialidad.BackColor = SystemColors.ButtonFace;
            buttonEspecialidad.Font = new Font("Segoe UI", 12F);
            buttonEspecialidad.Location = new Point(41, 128);
            buttonEspecialidad.Name = "buttonEspecialidad";
            buttonEspecialidad.Size = new Size(381, 35);
            buttonEspecialidad.TabIndex = 2;
            buttonEspecialidad.Text = "Especialidad";
            buttonEspecialidad.UseVisualStyleBackColor = false;
            buttonEspecialidad.Click += buttonEspecialidad_Click;
            // 
            // buttonPlan
            // 
            buttonPlan.BackColor = SystemColors.ButtonFace;
            buttonPlan.Font = new Font("Segoe UI", 12F);
            buttonPlan.Location = new Point(437, 128);
            buttonPlan.Name = "buttonPlan";
            buttonPlan.Size = new Size(381, 35);
            buttonPlan.TabIndex = 3;
            buttonPlan.Text = "Plan";
            buttonPlan.UseVisualStyleBackColor = false;
            buttonPlan.Click += buttonPlan_Click;
            // 
            // buttonPersona
            // 
            buttonPersona.BackColor = SystemColors.ButtonFace;
            buttonPersona.Font = new Font("Segoe UI", 12F);
            buttonPersona.Location = new Point(437, 75);
            buttonPersona.Name = "buttonPersona";
            buttonPersona.Size = new Size(381, 35);
            buttonPersona.TabIndex = 4;
            buttonPersona.Text = "Persona";
            buttonPersona.UseVisualStyleBackColor = false;
            buttonPersona.Click += buttonPersona_Click;
            // 
            // buttonComision
            // 
            buttonComision.BackColor = SystemColors.ButtonFace;
            buttonComision.Font = new Font("Segoe UI", 12F);
            buttonComision.Location = new Point(41, 180);
            buttonComision.Name = "buttonComision";
            buttonComision.Size = new Size(381, 35);
            buttonComision.TabIndex = 5;
            buttonComision.Text = "Comisión";
            buttonComision.UseVisualStyleBackColor = false;
            buttonComision.Click += buttonComision_Click;
            // 
            // buttonMateria
            // 
            buttonMateria.BackColor = SystemColors.ButtonFace;
            buttonMateria.Font = new Font("Segoe UI", 12F);
            buttonMateria.Location = new Point(437, 180);
            buttonMateria.Name = "buttonMateria";
            buttonMateria.Size = new Size(381, 35);
            buttonMateria.TabIndex = 6;
            buttonMateria.Text = "Materia";
            buttonMateria.UseVisualStyleBackColor = false;
            buttonMateria.Click += buttonMateria_Click;
            // 
            // buttonCurso
            // 
            buttonCurso.BackColor = SystemColors.ButtonFace;
            buttonCurso.Font = new Font("Segoe UI", 12F);
            buttonCurso.Location = new Point(41, 231);
            buttonCurso.Name = "buttonCurso";
            buttonCurso.Size = new Size(381, 35);
            buttonCurso.TabIndex = 7;
            buttonCurso.Text = "Curso";
            buttonCurso.UseVisualStyleBackColor = false;
            buttonCurso.Click += buttonCurso_Click;
            // 
            // labelRol
            // 
            labelRol.AutoSize = true;
            labelRol.Font = new Font("Segoe UI", 12F);
            labelRol.Location = new Point(656, 9);
            labelRol.Name = "labelRol";
            labelRol.Size = new Size(36, 21);
            labelRol.TabIndex = 8;
            labelRol.Text = "Rol:";
            // 
            // labelRolDisplay
            // 
            labelRolDisplay.AutoSize = true;
            labelRolDisplay.Font = new Font("Segoe UI", 12F);
            labelRolDisplay.Location = new Point(698, 9);
            labelRolDisplay.Name = "labelRolDisplay";
            labelRolDisplay.Size = new Size(64, 21);
            labelRolDisplay.TabIndex = 9;
            labelRolDisplay.Text = "Usuario";
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Font = new Font("Segoe UI", 12F);
            labelUsuario.Location = new Point(656, 41);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(67, 21);
            labelUsuario.TabIndex = 10;
            labelUsuario.Text = "Usuario:";
            // 
            // buttonCerrarSesion
            // 
            buttonCerrarSesion.BackColor = SystemColors.ButtonFace;
            buttonCerrarSesion.Font = new Font("Segoe UI", 12F);
            buttonCerrarSesion.Location = new Point(41, 378);
            buttonCerrarSesion.Name = "buttonCerrarSesion";
            buttonCerrarSesion.Size = new Size(777, 35);
            buttonCerrarSesion.TabIndex = 11;
            buttonCerrarSesion.Text = "Cerrar Sesión";
            buttonCerrarSesion.UseVisualStyleBackColor = false;
            buttonCerrarSesion.Click += buttonCerrarSesion_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = SystemColors.ButtonFace;
            buttonSalir.Font = new Font("Segoe UI", 12F);
            buttonSalir.Location = new Point(41, 428);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(777, 35);
            buttonSalir.TabIndex = 12;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // buttonDocenteCurso
            // 
            buttonDocenteCurso.BackColor = SystemColors.ButtonFace;
            buttonDocenteCurso.Font = new Font("Segoe UI", 12F);
            buttonDocenteCurso.Location = new Point(41, 285);
            buttonDocenteCurso.Name = "buttonDocenteCurso";
            buttonDocenteCurso.Size = new Size(777, 35);
            buttonDocenteCurso.TabIndex = 13;
            buttonDocenteCurso.Text = "Docentes y cursos";
            buttonDocenteCurso.UseVisualStyleBackColor = false;
            buttonDocenteCurso.Click += buttonDocenteCurso_Click;
            // 
            // buttonInscripcion
            // 
            buttonInscripcion.BackColor = SystemColors.ButtonFace;
            buttonInscripcion.Font = new Font("Segoe UI", 12F);
            buttonInscripcion.Location = new Point(437, 231);
            buttonInscripcion.Name = "buttonInscripcion";
            buttonInscripcion.Size = new Size(381, 35);
            buttonInscripcion.TabIndex = 14;
            buttonInscripcion.Text = "Inscripciones";
            buttonInscripcion.UseVisualStyleBackColor = false;
            buttonInscripcion.Click += buttonInscripcion_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(850, 484);
            Controls.Add(buttonInscripcion);
            Controls.Add(buttonDocenteCurso);
            Controls.Add(buttonSalir);
            Controls.Add(buttonCerrarSesion);
            Controls.Add(labelUsuario);
            Controls.Add(labelRolDisplay);
            Controls.Add(labelRol);
            Controls.Add(buttonCurso);
            Controls.Add(buttonMateria);
            Controls.Add(buttonComision);
            Controls.Add(buttonPersona);
            Controls.Add(buttonPlan);
            Controls.Add(buttonEspecialidad);
            Controls.Add(menu);
            Controls.Add(buttonUsuario);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú";
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
        private Label labelRol;
        private Label labelRolDisplay;
        private Label labelUsuario;
        private Button buttonCerrarSesion;
        private Button buttonSalir;
        private Button buttonDocenteCurso;
        private Button buttonInscripcion;
    }
}