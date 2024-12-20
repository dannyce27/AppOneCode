using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AppOneCode.Vista
{
    public partial class FrmLogin : Form
    {
        private bool showPassword = false;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblIniciodeSesion_Click(object sender, EventArgs e)
        {

        }

        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            try
            {
                // Validar que los campos coincidan con el usuario y la contraseña esperados
                string usuarioEsperado = "marcela";
                string contrasenaEsperada = "marcela";

                if (txtNombreUsuario.Text == usuarioEsperado && txtContrasenaUsuario.Text == contrasenaEsperada)
                {
                    // Si las credenciales son correctas, abrir la ventana principal
                    FrmInicio ventanaPrincipal = new FrmInicio();
                    ventanaPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    // Mostrar mensaje de error si los datos son incorrectos
                    MessageBox.Show("Datos Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de error de la excepción
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasenaUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            showPassword = !showPassword;
            if (showPassword)
            {
                // Mostrar contraseña
              //  txtContrasenaUsuario.PasswordChar = '\0';
               // pictureBox7.Image = AppOneCode..Resources.icons8_hide_50;
            }
            else
            {
                // Ocultar contraseña
                txtContrasenaUsuario.PasswordChar = '*';
                //pictureBox7.Image = AppOneCode.Properties.Resources.icons8_show_50;
            }
        }
    }
}
