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

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            Usuario Usuario = new Usuario();


            int userCount = Usuario.ContarUsuarios();


            lblUserCount.Text = $"{userCount}";

            CargarDatosEmpleadosEficientes();
            CargarDatosTareasCompletadasPorDia();
            CargarNumeroTareasCompletadas();
            CargarNumeroTareasPendientes();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatosEmpleadosEficientes()
        {
            try
            {
                // Crear la conexión con la base de datos
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



        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
