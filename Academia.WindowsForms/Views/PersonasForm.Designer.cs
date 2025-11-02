namespace Academia.WindowsForms.Views
{
    partial class PersonasForm
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
            buttonEliminar = new Button();
            buttonModificar = new Button();
            buttonAgregar = new Button();
            buttonListarAlumnos = new Button();
            dgvPersonas = new DataGridView();
            buttonListarDocentes = new Button();
            buttonListar2 = new Button();
            buscarTextBox = new TextBox();
            buttonListar = new Button();
            panelMiInfo = new Panel();
            labelTitulo = new Label();
            groupBoxInfo = new GroupBox();
            labelTipoPersonaValue = new Label();
            labelTipoPersona = new Label();
            labelEspecialidadValue = new Label();
            labelLegajoValue = new Label();
            labelEmailValue = new Label();
            labelPlanValue = new Label();
            labelDireccionValue = new Label();
            labelTelefonoValue = new Label();
            labelLegajo = new Label();
            labelEmail = new Label();
            labelDireccion = new Label();
            labelPlan = new Label();
            labelEspecialidad = new Label();
            labelTelefono = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            panelMiInfo.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            SuspendLayout();
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(680, 417);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(115, 33);
            buttonEliminar.TabIndex = 9;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(549, 417);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(115, 33);
            buttonModificar.TabIndex = 8;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(419, 417);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(115, 33);
            buttonAgregar.TabIndex = 7;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonListarAlumnos
            // 
            buttonListarAlumnos.Location = new Point(157, 417);
            buttonListarAlumnos.Name = "buttonListarAlumnos";
            buttonListarAlumnos.Size = new Size(115, 33);
            buttonListarAlumnos.TabIndex = 6;
            buttonListarAlumnos.Text = "Listar alumnos";
            buttonListarAlumnos.UseVisualStyleBackColor = true;
            buttonListarAlumnos.Click += buttonListarAlumnos_Click;
            // 
            // dgvPersonas
            // 
            dgvPersonas.AllowUserToAddRows = false;
            dgvPersonas.AllowUserToDeleteRows = false;
            dgvPersonas.AllowUserToOrderColumns = true;
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Location = new Point(12, 52);
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.Size = new Size(799, 354);
            dgvPersonas.TabIndex = 5;
            // 
            // buttonListarDocentes
            // 
            buttonListarDocentes.Location = new Point(289, 417);
            buttonListarDocentes.Name = "buttonListarDocentes";
            buttonListarDocentes.Size = new Size(115, 33);
            buttonListarDocentes.TabIndex = 10;
            buttonListarDocentes.Text = "Listar docentes";
            buttonListarDocentes.UseVisualStyleBackColor = true;
            buttonListarDocentes.Click += buttonListarDocentes_Click;
            // 
            // buttonListar2
            // 
            buttonListar2.Location = new Point(24, 417);
            buttonListar2.Name = "buttonListar2";
            buttonListar2.Size = new Size(115, 33);
            buttonListar2.TabIndex = 11;
            buttonListar2.Text = "Listar";
            buttonListar2.UseVisualStyleBackColor = true;
            buttonListar2.Click += buttonListar2_Click;
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(12, 12);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por nombre, apellido o legajo...";
            buscarTextBox.Size = new Size(628, 23);
            buscarTextBox.TabIndex = 12;
            // 
            // buttonListar
            // 
            buttonListar.Location = new Point(646, 12);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(149, 23);
            buttonListar.TabIndex = 13;
            buttonListar.Text = "Buscar";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += buttonListar_Click;
            // 
            // panelMiInfo
            // 
            panelMiInfo.Controls.Add(labelTitulo);
            panelMiInfo.Controls.Add(groupBoxInfo);
            panelMiInfo.Location = new Point(3, 3);
            panelMiInfo.Name = "panelMiInfo";
            panelMiInfo.Size = new Size(821, 456);
            panelMiInfo.TabIndex = 14;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.BorderStyle = BorderStyle.Fixed3D;
            labelTitulo.Font = new Font("Segoe UI", 20F);
            labelTitulo.Location = new Point(39, 15);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(315, 39);
            labelTitulo.TabIndex = 17;
            labelTitulo.Text = "MIS DATOS PERSONALES";
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.Controls.Add(labelTipoPersonaValue);
            groupBoxInfo.Controls.Add(labelTipoPersona);
            groupBoxInfo.Controls.Add(labelEspecialidadValue);
            groupBoxInfo.Controls.Add(labelLegajoValue);
            groupBoxInfo.Controls.Add(labelEmailValue);
            groupBoxInfo.Controls.Add(labelPlanValue);
            groupBoxInfo.Controls.Add(labelDireccionValue);
            groupBoxInfo.Controls.Add(labelTelefonoValue);
            groupBoxInfo.Controls.Add(labelLegajo);
            groupBoxInfo.Controls.Add(labelEmail);
            groupBoxInfo.Controls.Add(labelDireccion);
            groupBoxInfo.Controls.Add(labelPlan);
            groupBoxInfo.Controls.Add(labelEspecialidad);
            groupBoxInfo.Controls.Add(labelTelefono);
            groupBoxInfo.Location = new Point(39, 82);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Size = new Size(736, 338);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            // 
            // labelTipoPersonaValue
            // 
            labelTipoPersonaValue.AutoSize = true;
            labelTipoPersonaValue.Font = new Font("Segoe UI", 13F);
            labelTipoPersonaValue.Location = new Point(183, 248);
            labelTipoPersonaValue.Name = "labelTipoPersonaValue";
            labelTipoPersonaValue.Size = new Size(139, 25);
            labelTipoPersonaValue.TabIndex = 13;
            labelTipoPersonaValue.Text = "Tipo de Persona";
            // 
            // labelTipoPersona
            // 
            labelTipoPersona.AutoSize = true;
            labelTipoPersona.Font = new Font("Segoe UI", 13F);
            labelTipoPersona.Location = new Point(34, 248);
            labelTipoPersona.Name = "labelTipoPersona";
            labelTipoPersona.Size = new Size(143, 25);
            labelTipoPersona.TabIndex = 12;
            labelTipoPersona.Text = "Tipo de Persona:";
            // 
            // labelEspecialidadValue
            // 
            labelEspecialidadValue.AutoSize = true;
            labelEspecialidadValue.Font = new Font("Segoe UI", 13F);
            labelEspecialidadValue.Location = new Point(412, 182);
            labelEspecialidadValue.Name = "labelEspecialidadValue";
            labelEspecialidadValue.Size = new Size(109, 25);
            labelEspecialidadValue.TabIndex = 11;
            labelEspecialidadValue.Text = "Especialidad";
            // 
            // labelLegajoValue
            // 
            labelLegajoValue.AutoSize = true;
            labelLegajoValue.Font = new Font("Segoe UI", 13F);
            labelLegajoValue.Location = new Point(106, 47);
            labelLegajoValue.Name = "labelLegajoValue";
            labelLegajoValue.Size = new Size(64, 25);
            labelLegajoValue.TabIndex = 10;
            labelLegajoValue.Text = "Legajo";
            // 
            // labelEmailValue
            // 
            labelEmailValue.AutoSize = true;
            labelEmailValue.Font = new Font("Segoe UI", 13F);
            labelEmailValue.Location = new Point(357, 47);
            labelEmailValue.Name = "labelEmailValue";
            labelEmailValue.Size = new Size(54, 25);
            labelEmailValue.TabIndex = 9;
            labelEmailValue.Text = "Email";
            // 
            // labelPlanValue
            // 
            labelPlanValue.AutoSize = true;
            labelPlanValue.Font = new Font("Segoe UI", 13F);
            labelPlanValue.Location = new Point(89, 182);
            labelPlanValue.Name = "labelPlanValue";
            labelPlanValue.Size = new Size(45, 25);
            labelPlanValue.TabIndex = 8;
            labelPlanValue.Text = "Plan";
            // 
            // labelDireccionValue
            // 
            labelDireccionValue.AutoSize = true;
            labelDireccionValue.Font = new Font("Segoe UI", 13F);
            labelDireccionValue.Location = new Point(129, 112);
            labelDireccionValue.Name = "labelDireccionValue";
            labelDireccionValue.Size = new Size(85, 25);
            labelDireccionValue.TabIndex = 7;
            labelDireccionValue.Text = "Dirección";
            // 
            // labelTelefonoValue
            // 
            labelTelefonoValue.AutoSize = true;
            labelTelefonoValue.Font = new Font("Segoe UI", 13F);
            labelTelefonoValue.Location = new Point(382, 112);
            labelTelefonoValue.Name = "labelTelefonoValue";
            labelTelefonoValue.Size = new Size(79, 25);
            labelTelefonoValue.TabIndex = 6;
            labelTelefonoValue.Text = "Teléfono";
            // 
            // labelLegajo
            // 
            labelLegajo.AutoSize = true;
            labelLegajo.Font = new Font("Segoe UI", 13F);
            labelLegajo.Location = new Point(32, 47);
            labelLegajo.Name = "labelLegajo";
            labelLegajo.Size = new Size(68, 25);
            labelLegajo.TabIndex = 5;
            labelLegajo.Text = "Legajo:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 13F);
            labelEmail.Location = new Point(293, 47);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(58, 25);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "Email:";
            // 
            // labelDireccion
            // 
            labelDireccion.AutoSize = true;
            labelDireccion.Font = new Font("Segoe UI", 13F);
            labelDireccion.Location = new Point(34, 112);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(89, 25);
            labelDireccion.TabIndex = 3;
            labelDireccion.Text = "Dirección:";
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Font = new Font("Segoe UI", 13F);
            labelPlan.Location = new Point(34, 182);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(49, 25);
            labelPlan.TabIndex = 2;
            labelPlan.Text = "Plan:";
            // 
            // labelEspecialidad
            // 
            labelEspecialidad.AutoSize = true;
            labelEspecialidad.Font = new Font("Segoe UI", 13F);
            labelEspecialidad.Location = new Point(293, 182);
            labelEspecialidad.Name = "labelEspecialidad";
            labelEspecialidad.Size = new Size(113, 25);
            labelEspecialidad.TabIndex = 1;
            labelEspecialidad.Text = "Especialidad:";
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Font = new Font("Segoe UI", 13F);
            labelTelefono.Location = new Point(293, 112);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(83, 25);
            labelTelefono.TabIndex = 0;
            labelTelefono.Text = "Teléfono:";
            // 
            // PersonasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 462);
            Controls.Add(panelMiInfo);
            Controls.Add(buttonListar);
            Controls.Add(buscarTextBox);
            Controls.Add(buttonListar2);
            Controls.Add(buttonListarDocentes);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonModificar);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonListarAlumnos);
            Controls.Add(dgvPersonas);
            Name = "PersonasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personas";
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            panelMiInfo.ResumeLayout(false);
            panelMiInfo.PerformLayout();
            groupBoxInfo.ResumeLayout(false);
            groupBoxInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEliminar;
        private Button buttonModificar;
        private Button buttonAgregar;
        private Button buttonListarAlumnos;
        private DataGridView dgvPersonas;
        private Button buttonListarDocentes;
        private Button buttonListar2;
        private TextBox buscarTextBox;
        private Button buttonListar;
        private Panel panelMiInfo;
        private Label labelTitulo;
        private GroupBox groupBoxInfo;
        private Label labelEspecialidadValue;
        private Label labelLegajoValue;
        private Label labelEmailValue;
        private Label labelPlanValue;
        private Label labelDireccionValue;
        private Label labelTelefonoValue;
        private Label labelLegajo;
        private Label labelEmail;
        private Label labelDireccion;
        private Label labelPlan;
        private Label labelEspecialidad;
        private Label labelTelefono;
        private Label labelTipoPersonaValue;
        private Label labelTipoPersona;
    }
}