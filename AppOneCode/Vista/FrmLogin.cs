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
    public partial class FrmLogin : Form
    {
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
            FrmInicio ventanaPrincipal = new FrmInicio();

            ventanaPrincipal.Show();

            this.Hide();


        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasenaUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
