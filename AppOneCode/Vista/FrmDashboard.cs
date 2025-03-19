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
        private readonly string connectionString = @"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";



        public FrmDashboard()
        {
            InitializeComponent();
            CargaProyectos();
            CargarAreasTrabajo();
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

                    
                    Dictionary<int, string> Proyectos = new Dictionary<int, string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);

                        
                        Proyectos.Add(id, username);
                    }


                    cmbProyectos.DataSource = new BindingSource(Proyectos, null);
                    cmbProyectos.DisplayMember = "Value";
                    cmbProyectos.ValueMember = "Key";   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar Proyectos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarAreasTrabajo()
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, NombreArea FROM AreaTrabajo";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                   
                    Dictionary<int, string> Proyectos = new Dictionary<int, string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);

                        
                        Proyectos.Add(id, username);
                    }

                    // Asigna los datos al ComboBox
                    cmbAreaTrabajo.DataSource = new BindingSource(Proyectos, null);
                    cmbAreaTrabajo.DisplayMember = "Value";
                    cmbAreaTrabajo.ValueMember = "Key";   
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

                        
                        ctEmpleadosEficientes.Series["Series1"].Points.Clear();

                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            int cantidadCompletadas = Convert.ToInt32(reader["CantidadCompletadas"]);

                           
                            var punto = ctEmpleadosEficientes.Series["Series1"].Points.AddXY(username, cantidadCompletadas);

                          
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

                      
                        ctTareasCompletadas.Series["Series1"].Points.Clear();

                        while (reader.Read())
                        {
                            DateTime fecha = Convert.ToDateTime(reader["Fecha"]);
                            int cantidadCompletadas = Convert.ToInt32(reader["CantidadCompletadas"]);

                         
                            var punto = ctTareasCompletadas.Series["Series1"].Points.AddXY(fecha.ToShortDateString(), cantidadCompletadas);

                           
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
              
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                  
                    string queryTotalTareas = @"
            SELECT COUNT(*) 
            FROM Tareas 
            WHERE idProyecto = @idProyecto";

                    SqlCommand cmdTotalTareas = new SqlCommand(queryTotalTareas, conn);
                    cmdTotalTareas.Parameters.AddWithValue("@idProyecto", idProyecto);

                    int totalTareas = (int)cmdTotalTareas.ExecuteScalar();

                  
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
            
            int idProyecto = (int)((KeyValuePair<int, string>)cmbProyectos.SelectedItem).Key;

           
            CargarPorcentajeProyectos(idProyecto);
        }

        private void btnBuscarProyectos_Click(object sender, EventArgs e)
        {
            try
            {
               
                int idProyecto = (int)((KeyValuePair<int, string>)cmbProyectos.SelectedItem).Key;

                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string queryTotalTareas = @"
                SELECT COUNT(*) 
                FROM Tareas 
                WHERE idProyecto = @IdProyecto";

                    SqlCommand cmdTotalTareas = new SqlCommand(queryTotalTareas, conn);
                    cmdTotalTareas.Parameters.AddWithValue("@IdProyecto", idProyecto);

                    int totalTareas = (int)cmdTotalTareas.ExecuteScalar();

                   
                    string queryTareasCompletadas = @"
                SELECT COUNT(*) 
                FROM Tareas 
                WHERE idProyecto = @IdProyecto 
                  AND EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = 'Completada')";

                    SqlCommand cmdTareasCompletadas = new SqlCommand(queryTareasCompletadas, conn);
                    cmdTareasCompletadas.Parameters.AddWithValue("@IdProyecto", idProyecto);

                    int tareasCompletadas = (int)cmdTareasCompletadas.ExecuteScalar();

                   
                    double porcentajeCompletado = totalTareas > 0 ? ((double)tareasCompletadas / totalTareas) * 100 : 0;

                  
                    ctPorcentajeProyectos.Series["Series1"].Points.Clear();

                  
                    ctPorcentajeProyectos.Series["Series1"].Points.AddXY("Completadas", porcentajeCompletado);
                    ctPorcentajeProyectos.Series["Series1"].Points.AddXY("Pendientes", 100 - porcentajeCompletado);

                 
                    ctPorcentajeProyectos.Series["Series1"].Points[0].Label = $"{porcentajeCompletado:F1}% Completadas";
                    ctPorcentajeProyectos.Series["Series1"].Points[1].Label = $"{100 - porcentajeCompletado:F1}% Pendientes";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular el porcentaje de tareas completadas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                ReportePDF.GenerarReporte();
                MessageBox.Show("Reporte generado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscarPorAT_Click(object sender, EventArgs e)
        {
            try
            {
                
                int idAreaTrabajo = (int)((KeyValuePair<int, string>)cmbAreaTrabajo.SelectedItem).Key;

                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                
                    string query = @"
                SELECT u.Username, COUNT(t.Id) AS CantidadTareas
                FROM Tareas t
                INNER JOIN Trabajo tr ON t.idProyecto = tr.Id
                INNER JOIN AreaTrabajo a ON tr.IdAreaTrabajo = a.Id
                INNER JOIN Users u ON t.UsuarioId = u.Id
                WHERE a.Id = @IdAreaTrabajo
                GROUP BY u.Username
                ORDER BY CantidadTareas DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdAreaTrabajo", idAreaTrabajo);

                       
                        SqlDataReader reader = cmd.ExecuteReader();

                      
                        ctEmpleadosEficientes.Series["Series1"].Points.Clear();

                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            int cantidadTareas = Convert.ToInt32(reader["CantidadTareas"]);

                            var punto = ctEmpleadosEficientes.Series["Series1"].Points.AddXY(username, cantidadTareas);

                           
                            ctEmpleadosEficientes.Series["Series1"].Points.Last().Label = $"{username} ({cantidadTareas})";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar tareas por área de trabajo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAreaTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
