using AppOneCode.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private readonly string connectionString = @"Server=DESKTOP-2I6K8G4\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";
        private ToolTip toolTip1;

        public frmProyectos()
        {



            InitializeComponent();
            CargarTareas();
            CargarAreasTrabajo();
            CargarEncargadosProyectos();    


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


                    Dictionary<int, string> estados = new Dictionary<int, string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombreEstado = reader.GetString(1);

                        
                        estados.Add(id, nombreEstado);
                    }

                   
                    cmbAreaTrabajo.DataSource = new BindingSource(estados, null);
                    cmbAreaTrabajo.DisplayMember = "Value";
                    cmbAreaTrabajo.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarEncargadosProyectos()
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Username FROM Users";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();


                    Dictionary<int, string> estados = new Dictionary<int, string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombreEstado = reader.GetString(1);

                       
                        estados.Add(id, nombreEstado);
                    }

                
                    cmbEncargado.DataSource = new BindingSource(estados, null);
                    cmbEncargado.DisplayMember = "Value";
                    cmbEncargado.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pbAgregarProyecto_Click(object sender, EventArgs e)
        {
            Tareas nuevaTarea = new Tareas
            {
                Nombre = txtNombreProyecto.Text,
                IdEncargado = Convert.ToInt32(cmbEncargado.SelectedValue),
                IdAreaTrabajo = Convert.ToInt32(cmbAreaTrabajo.SelectedValue),
                Descripcion = txtDescProyecto.Text,
                FechaInicio = dtpFechaInicio.Value,
                FechaFinalizacion = dtpFechaFinalizacion.Value,

            };

            if (nuevaTarea.InsertarProyecto())
            {
                MessageBox.Show("Proyecto agregado exitosamente.");
                CargarTareas();
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
                    IdEncargado = (int)cmbEncargado.SelectedValue,
                    IdAreaTrabajo = (int)cmbAreaTrabajo.SelectedValue,
                    Descripcion = txtDescProyecto.Text,
                    FechaInicio = dtpFechaFinalizacion.Value,
                    FechaFinalizacion = dtpFechaFinalizacion.Value

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
                    cmbEncargado.Text = dgvproyectos.CurrentRow.Cells["Encargado"].Value.ToString();
                    cmbAreaTrabajo.Text = dgvproyectos.CurrentRow.Cells["AreaDeTrabajo"].Value.ToString();
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }
    }
}
    


