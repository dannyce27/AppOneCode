using AppOneCode.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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
            CargarTareas();

            toolTip1 = new ToolTip();


        }

        private void CargarTareas()

        {
            Tareas tareas = new Tareas();
            List<Tareas> tareasList = tareas.CargarProyecto();
            dgvproyectos.DataSource = tareasList;
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
            Tareas nuevaTarea = new Tareas
            {
                Nombre = txtNombreProyecto.Text,
                Encargado = txtEncargadoProyecto.Text,
                AreaDeTrabajo = txtAreaTProyecto.Text,
                Descripcion = txtDescProyecto.Text
            };

            if (nuevaTarea.InsertarProyecto()) 
            {
                MessageBox.Show("Proyecto agregado exitosamente.");
                CargarTareas(); // Recargar las tareas para mostrar la nueva
            }


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
            if (dgvproyectos.CurrentRow != null)
            {
                Tareas tareaAEliminar = new Tareas
                {
                    Id = Convert.ToInt32(dgvproyectos.CurrentRow.Cells["Id"].Value)
                };

                if (tareaAEliminar.EliminarProyecto())
                {
                    MessageBox.Show("Proyecto eliminado con exito.");
                    CargarTareas(); // Recargar las tareas para reflejar la eliminación
                }
            }
        
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbActualizarProyecto_Click(object sender, EventArgs e)
        {
            if (dgvproyectos.CurrentRow != null)
            {
                Tareas tareaActualizada = new Tareas
                {
                    Id = Convert.ToInt32(dgvproyectos.CurrentRow.Cells["Id"].Value),
                    Nombre = txtNombreProyecto.Text,
                    Encargado = txtEncargadoProyecto.Text,
                    AreaDeTrabajo = txtAreaTProyecto.Text,
                    Descripcion = txtDescProyecto.Text
                };

                if (tareaActualizada.ActualizarProyecto())
                {
                    MessageBox.Show("Proyecto actualizada exitosamente.");
                    CargarTareas(); // Recargar las tareas para mostrar los cambios
                }
            }
        }

        private void txtDescProyecto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvproyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (dgvproyectos.CurrentRow != null)
                {
                    txtNombreProyecto.Text = dgvproyectos.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtEncargadoProyecto.Text = dgvproyectos.CurrentRow.Cells["Encargado"].Value.ToString();
                    txtAreaTProyecto.Text = dgvproyectos.CurrentRow.Cells["AreaDeTrabajo"].Value.ToString();
                    txtDescProyecto.Text = dgvproyectos.CurrentRow.Cells["Descripcion"].Value.ToString();
                }
            }
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            String criterio = txtSearchProyect.Text.Trim(); 

            Tareas tareas = new Tareas();
            List<Tareas> tareasList = tareas.BuscarProyecto(criterio);

            dgvproyectos.DataSource = tareasList;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
    


