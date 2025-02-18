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

        private readonly string connectionString = @"Server=DESKTOP-2I6K8G4\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";

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

            // Crea una nueva instancia de la clase Tareas2
            Tareas2 nuevaTarea = new Tareas2
            {
                Descripcion = txtDescP.Text,
                Usuario = cmbEmpleadoAsignado.Text,
                Prioridad = cmbPrioridad.Text,
                Estado = cmbEstado.Text,
                FechaInicio = dtpFechaInicio.Value,  // Obtiene la fecha del DateTimePicker
                FechaFinalizacion = dtpFechaFinalizacion.Value, // Obtiene la fecha final
                Trabajo = cmbProyectos.Text
            };

            // Llama al método InsertarTarea para agregar la tarea
            bool resultado = nuevaTarea.InsertarTarea();

            // Verifica si la tarea fue agregada correctamente
            if (resultado)
            {
                MessageBox.Show("Tarea agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpia los campos del formulario
                txtDescP.Clear();
                cmbEmpleadoAsignado.SelectedIndex = -1;
                cmbPrioridad.SelectedIndex = -1;
                cmbEstado.SelectedIndex = -1;
                dtpFechaInicio.Value = DateTime.Now;  // Reinicia la fecha al día actual
                dtpFechaFinalizacion.Value = DateTime.Now; // Reinicia la fecha al día actual
                cmbProyectos.SelectedIndex = -1;
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

            // Llamar al método CargarTareas para obtener las tareas
            List<Tareas2> tareasList = tareaModelo.CargarTareas();

            // Asignar la lista de tareas al DataGridView
            dgvMostrarProyectosI.DataSource = tareasList;

            // Opcionalmente, configurar algunas propiedades del DataGridView
            dgvMostrarProyectosI.Columns["Id"].Visible = false;  // Si no deseas mostrar la columna Id
            dgvMostrarProyectosI.Columns["Descripcion"].HeaderText = "Descripción";
            dgvMostrarProyectosI.Columns["Usuario"].HeaderText = "Empleado Asignado";
            dgvMostrarProyectosI.Columns["Prioridad"].HeaderText = "Prioridad";
            dgvMostrarProyectosI.Columns["Estado"].HeaderText = "Estado";
           



        }

        private void txtEncargadoProyecto_TextChanged(object sender, EventArgs e)
        {

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
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dgvMostrarProyectosI.SelectedRows.Count > 0)
            {
                // Obtener el Id de la tarea seleccionada (asumiendo que la columna Id está en la posición 0)
                int tareaId = Convert.ToInt32(dgvMostrarProyectosI.SelectedRows[0].Cells["Id"].Value);

                // Verificar que haya un empleado seleccionado en el ComboBox
                if (cmbEmpleadoAsignado.SelectedItem == null || cmbEmpleadoAsignado.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecciona un empleado para la tarea.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detener la ejecución si no se seleccionó un empleado
                }

                // Crear una instancia del modelo de Tareas2
                Tareas2 tareaModelo = new Tareas2();
                tareaModelo.Id = tareaId; 
                tareaModelo.Descripcion = txtDescP.Text;  
                tareaModelo.Usuario = cmbEmpleadoAsignado.SelectedItem.ToString();
                tareaModelo.Prioridad = cmbPrioridad.SelectedItem.ToString();
                tareaModelo.Estado = cmbEstado.SelectedItem.ToString();
                tareaModelo.FechaInicio = dtpFechaInicio.Value;
                tareaModelo.FechaFinalizacion = dtpFechaFinalizacion.Value;
                tareaModelo.Trabajo = cmbProyectos.SelectedItem.ToString();

                // Llamar al método de actualización
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

            // Obtener fechas de los DateTimePicker
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFinalizacion = dtpFechaFinalizacion.Value.Date;

            // Verificar que la fecha de inicio no sea mayor a la de finalización
            if (fechaInicio > fechaFinalizacion)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de finalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear instancia del modelo y llamar al método de búsqueda
            Tareas2 tareaModelo = new Tareas2();
            List<Tareas2> tareasFiltradas = tareaModelo.BuscarTareasPorFecha(fechaInicio, fechaFinalizacion);

            // Verificar si la lista tiene datos
            if (tareasFiltradas.Count > 0)
            {
                dgvMostrarProyectosI.DataSource = tareasFiltradas; // Mostrar en DataGridView
            }
            else
            {
                MessageBox.Show("No se encontraron tareas en el rango de fechas seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvMostrarProyectosI.DataSource = null; // Limpiar DataGridView si no hay datos
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

            // Obtener fechas de los DateTimePicker
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFinalizacion = dtpFechaFinalizacion.Value.Date;

            // Verificar que la fecha de inicio no sea mayor a la de finalización
            if (fechaInicio > fechaFinalizacion)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de finalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear instancia del modelo y llamar al método de búsqueda
            Tareas2 tareaModelo = new Tareas2();
            List<Tareas2> tareasFiltradas = tareaModelo.BuscarTareasPorFecha(fechaInicio, fechaFinalizacion);

            // Verificar si la lista tiene datos
            if (tareasFiltradas.Count > 0)
            {
                dgvMostrarProyectosI.DataSource = tareasFiltradas; // Mostrar en DataGridView

             
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
    }
}
