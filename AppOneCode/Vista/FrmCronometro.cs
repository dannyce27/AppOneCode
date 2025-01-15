using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
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
            conexion = new Conexion(); // Inicializamos la conexión aquí
            notifyIconCronometro.Visible = false; // Para que el ícono no sea visible al principio
            ConfigurarNotifyIcon(); // Configurar el NotifyIcon
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // Obtener el tamaño de la pantalla
                Rectangle workingArea = Screen.GetWorkingArea(this);

                // Mover el formulario a la esquina inferior derecha
                this.Location = new Point(workingArea.Right - this.Width, workingArea.Bottom - this.Height);

                // Mantenerlo visible
                this.ShowInTaskbar = true;
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra la aplicación
        }

        private void FrmCronometro_Load(object sender, EventArgs e)
        {
            lbMarcasTiempo.Items.Clear(); // Limpia el ListBox al cargar
            CargarMarcasDeTiempo(); // Carga las marcas de tiempo desde la base de datos
        }

        private void pbPlay_Click(object sender, EventArgs e)
        {
            stopwatch.Start(); // Inicia el cronómetro
            tmrTimer.Enabled = true; // Habilita el temporizador
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)stopwatch.ElapsedMilliseconds);
            cronometro = $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}:{ts.Milliseconds:D3}";
            lblNumerosCrono.Text = cronometro; // Actualiza el tiempo en la interfaz
        }

        private void pbPause_Click(object sender, EventArgs e)
        {
            stopwatch.Stop(); // Detiene el cronómetro
            tmrTimer.Enabled = false; // Desactiva el temporizador

            DateTime ahora = DateTime.Now;
            string marcaTiempo = $"Fecha: {ahora.ToShortDateString()} Hora: {ahora.ToLongTimeString()} | Tiempo: {cronometro}";
            lbMarcasTiempo.Items.Add(marcaTiempo); // Agrega al ListBox
            GuardarMarcaDeTiempoEnBD(ahora, cronometro); // Guarda en la base de datos
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            tmrTimer.Enabled = false;
            cronometro = "00:00:00:000";
            lblNumerosCrono.Text = cronometro;
        }

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

        private void lbMarcasTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si el ListBox contiene elementos y si hay un elemento seleccionado
            if (lbMarcasTiempo != null && lbMarcasTiempo.SelectedItem != null)
            {
                string seleccion = lbMarcasTiempo.SelectedItem.ToString();
                MessageBox.Show($"Marca seleccionada:\n{seleccion}", "Información");
            }
            else
            {
                MessageBox.Show("No hay ninguna marca seleccionada o el ListBox está vacío.", "Advertencia");
            }
        }

        private void CargarMarcasDeTiempo()
        {
            try
            {
                using (SqlConnection connection = conexion.OpenConnection())
                {
                    string query = "SELECT Fecha, Hora, Tiempo FROM MarcasDeTiempo ORDER BY Fecha DESC, Hora DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string fecha = reader["Fecha"].ToString();
                            string hora = reader["Hora"].ToString();
                            string tiempo = reader["Tiempo"].ToString();
                            string marcaTiempo = $"Fecha: {fecha} Hora: {hora} | Tiempo: {tiempo}";
                            lbMarcasTiempo.Items.Add(marcaTiempo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las marcas de tiempo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCronometro_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Cancela el cierre del formulario
            this.Hide(); // Oculta el formulario
            notifyIconCronometro.Visible = true; // Muestra el ícono en el área de notificación
            notifyIconCronometro.ShowBalloonTip(1000, "Cronómetro", "El cronómetro sigue ejecutándose en segundo plano.", ToolTipIcon.Info);
        }

        private void notifyIconCronometro_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MostrarFormulario(); // Restaura el formulario
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarFormulario(); // Restaura el formulario
        }

        private void ConfigurarNotifyIcon()
        {
            notifyIconCronometro.BalloonTipText = "El cronómetro sigue ejecutándose.";
            notifyIconCronometro.BalloonTipTitle = "Cronómetro en segundo plano";
            notifyIconCronometro.Text = "Cronómetro";
            notifyIconCronometro.Icon = SystemIcons.Application; 
            notifyIconCronometro.Visible = false;
        }

        private void MostrarFormulario()
        {
            this.Show(); // Muestra el formulario
            this.WindowState = FormWindowState.Normal; // Restaura el formulario si estaba minimizado
            notifyIconCronometro.Visible = false; // Oculta el ícono en el área de notificación
        }
    }
}
