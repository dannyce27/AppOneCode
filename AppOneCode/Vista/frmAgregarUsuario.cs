using AppOneCode.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            CargarImagenPerfil();
            

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
            int usuarioId = Usuario.UsuarioId;

            // Llamas al método para obtener el nombre de usuario
            string username = Usuario.ObtenerNombreUsuario(usuarioId);


         


            if (!string.IsNullOrEmpty(username))
            {
                lblNombreUsuario.Text = username;
            }
            else
            {
                MessageBox.Show("No se pudo cargar el nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         

            // Obtener el nombre de usuario
            string tipoUsuario = Usuario.ObtenerTipoUsuario(usuarioId); // Obtener el tipo de usuario

            if (!string.IsNullOrEmpty(tipoUsuario))
            {
                lblCargo.Text = tipoUsuario; // Mostrar el tipo de usuario en lblCargo
            }
            else
            {
                MessageBox.Show("No se pudo cargar el tipo de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            {
                string usuario = txtagregarNombreUsuario.Text; 
                string email = txtagregarEmailUsuario.Text;
                string password = txtagregarContrasenaUsuario.Text; 

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
                   // txtagregarContrasenaUsuario.Text = dgvListaUsuarios.CurrentRow.Cells["Contrasenaa"].Value.ToString();

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
                string nuevoUsuario = txtagregarNombreUsuario.Text; 
                string nuevoEmail = txtagregarEmailUsuario.Text; 
                string nuevaContraseña = txtagregarContrasenaUsuario.Text; 

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

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void btnCambiarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir un cuadro de diálogo para seleccionar la imagen
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Imagenes (*.jpg; *.jpeg; *.png; *.gif)|*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cargar la imagen seleccionada en el PictureBox
                    pbImageTrabajador.Image = Image.FromFile(openFileDialog.FileName);

                    // Convertir la imagen a un array de bytes
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                    // Obtener el usuarioId
                    int usuarioId = Usuario.UsuarioId; // Ya tienes el usuarioId de la sesión

                    // Guardar la imagen en la base de datos
                    bool imagenGuardada = Usuario.GuardarImagenUsuario(usuarioId, imageBytes);

                    if (imagenGuardada)
                    {
                        MessageBox.Show("Imagen de perfil guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al guardar la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        private void CargarImagenPerfil()
        {
            try
            {
                int usuarioId = Usuario.UsuarioId; // Obtener el usuarioId

                // Cargar la imagen desde la base de datos
                byte[] imagenBytes = Usuario.CargarImagenUsuario(usuarioId);

                if (imagenBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        pbImageTrabajador.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró una imagen de perfil para este usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void botonPersonalizado1_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir un cuadro de diálogo para seleccionar la imagen
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Imagenes (*.jpg; *.jpeg; *.png; *.gif)|*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cargar la imagen seleccionada en el PictureBox
                    pbImageTrabajador.Image = Image.FromFile(openFileDialog.FileName);

                    // Convertir la imagen a un array de bytes
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                    // Obtener el usuarioId
                    int usuarioId = Usuario.UsuarioId; // Ya tienes el usuarioId de la sesión

                    // Guardar la imagen en la base de datos
                    bool imagenGuardada = Usuario.GuardarImagenUsuario(usuarioId, imageBytes);

                    if (imagenGuardada)
                    {
                        MessageBox.Show("Imagen de perfil guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al guardar la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            String usuario = txtSearchProyect.Text.Trim();

            Usuario usuario_ = new Usuario();
            List<Usuario> usuList = usuario_.BuscarUsuarios(usuario);
            dgvListaUsuarios.DataSource = usuList;
        }

        private void pbImageTrabajador_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            this.Hide();
            frmInicio.ShowDialog();
        }

        private void lblproyectos_Click(object sender, EventArgs e)
        {
            frmProyectos frmPro = new frmProyectos();   
            this.Hide();
            frmPro.ShowDialog();
        }

        private void lbltareas_Click(object sender, EventArgs e)
        {
            FrmTareas frmTareas = new FrmTareas();
            this.Hide();
            frmTareas.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void botonPersonalizado2_Click(object sender, EventArgs e)
        {
            FrmChat chat = new FrmChat();
            this.Hide();
            chat.ShowDialog();
        }

        private void lblCargo_Click(object sender, EventArgs e)
        {

        }
    }
}

