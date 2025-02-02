using System;
using System.Windows.Forms;
using AppOneCode.Modelo;

namespace AppOneCode.Vista
{
    public partial class FrmRecuperacionC : Form
    {
        private string codigoRecuperacion;

        public FrmRecuperacionC()
        {
            InitializeComponent();

            // Inicializar el formulario para mostrar solo los controles iniciales
            CambiarVistaValidacion(false);
        }

        private void CambiarVistaValidacion(bool mostrarValidacion)
        {
            // Mostrar u ocultar controles para enviar correo
            pbTextoInformativo.Visible = !mostrarValidacion;
            btnEnviarCorreo.Visible = !mostrarValidacion;
            txtIngresarCorreo.Visible = !mostrarValidacion;

            // Mostrar u ocultar controles para validar el código
            lblValidarCodigo.Visible = mostrarValidacion;
            txtValidarCodigo.Visible = mostrarValidacion;
            btnValidarCodigo.Visible = mostrarValidacion;
        }

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el correo ingresado
                string email = txtIngresarCorreo.Text;

                // Verificar que no esté vacío
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Por favor, ingresa tu correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Enviar el código de recuperación
                EmailService emailService = new EmailService();
                codigoRecuperacion = emailService.EnviarCodigoRecuperacion(email);

                MessageBox.Show("El código de recuperación ha sido enviado a tu correo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cambiar a la vista de validación
                CambiarVistaValidacion(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            // Verificar si el código ingresado coincide
            if (txtValidarCodigo.Text == codigoRecuperacion)
            {
                MessageBox.Show("Código válido. Proceder a cambiar contraseña.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario para cambiar la contraseña
                FrmCambiarContraseña frmCambiarContraseña = new FrmCambiarContraseña();
                frmCambiarContraseña.Show();
                this.Close(); // Cierra el formulario actual
            }
            else
            {
                MessageBox.Show("El código ingresado es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIngresarCorreo_TextChanged(object sender, EventArgs e)
        {
            // Lógica adicional si se requiere
        }

        private void txtValidarCodigo_TextChanged(object sender, EventArgs e)
        {
            // Lógica adicional si se requiere
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Lógica para el PictureBox si es necesario
        }

        private void btnValidarCodigo_Click_1(object sender, EventArgs e)
        {
            // Verificar si el código ingresado coincide
            if (txtValidarCodigo.Text == codigoRecuperacion)
            {
                MessageBox.Show("Código válido. Proceder a cambiar contraseña.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario para cambiar la contraseña
                FrmCambiarContraseña frmCambiarContraseña = new FrmCambiarContraseña();
                frmCambiarContraseña.Show();
                this.Close(); // Cierra el formulario actual
            }
            else
            {
                MessageBox.Show("El código ingresado es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarCorreo_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Obtener el correo ingresado
                string email = txtIngresarCorreo.Text;

                // Verificar que no esté vacío
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Por favor, ingresa tu correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Enviar el código de recuperación
                EmailService emailService = new EmailService();
                codigoRecuperacion = emailService.EnviarCodigoRecuperacion(email);

                MessageBox.Show("El código de recuperación ha sido enviado a tu correo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cambiar a la vista de validación
                CambiarVistaValidacion(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.ShowDialog();
        }
    }
}
