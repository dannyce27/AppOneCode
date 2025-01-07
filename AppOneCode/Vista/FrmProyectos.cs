using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOneCode.Vista
{
    public partial class frmProyectos : Form
    {

        private ToolTip toolTip1; 

        public frmProyectos()
        {

            InitializeComponent();

            toolTip1 = new ToolTip();


        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void pbAgregarProyecto_Click(object sender, EventArgs e)
        {

        }

        private void pbAgregarProyecto_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Agregar Proyecto", pbAgregarProyecto);
        }

        private void pbAgregarProyecto_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pbAgregarProyecto);
        }

        private void pbEliminarProyecto_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Eliminar Proyecto", pbEliminarProyecto);

        }

        private void pbEliminarProyecto_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pbEliminarProyecto);
        }

        private void pbActualizarProyecto_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Actualizar Proyecto", pbActualizarProyecto);

        }

        private void pbActualizarProyecto_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pbActualizarProyecto);
        }

        private void pbEliminarProyecto_Click(object sender, EventArgs e)
        {

        }

        private void lblinicio_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            this.Close();
            frmInicio.ShowDialog();
        }

        private void lbltareas_Click(object sender, EventArgs e)
        {
            FrmTareas frmTareas = new FrmTareas();
            this.Close();
            frmTareas.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            this.Close();
            frmDashboard.ShowDialog();
        }

        private void lblrecursos_Click(object sender, EventArgs e)
        {

        }
    }
}
