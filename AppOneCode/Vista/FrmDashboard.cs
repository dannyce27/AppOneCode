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
    public partial class FrmDashboard : Form

        
    {
        bool sideBarexoand;
        private readonly string connectionString = @"Server=DESKTOP-2I6K8G4\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";


        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            Usuario Usuario = new Usuario();


            int userCount = Usuario.ContarUsuarios();

            Tareas Tareas = new Tareas();

            int idProyecto = Tareas.Id;
            lblUserCount.Text = $"{userCount}";

            CargarDatosEmpleadosEficientes();
            CargarDatosTareasCompletadasPorDia();
            CargarNumeroTareasCompletadas();
            CargarNumeroTareasPendientes();
            CargarPorcentajeProyectos(idProyecto);
            CargaProyectos();

        }


        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatosEmpleadosEficientes()
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT u.Username, COUNT(t.Id) AS CantidadCompletadas
                FROM Users u
                JOIN Tareas t ON u.Id = t.UsuarioId
                WHERE t.EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = 'Completada')
                GROUP BY u.Username
                ORDER BY CantidadCompletadas DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Limpiar los datos existentes en el gráfico
                        ctEmpleadosEficientes.Series["Series1"].Points.Clear();

                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            int cantidadCompletadas = Convert.ToInt32(reader["CantidadCompletadas"]);

                            // Añadir los puntos al gráfico
                            var punto = ctEmpleadosEficientes.Series["Series1"].Points.AddXY(username, cantidadCompletadas);

                            // Establecer el valor como etiqueta
                            ctEmpleadosEficientes.Series["Series1"].Points.Last().Label = $"{username} ({cantidadCompletadas})";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos de empleados eficientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosTareasCompletadasPorDia()
        {
            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT CAST(t.FechaFinalizacion AS DATE) AS Fecha, COUNT(t.Id) AS CantidadCompletadas
                FROM Tareas t
                WHERE t.EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = 'Completada')
                GROUP BY CAST(t.FechaFinalizacion AS DATE)
                ORDER BY Fecha";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Limpiar los datos existentes en el gráfico
                        ctTareasCompletadas.Series["Series1"].Points.Clear();

                        while (reader.Read())
                        {
                            DateTime fecha = Convert.ToDateTime(reader["Fecha"]);
                            int cantidadCompletadas = Convert.ToInt32(reader["CantidadCompletadas"]);

                            // Añadir los puntos al gráfico
                            var punto = ctTareasCompletadas.Series["Series1"].Points.AddXY(fecha.ToShortDateString(), cantidadCompletadas);

                            // Establecer el valor como etiqueta
                            ctTareasCompletadas.Series["Series1"].Points.Last().Label = $"{cantidadCompletadas} ({fecha.ToShortDateString()})";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos de tareas completadas por día: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarNumeroTareasCompletadas()
        {
            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                   SELECT COUNT(*) 
                   FROM Tareas 
                   WHERE EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = 'Completada')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int cantidadCompletadas = (int)cmd.ExecuteScalar();

                        // Mostrar el número de tareas completadas en el label
                        lblTareasCompletadas.Text = $"{cantidadCompletadas}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el número de tareas completadas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarNumeroTareasPendientes()
        {
            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) 
                FROM Tareas 
                WHERE EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = 'Pendiente')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int cantidadPendientes = (int)cmd.ExecuteScalar();

                        // Mostrar el número de tareas pendientes en el label
                        lblTareasPendientes.Text = $"{cantidadPendientes}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el número de tareas pendientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPorcentajeProyectos(int idProyecto)
        {
            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Consultar el número total de tareas del proyecto
                    string queryTotalTareas = @"
            SELECT COUNT(*) 
            FROM Tareas 
            WHERE idProyecto = @idProyecto";

                    SqlCommand cmdTotalTareas = new SqlCommand(queryTotalTareas, conn);
                    cmdTotalTareas.Parameters.AddWithValue("@idProyecto", idProyecto);

                    int totalTareas = (int)cmdTotalTareas.ExecuteScalar();

                    // Consultar el número de tareas completadas del proyecto
                    string queryTareasCompletadas = @"
            SELECT COUNT(*) 
            FROM Tareas 
            WHERE idProyecto = @idProyecto AND EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = 'Completada')";

                    SqlCommand cmdTareasCompletadas = new SqlCommand(queryTareasCompletadas, conn);
                    cmdTareasCompletadas.Parameters.AddWithValue("@idProyecto", idProyecto);

                    int tareasCompletadas = (int)cmdTareasCompletadas.ExecuteScalar();

                    // Calcular el porcentaje de tareas completadas
                    double porcentajeCompletado = totalTareas > 0 ? ((double)tareasCompletadas / totalTareas) * 100 : 0;

                    // Limpiar datos previos del gráfico
                    ctPorcentajeProyectos.Series["Series1"].Points.Clear();

                    // Mostrar el porcentaje de tareas completadas y pendientes en el gráfico
                    ctPorcentajeProyectos.Series["Series1"].Points.AddXY("Completadas", porcentajeCompletado);
                    ctPorcentajeProyectos.Series["Series1"].Points.AddXY("Pendientes", 100 - porcentajeCompletado);

                    // Etiquetas en los puntos del gráfico
                    ctPorcentajeProyectos.Series["Series1"].Points[0].Label = $"{porcentajeCompletado:F1}% Completadas";
                    ctPorcentajeProyectos.Series["Series1"].Points[1].Label = $"{100 - porcentajeCompletado:F1}% Pendientes";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el porcentaje de proyectos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void ctPorcentajeProyectos_Click(object sender, EventArgs e)
        {
            // Obtener el Id del proyecto seleccionado en el ComboBox
            int idProyecto = (int)((KeyValuePair<int, string>)cmbProyectos.SelectedItem).Key;

            // Llamar al método que carga el porcentaje de tareas del proyecto seleccionado
            CargarPorcentajeProyectos(idProyecto);
        }

        private void btnBuscarProyectos_Click(object sender, EventArgs e)
        {

        }

        private void lblUserCount_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void lblTareasCompletadas_Click(object sender, EventArgs e)
        {

        }

        private void s(object sender, EventArgs e)
        {
            if (sideBarexoand)
            {

                sideBarContainer.Width -= 10;
                if (sideBarContainer.Width == sideBarContainer.MinimumSize.Width)
                {

                    sideBarexoand = false;
                    SidebarTime.Stop();



                }
            }
            else
            {

                sideBarContainer.Width += 10;
                if (sideBarContainer.Width == sideBarContainer.MaximumSize.Width)
                {

                    sideBarexoand = true;
                    SidebarTime.Stop();

                }

            }
        }

        private void FiltrarTareasPorEstado(string estado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT u.Username, COUNT(t.Id) AS Cantidad
                FROM Users u
                JOIN Tareas t ON u.Id = t.UsuarioId
                WHERE t.EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = @Estado)
                GROUP BY u.Username
                ORDER BY Cantidad DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Estado", estado);
                        SqlDataReader reader = cmd.ExecuteReader();

                        ctEmpleadosEficientes.Series["Series1"].Points.Clear();

                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            int cantidad = Convert.ToInt32(reader["Cantidad"]);

                            ctEmpleadosEficientes.Series["Series1"].Points.AddXY(username, cantidad);
                            ctEmpleadosEficientes.Series["Series1"].Points.Last().Label = $"{username} ({cantidad})";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar tareas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SidebarTime.Start();
        }

        private void lblTareasPendientes_Click(object sender, EventArgs e)
        {

        }

        private void cmbProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFiltroCompletadas_Click(object sender, EventArgs e)
        {
            FiltrarTareasPorEstado("Completada");
        }

        private void btnFiltroPendientes_Click(object sender, EventArgs e)
        {
            FiltrarTareasPorEstado("Pendiente");    
        }

        private void btnFiltroTrabajando_Click(object sender, EventArgs e)
        {
            FiltrarTareasPorEstado("Trabajando");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

            ReportePDF.GenerarReporte();
            MessageBox.Show("Reporte generado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
