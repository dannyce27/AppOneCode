        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppOneCode.Modelo;

namespace AppOneCode.Vista
{
    public partial class FrmAgregarTareas : Form
    {

        private readonly string connectionString = @"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";


        public FrmAgregarTareas()
        {
            InitializeComponent();
            CargarEmpleados();
            CargarPrioridades();
            CargarEstados();
            CargarDatos();
            CargaProyectos();

            dgvMostrarProyectosI.ReadOnly = true;
        }

        private void FrmAgregarTareas_Load(object sender, EventArgs e)
        {
            // Configurar el formato de los DateTimePicker
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy"; // Formato día/mes/año

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy"; // Formato día/mes/año

            cmbFrecuenciaRepeticion.Items.AddRange(new string[] { "Ninguna", "Diaria", "Semanal", "Mensual" });
            cmbFrecuenciaRepeticion.SelectedIndex = 0;

            // Obtener el ID del usuario actual
            int usuarioId = Usuario.UsuarioId;

            // Obtener el rol del usuario
            int idRol = ObtenerIdRol(usuarioId);

            // Ocultar el botón si el rol es 3 (Comentarista) o 4 (Cliente)
            if (idRol == 3 || idRol == 4)
            {
                pbEliminarProyecto.Visible = false;
            }

            if (idRol == 4)
            {
                pbEliminarProyecto.Visible = false;
                pbAgregarProyecto.Visible = false;
            }
        }
        private void CargarEmpleados()
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Username FROM Users";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Crea una lista para almacenar los datos
                    Dictionary<int, string> empleados = new Dictionary<int, string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);

                        // Agrega el id y el nombre a la lista
                        empleados.Add(id, username);
                    }

                    // Asigna los datos al ComboBox
                    cmbEmpleadoAsignado.DataSource = new BindingSource(empleados, null);
                    cmbEmpleadoAsignado.ValueMember = "Key"; // Lo que se muestra
                    cmbEmpleadoAsignado.DisplayMember = "Value";    // El valor interno
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargaProyectos()
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre FROM Trabajo";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Crea una lista para almacenar los datos
                    Dictionary<int, string> Proyectos = new Dictionary<int, string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);

                        // Agrega el id y el nombre a la lista
                        Proyectos.Add(id, username);
                    }

                    // Asigna los datos al ComboBox
                    cmbProyectos.DataSource = new BindingSource(Proyectos, null);
                    cmbProyectos.DisplayMember = "Value"; // Lo que se muestra
                    cmbProyectos.ValueMember = "Key";    // El valor interno
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar Proyectos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarPrioridades()
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, NombrePrioridad FROM Prioridad";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Crea una lista para almacenar los datos
                    Dictionary<int, string> prioridades = new Dictionary<int, string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombrePrioridad = reader.GetString(1);

                        // Agrega el id y el nombre al diccionario
                        prioridades.Add(id, nombrePrioridad);
                    }

                    // Asigna los datos al ComboBox
                    cmbPrioridad.DataSource = new BindingSource(prioridades, null);
                    cmbPrioridad.DisplayMember = "Value"; // Lo que se muestra
                    cmbPrioridad.ValueMember = "Key";    // El valor interno
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar prioridades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void CargarEstados()
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, NombreEstado FROM Estado"; // Ajusta 'Nombre' según el nombre real de tu columna.

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Crea un diccionario para almacenar los datos
                    Dictionary<int, string> estados = new Dictionary<int, string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);        // Id del estado
                        string nombreEstado = reader.GetString(1); // Nombre del estado

                        // Agrega el id y el nombre al diccionario
                        estados.Add(id, nombreEstado);
                    }

                    // Asigna los datos al ComboBox
                    cmbEstado.DataSource = new BindingSource(estados, null);
                    cmbEstado.DisplayMember = "Value"; // Lo que se muestra
                    cmbEstado.ValueMember = "Key";    // El valor interno
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void pbAgregarProyecto_Click(object sender, EventArgs e)
        {
            // Verifica que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDescP.Text) ||
                cmbEmpleadoAsignado.SelectedValue == null ||
                cmbPrioridad.SelectedValue == null ||
                cmbEstado.SelectedValue == null)
            {
                MessageBox.Show("Por favor, completa todos los campos antes de agregar la tarea.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string descripcion = txtDescP.Text;
            string usuarioNombre = cmbEmpleadoAsignado.Text;
            int usuarioId = Convert.ToInt32(cmbEmpleadoAsignado.SelectedValue);
            string prioridad = cmbPrioridad.Text;
            string estado = cmbEstado.Text;
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFinalizacion = dtpFechaFinalizacion.Value;
            string nombreProyecto = cmbProyectos.Text;
            int idProyecto = Convert.ToInt32(cmbProyectos.SelectedValue);
            string frecuenciaRepeticion = cmbFrecuenciaRepeticion.SelectedItem.ToString();

            string emailUsuario = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Email FROM Users WHERE Id = @UsuarioId", con);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) emailUsuario = reader["Email"].ToString();
            }

         
            Tareas2 nuevaTarea = new Tareas2
            {
                Descripcion = txtDescP.Text,
                Usuario = cmbEmpleadoAsignado.Text,
                Prioridad = cmbPrioridad.Text,
                Estado = cmbEstado.Text,
                FechaInicio = dtpFechaInicio.Value, 
                FechaFinalizacion = dtpFechaFinalizacion.Value,
                Trabajo = cmbProyectos.Text,
                FrecuenciaRepeticion = cmbFrecuenciaRepeticion.Text

            };

          
            bool resultado = nuevaTarea.InsertarTarea();

            // Verifica si la tarea fue agregada correctamente
            if (resultado)
            {
                MessageBox.Show("Tarea agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Enviar correo de notificación
                EmailService emailService = new EmailService();
                emailService.EnviarNotificacionTarea(emailUsuario, usuarioNombre, nombreProyecto, descripcion);


                // Si la frecuencia de repetición no es "Ninguna", crear tareas repetitivas
                if (cmbFrecuenciaRepeticion.SelectedItem.ToString() != "Ninguna")
                {
                    CrearTareasRepetitivas(nuevaTarea, cmbFrecuenciaRepeticion.SelectedItem.ToString());
                }

                // Limpia los campos del formulario
                txtDescP.Clear();
                cmbEmpleadoAsignado.SelectedIndex = -1;
                cmbPrioridad.SelectedIndex = -1;
                cmbEstado.SelectedIndex = -1;
                dtpFechaInicio.Value = DateTime.Now;  // Reinicia la fecha al día actual
                dtpFechaFinalizacion.Value = DateTime.Now; // Reinicia la fecha al día actual
                cmbProyectos.SelectedIndex = -1;
                cmbFrecuenciaRepeticion.SelectedIndex = -1;
                CargarDatos();  // Recargar datos en la interfaz
            }
            else
            {
                MessageBox.Show("Error al agregar la tarea. Verifica los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {

            Tareas2 tareaModelo = new Tareas2();


            List<Tareas2> tareasList = tareaModelo.CargarTareas();

            // Asignar la lista de tareas al DataGridView
            dgvMostrarProyectosI.DataSource = tareasList;


            dgvMostrarProyectosI.Columns["Id"].Visible = false;
            dgvMostrarProyectosI.Columns["Descripcion"].HeaderText = "Descripción";
            dgvMostrarProyectosI.Columns["Usuario"].HeaderText = "Empleado Asignado";
            dgvMostrarProyectosI.Columns["Prioridad"].HeaderText = "Prioridad";
            dgvMostrarProyectosI.Columns["FechaInicio"].HeaderText = "Fecha de Inicio";
            dgvMostrarProyectosI.Columns["FechaFinalizacion"].HeaderText = "Fecha de Finalización";
       
            dgvMostrarProyectosI.Columns["frecuenciaRepeticion"].HeaderText = "Frecuencia de Repeticion";
         




        }

        private void txtEncargadoProyecto_TextChanged(object sender, EventArgs e)
        {

        }
        public static int ObtenerIdRol(int usuarioId)
        {
            int idRol = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;"))
                {
                    conn.Open();
                    string query = "SELECT idTipoUsuario FROM Users WHERE Id = @usuarioId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                        idRol = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el rol del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return idRol;
        }

        private void pbEliminarProyecto_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dgvMostrarProyectosI.SelectedRows.Count > 0)
            {
                // Obtener el Id de la tarea seleccionada (asumo que la columna Id está en la posición 0)
                int tareaId = Convert.ToInt32(dgvMostrarProyectosI.SelectedRows[0].Cells["Id"].Value);

                // Crear una instancia del modelo de Tareas2
                Tareas2 tareaModelo = new Tareas2();
                tareaModelo.Id = tareaId;  // Asignar el Id de la tarea a eliminar

                // Eliminar la tarea
                bool resultado = tareaModelo.EliminarTarea();

                if (resultado)
                {
                    MessageBox.Show("La tarea ha sido eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Volver a cargar los datos para reflejar el cambio
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar la tarea. Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una tarea para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbActualizarProyecto_Click(object sender, EventArgs e)
        {

            if (dgvMostrarProyectosI.SelectedRows.Count > 0)
            {

                int tareaId = Convert.ToInt32(dgvMostrarProyectosI.SelectedRows[0].Cells["Id"].Value);


                if (cmbEmpleadoAsignado.SelectedItem == null || cmbEmpleadoAsignado.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecciona un empleado para la tarea.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                Tareas2 tareaModelo = new Tareas2();
                tareaModelo.Id = tareaId;
                tareaModelo.Descripcion = txtDescP.Text;
                tareaModelo.Usuario = cmbEmpleadoAsignado.SelectedItem.ToString();
                tareaModelo.Prioridad = cmbPrioridad.SelectedItem.ToString();
                tareaModelo.Estado = cmbEstado.SelectedItem.ToString();
                tareaModelo.FechaInicio = dtpFechaInicio.Value;
                tareaModelo.FechaFinalizacion = dtpFechaFinalizacion.Value;
                tareaModelo.Trabajo = cmbProyectos.SelectedItem.ToString();


                bool resultado = tareaModelo.ActualizarTarea();

                if (resultado)
                {
                    MessageBox.Show("La tarea ha sido actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Volver a cargar los datos para reflejar el cambio
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar la tarea. Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una tarea para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmTareas fmT = new FrmTareas();
            this.Close();
            fmT.ShowDialog();
        }

        private void botonPersonalizado1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFinalizacion = dtpFechaFinalizacion.Value.Date;

            // Verificar que la fecha de inicio no sea mayor a la de finalización
            if (fechaInicio > fechaFinalizacion)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de finalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Tareas2 tareaModelo = new Tareas2();
            List<Tareas2> tareasFiltradas = tareaModelo.BuscarTareasPorFecha(fechaInicio, fechaFinalizacion);

            // Verificar si la lista tiene datos
            if (tareasFiltradas.Count > 0)
            {
                dgvMostrarProyectosI.DataSource = tareasFiltradas;
            }
            else
            {
                MessageBox.Show("No se encontraron tareas en el rango de fechas seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvMostrarProyectosI.DataSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tareas2 tareaModelo = new Tareas2();
            string searchCriteria = txtSearchProyect.Text.Trim();


            List<Tareas2> resultados = tareaModelo.BuscarTareas(searchCriteria);


            dgvMostrarProyectosI.DataSource = resultados;
        }

        private void botonPersonalizado1_Click_1(object sender, EventArgs e)
        {


            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFinalizacion = dtpFechaFinalizacion.Value.Date;


            if (fechaInicio > fechaFinalizacion)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de finalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Tareas2 tareaModelo = new Tareas2();
            List<Tareas2> tareasFiltradas = tareaModelo.BuscarTareasPorFecha(fechaInicio, fechaFinalizacion);


            if (tareasFiltradas.Count > 0)
            {
                dgvMostrarProyectosI.DataSource = tareasFiltradas;
                MessageBox.Show($"Se encontraron {tareasFiltradas.Count} tareas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontraron tareas en el rango de fechas seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void botonPersonalizado2_Click(object sender, EventArgs e)
        {
            Tareas2 tareaModelo = new Tareas2();

            string searchCriteria = txtSearchProyect.Text.Trim();

            List<Tareas2> resultados = tareaModelo.BuscarTareas(searchCriteria);

            dgvMostrarProyectosI.DataSource = resultados;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CrearTareasRepetitivas(Tareas2 tareaPrincipal, string frecuenciaRepeticion)
        {
            DateTime fechaInicio = tareaPrincipal.FechaInicio;
            DateTime fechaFinalizacion = tareaPrincipal.FechaFinalizacion;

            switch (frecuenciaRepeticion)
            {
                case "Diaria":
                    // Crear tareas diarias hasta la fecha de finalización
                    for (DateTime fecha = fechaInicio.AddDays(1); fecha <= fechaFinalizacion; fecha = fecha.AddDays(1))
                    {
                        CrearTareaRepetitiva(tareaPrincipal, fecha);
                    }
                    break;

                case "Semanal":
                    // Crear tareas semanales (cada lunes) hasta la fecha de finalización
                    for (DateTime fecha = fechaInicio.AddDays(7); fecha <= fechaFinalizacion; fecha = fecha.AddDays(7))
                    {
                        CrearTareaRepetitiva(tareaPrincipal, fecha);
                    }
                    break;

                case "Mensual":
                    // Crear tareas mensuales (el mismo día del mes) hasta la fecha de finalización
                    for (DateTime fecha = fechaInicio.AddMonths(1); fecha <= fechaFinalizacion; fecha = fecha.AddMonths(1))
                    {
                        CrearTareaRepetitiva(tareaPrincipal, fecha);
                    }
                    break;
            }
        }

        private void CrearTareaRepetitiva(Tareas2 tareaPrincipal, DateTime fecha)
        {
            Tareas2 tareaRepetitiva = new Tareas2
            {
                Descripcion = tareaPrincipal.Descripcion,
                Usuario = tareaPrincipal.Usuario,
                Prioridad = tareaPrincipal.Prioridad,
                Estado = tareaPrincipal.Estado,
                FechaInicio = fecha,
                FechaFinalizacion = fecha,
                Trabajo = tareaPrincipal.Trabajo,
                FrecuenciaRepeticion = tareaPrincipal.FrecuenciaRepeticion
            };

          
            bool resultado = tareaRepetitiva.InsertarTarea();

            if (!resultado)
            {
                MessageBox.Show($"Error al crear la tarea repetitiva para la fecha {fecha.ToShortDateString()}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
