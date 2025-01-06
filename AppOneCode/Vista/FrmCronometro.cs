using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace AppOneCode.Vista
{
    public partial class FrmCronometro : Form
    {
        private string cronometro;
        private Stopwatch stopwatch;

        public FrmCronometro()
        {
            InitializeComponent();
            cronometro = "";
            stopwatch = new Stopwatch();
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
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            tmrTimer.Enabled = false;
            cronometro = "00:00:00:000";
            lblNumerosCrono.Text = cronometro;
        }

        private void lblNumerosCrono_Click(object sender, EventArgs e)
        {

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
    }
}
