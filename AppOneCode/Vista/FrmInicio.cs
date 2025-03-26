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
using AppOneCode.Vista;

namespace AppOneCode
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            int usuarioId = Usuario.UsuarioId;

            // Obtener el nombre de usuario
            string username = Usuario.ObtenerNombreUsuario(usuarioId);

            if (!string.IsNullOrEmpty(username))
            {
                lblUsername.Text = username;
            }
            else
            {
                MessageBox.Show("No se pudo cargar el nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
            int idRol = ObtenerIdRol(usuarioId);

            
            if (idRol != 1)
            {
                lblDashboard.Visible = false;
            }

            if (idRol == 4)
            {
                lblproyectos.Visible = false;

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void lbltareas_Click(object sender, EventArgs e)
        {
            FrmTareas Ft = new FrmTareas();
            this.Hide();
            Ft.ShowDialog();
        }

        private void lblinicio_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            FrmDashboard Ft = new FrmDashboard();
            this.Hide();
            Ft.ShowDialog();
        }

        private void lblproyectos_Click(object sender, EventArgs e)
        {
            frmProyectos frm = new frmProyectos();
            this.Hide();
            frm.ShowDialog();
        }

        private void lblrecursos_Click(object sender, EventArgs e)
        {

        }

        private void lblfaq_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://eclectic-elf-ac92ac.netlify.app/", 
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la página: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblchat_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int idTipoUsuario = Usuario.ObtenerIdTipoUsuario(Usuario.UsuarioId); // Obtiene el tipo de usuario

            switch (idTipoUsuario)
            {
                case 1: // Administrador
                    frmAgregarUsuario frmAdmin = new frmAgregarUsuario();
                    this.Hide();
                    frmAdmin.Show();
                    break;
                case 2: // Empleado
                    FrmPerfil frmEmpleado = new FrmPerfil();
                    this.Hide();
                    frmEmpleado.Show();
                    break;
                default:
                    MessageBox.Show("Rol no reconocido. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }

        }

        public static int ObtenerIdRol(int usuarioId)
        {
            int idRol = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;"))
                {
                    conn.Open();
                    string query = "SELECT idTipoUsuario FROM Users WHERE Id = @usuarioId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                        idRol = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el rol del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return idRol;
        }

        private void botonPersonalizado1_Click(object sender, EventArgs e)
        {
            FrmChat Ft = new FrmChat();
            this.Hide();
            Ft.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
