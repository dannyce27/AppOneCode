using AppOneCode.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOneCode.Vista
{
    public partial class frmAgregarUsuario : Form
    {
        public frmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            {
                string usuario = txtagregarNombreUsuario.Text; // Suponiendo que tienes un TextBox para el usuario
                string email = txtagregarEmailUsuario.Text; // Suponiendo que tienes un TextBox para el email
                string password = txtagregarContrasenaUsuario.Text; // Suponiendo que tienes un TextBox para la contraseña

                bool resultado = AgregarUsuario.CrearCuentas(usuario, email, password, dgvListaUsuarios);
                if (resultado)
                {
                    MessageBox.Show("Cuenta creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }






        private void dgvListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (dgvListaUsuarios.CurrentRow != null)
                {
                    txtagregarNombreUsuario.Text = dgvListaUsuarios.CurrentRow.Cells["Username"].Value.ToString();
                    txtagregarEmailUsuario.Text = dgvListaUsuarios.CurrentRow.Cells["Email"].Value.ToString();
                    txtagregarContrasenaUsuario.Text = dgvListaUsuarios.CurrentRow.Cells["Contrasenaa"].Value.ToString();

                }
            }
        }

        private void BtnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvListaUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el Id del usuario seleccionado
                int usuarioId = Convert.ToInt32(dgvListaUsuarios.SelectedRows[0].Cells["Id"].Value);

                // Confirmar la eliminación
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    bool resultado = AgregarUsuario.EliminarCuenta(usuarioId, dgvListaUsuarios);
                    if (resultado)
                    {
                        MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void txtagregarContrasenaUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvListaUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el Id del usuario seleccionado
                int usuarioId = Convert.ToInt32(dgvListaUsuarios.SelectedRows[0].Cells["Id"].Value);

                // Obtener los nuevos valores de los TextBox
                string nuevoUsuario = txtagregarNombreUsuario.Text; // Suponiendo que tienes un TextBox para el nuevo nombre de usuario
                string nuevoEmail = txtagregarEmailUsuario.Text; // Suponiendo que tienes un TextBox para el nuevo email
                string nuevaContraseña = txtagregarContrasenaUsuario.Text; // Suponiendo que tienes un TextBox para la nueva contraseña

                bool resultado = AgregarUsuario.EditarCuenta(usuarioId, nuevoUsuario, nuevoEmail, nuevaContraseña, dgvListaUsuarios);
                if (resultado)
                {
                    MessageBox.Show("Usuario editado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo editar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

