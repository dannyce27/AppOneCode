using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace AppOneCode.Vista
{
    public partial class FrmCronometro : Form
    {
        private string cronometro;
        private Stopwatch stopwatch;
        private Conexion conexion;

        public FrmCronometro()
        {
            InitializeComponent();
            cronometro = "";
            stopwatch = new Stopwatch();
            conexion = new Conexion();  // Inicializamos la conexión aquí
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCronometro_Load(object sender, EventArgs e)
        {
            // Inicializar ListBox para que no dé errores
            lbMarcasTiempo.Items.Clear();

            // Cargar las marcas de tiempo desde la base de datos
            CargarMarcasDeTiempo();
        }

        private void pbPlay_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            tmrTimer.Enabled = true;
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)stopwatch.ElapsedMilliseconds);

            var hour = ts.Hours;
            var minute = ts.Minutes;
            var second = ts.Seconds;
            var ms = ts.Milliseconds;

            cronometro = $"{hour:D2}:{minute:D2}:{second:D2}:{ms:D3}";
            lblNumerosCrono.Text = cronometro;
        }

        private void pbPause_Click(object sender, EventArgs e)
        {
            stopwatch.Stop(); // Detiene el Stopwatch
            tmrTimer.Enabled = false; // Detiene el temporizador que actualiza la interfaz

            // Guardar marca de tiempo
            DateTime ahora = DateTime.Now;
            string marcaTiempo = $"Fecha: {ahora.ToShortDateString()} Hora: {ahora.ToLongTimeString()} | Tiempo: {cronometro}";

            // Agregar al ListBox
            lbMarcasTiempo.Items.Add(marcaTiempo);

            // Guardar en la base de datos
            GuardarMarcaDeTiempoEnBD(ahora, cronometro);
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            tmrTimer.Enabled = false;
            cronometro = "00:00:00:000";
            lblNumerosCrono.Text = cronometro;
        }

        private void lbMarcasTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Opcional: Realiza alguna acción al seleccionar un elemento en el ListBox
            string seleccion = lbMarcasTiempo.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(seleccion))
            {
                MessageBox.Show($"Marca seleccionada:\n{seleccion}", "Información");
            }
        }

        // Método para guardar las marcas de tiempo en la base de datos
        private void GuardarMarcaDeTiempoEnBD(DateTime fechaHora, string cronometro)
        {
            try
            {
                using (SqlConnection connection = conexion.OpenConnection())
                {
                    string query = "INSERT INTO MarcasDeTiempo (Fecha, Hora, Tiempo) VALUES (@Fecha, @Hora, @Tiempo)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", fechaHora.ToShortDateString());
                        command.Parameters.AddWithValue("@Hora", fechaHora.ToLongTimeString());
                        command.Parameters.AddWithValue("@Tiempo", cronometro);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Marca de tiempo guardada correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la marca de tiempo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar las marcas de tiempo desde la base de datos
        private void CargarMarcasDeTiempo()
        {
            try
            {
                using (SqlConnection connection = conexion.OpenConnection())
                {
                    string query = "SELECT Fecha, Hora, Tiempo FROM MarcasDeTiempo ORDER BY Fecha DESC, Hora DESC"; // Ordenar por fecha y hora
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string fecha = reader["Fecha"].ToString();
                            string hora = reader["Hora"].ToString();
                            string tiempo = reader["Tiempo"].ToString();
                            string marcaTiempo = $"Fecha: {fecha} Hora: {hora} | Tiempo: {tiempo}";

                            lbMarcasTiempo.Items.Add(marcaTiempo);  // Agregar al ListBox
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las marcas de tiempo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
