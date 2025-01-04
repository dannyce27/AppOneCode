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
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using AppOneCode.Vista;
using AppOneCode.Modelo;


namespace AppOneCode.Vista
{
    public partial class Frmregistro : Form
    {
        private bool showPassword = false;
        public Frmregistro()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtusuarioR.Text) ||
                    string.IsNullOrWhiteSpace(txtemailR.Text) ||
                    string.IsNullOrWhiteSpace(txtContrasenaUsuarioR.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear cuenta
                bool resultado = Usuario.CrearCuentas(txtusuarioR.Text, txtemailR.Text, txtContrasenaUsuarioR.Text);
                if (resultado = true)
                {
                    MessageBox.Show("Cuenta creada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se creó la cuenta. Verifica los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasenaUsuario_TextChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {


            
        }

        private void txtusuarioR_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            showPassword = !showPassword;

            if (showPassword)
            {
                // Mostrar contraseña
                txtContrasenaUsuarioR.PasswordChar = '\0'; // Muestra el texto de la contraseña
                pictureBox7.Image = AppOneCode.Properties.Resources.ojitoto; // Cambia al icono de "mostrar"
            }
            else
            {
                // Ocultar contraseña
                txtContrasenaUsuarioR.PasswordChar = '*'; // Oculta el texto de la contraseña
                pictureBox7.Image = AppOneCode.Properties.Resources.icons8_hide_50; // Cambia al icono de "ocultar"
            }
        }
    }
}
