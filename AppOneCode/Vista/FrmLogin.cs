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
                // Obtener los datos ingresados por el usuario
                string usuario = txtNombreUsuario.Text.Trim();
                string contrasena = txtContrasenaUsuario.Text.Trim();

                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
                {
                    MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método VerificarCuenta
                bool inicioSesionExitoso = Usuario.VerificarCuenta(usuario, contrasena, this);

                // Si las credenciales son correctas
                if (inicioSesionExitoso)
                {
                    // Abrir la ventana principal
                    FrmInicio frmInicio = new FrmInicio();
                    frmInicio.Show();

                    // Ocultar el formulario actual
                    this.Hide();
                }
                else
                {
                    // Si las credenciales son incorrectas, mostrar un mensaje de error
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error inesperado
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Alternar el estado de visibilidad de la contraseña
            showPassword = !showPassword;

            if (showPassword)
            {
                // Mostrar contraseña
                txtContrasenaUsuario.PasswordChar = '\0'; // Muestra el texto de la contraseña
                pictureBox7.Image = AppOneCode.Properties.Resources.icons8_hide_50; // Icono de ocultar
            }
            else
            {
                // Ocultar contraseña
                txtContrasenaUsuario.PasswordChar = '*'; // Oculta el texto de la contraseña
                pictureBox7.Image = AppOneCode.Properties.Resources.icons8_show_50; // Icono de mostrar
            }
        }
    }
}
