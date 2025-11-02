using Academia.WindowsForms.Helpers;

namespace Academia.WindowsForms.Views.Menu
{
    public partial class MenuForm : Form
    {
        private readonly RoleHelper _roleHelper;
        private readonly string _username;
        private readonly string _userRole;
        private readonly string _authToken;
        public MenuForm(string authToken, string username)
        {
            InitializeComponent();
            _authToken = authToken;
            _roleHelper = new RoleHelper(authToken);
            _username = username;
            _userRole = _roleHelper.GetCurrentUserRole();

            InitializeUIBasedOnRole();
            SetupUserInfo();
        }

        private void InitializeUIBasedOnRole()
        {
            switch (_userRole)
            {
                case "1": // Administrador
                    SetupAdminMenu();
                    break;
                case "2": // Docente
                    SetupDocenteMenu();
                    break;
                default: // Alumno
                    SetupAlumnoMenu();
                    break;
            }
        }

        private void SetupAdminMenu()
        {
            // Menú completo de administrador
            buttonUsuario.Visible = true;
            buttonEspecialidad.Visible = true;
            buttonPlan.Visible = true;
            buttonPersona.Visible = true;
            buttonComision.Visible = true;
            buttonMateria.Visible = true;
            buttonCurso.Visible = true;
            buttonDocenteCurso.Visible = true;
            buttonInscripcion.Visible = true;

            // Textos originales para admin
            buttonUsuario.Text = "Usuarios";
            buttonEspecialidad.Text = "Especialidades";
            buttonPlan.Text = "Planes";
            buttonPersona.Text = "Personas";
            buttonComision.Text = "Comisiones";
            buttonMateria.Text = "Materias";
            buttonCurso.Text = "Cursos";
            buttonDocenteCurso.Text = "Dictados";
            buttonInscripcion.Text = "Inscripciones";

            this.Text = "Sistema Académico - Administrador";
            labelRol.Text = "Rol:";
            labelRolDisplay.Text = "Administrador";
            labelRolDisplay.ForeColor = Color.Red;
        }

        private void SetupDocenteMenu()
        {
            // Menú para docente
            buttonUsuario.Visible = true; // Solo ver su usuario
            buttonEspecialidad.Visible = true; // Solo lectura
            buttonPlan.Visible = true; // Solo lectura
            buttonPersona.Visible = true; // Solo ver su persona
            buttonComision.Visible = true; // Solo lectura
            buttonMateria.Visible = true; // Solo lectura
            buttonCurso.Visible = true; // Solo lectura
            buttonDocenteCurso.Visible = true; // Ver sus dictados
            buttonInscripcion.Visible = true; // Calificar alumnos

            // Renombrar botones para contexto docente
            buttonUsuario.Text = "Mi Usuario";
            buttonPersona.Text = "Mis Datos Personales";
            buttonDocenteCurso.Text = "Mis Dictados";
            buttonInscripcion.Text = "Calificar Alumnos";
            buttonCurso.Text = "Cursos";
            buttonMateria.Text = "Materias";
            buttonComision.Text = "Comisiones";
            buttonPlan.Text = "Planes";
            buttonEspecialidad.Text = "Especialidades";

            this.Text = "Sistema Académico - Docente";
            labelRol.Text = "Rol:";
            labelRolDisplay.Text = "Docente";
            labelRolDisplay.ForeColor = Color.Blue;
        }

        private void SetupAlumnoMenu()
        {
            // Menú reducido para alumno
            buttonUsuario.Visible = true; // Solo ver su usuario
            buttonEspecialidad.Visible = true; // Solo lectura
            buttonPlan.Visible = true; // Solo lectura
            buttonPersona.Visible = true; // Solo ver su persona
            buttonComision.Visible = true; // Ver comisiones
            buttonMateria.Visible = true; // Ver materias
            buttonCurso.Visible = true; // Ver cursos
            buttonDocenteCurso.Visible = false; // No puede ver dictados
            buttonInscripcion.Visible = true; // Inscribirse y ver sus inscripciones

            // Renombrar botones para contexto alumno
            buttonUsuario.Text = "Mi Usuario";
            buttonPersona.Text = "Mis Datos Personales";
            buttonInscripcion.Text = "Mis Inscripciones";
            buttonCurso.Text = "Cursos Disponibles";
            buttonMateria.Text = "Materias";
            buttonComision.Text = "Comisiones";
            buttonPlan.Text = "Planes";
            buttonEspecialidad.Text = "Especialidades";

            this.Text = "Sistema Académico - Alumno";
            labelRol.Text = "Rol:";
            labelRolDisplay.Text = "Alumno";
            labelRolDisplay.ForeColor = Color.Green;
        }

        private void SetupUserInfo()
        {
            labelUsuario.Text = $"Usuario:   {_username}";
        }

        private void buttonUsuario_Click(object sender, EventArgs e)
        {
            OpenForm<UsuariosForm>();
        }

        private void buttonEspecialidad_Click(object sender, EventArgs e)
        {
            if (!_roleHelper.IsAdmin())
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenForm<EspecialidadesForm>();
        }

        private void buttonPlan_Click(object sender, EventArgs e)
        {
            if (!_roleHelper.IsAdmin())
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenForm<PlanesForm>();
        }

        private void buttonPersona_Click(object sender, EventArgs e)
        {
            OpenForm<PersonasForm>();
        }

        private void buttonComision_Click(object sender, EventArgs e)
        {
            if (!_roleHelper.IsAdmin())
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenForm<ComisionesForm>();
        }

        private void buttonMateria_Click(object sender, EventArgs e)
        {
            if (!_roleHelper.IsAdmin())
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenForm<MateriasForm>();
        }

        private void buttonCurso_Click(object sender, EventArgs e)
        {
            if (!_roleHelper.IsAdmin())
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenForm<CursosForm>();
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?",
                "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Limpiar sesión
                SessionManager.ClearSession();

                // Cerrar formulario actual
                this.Close();

                // Reiniciar aplicación para mostrar login
                Application.Restart();
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea salir del sistema?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Limpiar sesión antes de salir
                SessionManager.ClearSession();
                Application.Exit();
            }
        }

        private void buttonDocenteCurso_Click(object sender, EventArgs e)
        {
            if (!_roleHelper.IsAdminOrDocente())
            {
                MessageBox.Show("No tiene permisos para acceder a esta funcionalidad.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //OpenForm<DocenteCursosForm>();
        }

        private void buttonInscripcion_Click(object sender, EventArgs e)
        {
            // Todos los roles pueden acceder a inscripciones
            // pero cada uno verá información diferente según su rol
            // OpenForm<InscripcionesForm>();
        }

        private void OpenForm<T>() where T : Form, new()
        {
            this.Hide();
            using (T form = new T())
            {
                form.ShowDialog();
            }
            this.Show();
        }
    }
}
