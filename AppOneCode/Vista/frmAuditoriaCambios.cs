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

namespace AppOneCode.Vista
{
    public partial class frmAuditoriaCambios : Form
    {

        private string connectionString = "Server=DESKTOP-2I6K8G4\\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";
        public frmAuditoriaCambios()
        {
            InitializeComponent();
            CargarDatosAuditoriaProyectos();
            CargarDatosAuditoriaTareas();
        }


        private void CargarDatosAuditoriaTareas()
        {
            string query = "SELECT * FROM AuditoriaCambiosTareas"; // Modifica la consulta según tu tabla

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Asignar el DataTable al DataGridView
                dgvCambiosTareas.DataSource = dt;
            }
        }

        private void CargarDatosAuditoriaProyectos()
        {
            string query = "SELECT * FROM AuditoriaCambiosTrabajo"; // Modifica la consulta según tu tabla

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Asignar el DataTable al DataGridView
                dgvCambiosProyectos.DataSource = dt;
            }
        }
        private void dgvCambiosProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAuditoriaCambios_Load(object sender, EventArgs e)
        {

        }

        private void dgvCambiosTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void botonPersonalizado1_Click(object sender, EventArgs e)
        {
            frmAgregarUsuario frmAgregarUsuario = new frmAgregarUsuario();
            this.Hide();
            frmAgregarUsuario.ShowDialog();
        }
    }
}
