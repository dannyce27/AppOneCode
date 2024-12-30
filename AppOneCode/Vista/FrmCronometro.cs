using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

            cronometro = $"{hour}:{minute}:{second}:{ms}:";

            lblNumerosCrono.Text = cronometro;
        }

            private void pbPause_Click(object sender, EventArgs e)
            {
            stopwatch.Stop(); // Detiene el Stopwatch
            tmrTimer.Enabled = false; // Detiene el temporizador que actualiza la interfaz
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();
        }
    }
}
