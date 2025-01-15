using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppOneCode.Modelo;

namespace AppOneCode.Vista
{
    public partial class FrmTareas : Form
    {
        public FrmTareas()
        {
            InitializeComponent();
            LLenarTareas();
        }

        private void LLenarTareas()
        {
            Tareas2 obj = new Tareas2();
            obj.LLenarTareas(flowLayoutPanel1);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (txtBuscar.Text == "Buscar proyectos o tareas")
            {
                txtBuscar.ForeColor = Color.Gray;
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

        private void lblinicio_Click(object sender, EventArgs e)
        {
            FrmInicio fI = new FrmInicio();
            this.Close();
            fI.ShowDialog();
        }

        private void lblDasboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            this.Close();
            frmDashboard.Show();
        }

        private void lblproyectos_Click(object sender, EventArgs e)
        {
            frmProyectos fp = new frmProyectos();
            this.Close();
            fp.ShowDialog();
        }

        private void lblrecursos_Click(object sender, EventArgs e)
        {

        }

        private void pbAgregarProyecto_Click(object sender, EventArgs e)
        {
            FrmAgregarTareas frmAggTareas = new FrmAgregarTareas();
            this.Hide();
            frmAggTareas.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
