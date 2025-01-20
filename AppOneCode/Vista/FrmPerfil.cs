using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOneCode.Vista
{
    public partial class FrmPerfil : Form
    {
        public FrmPerfil()
        {
            InitializeComponent();
        }

        private void pbCloseForm_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Close();
            frmLogin.ShowDialog();
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

      
        private void CargarDatosTareas()
        {
            try
            {
                // Suponemos que el UsuarioId ya está disponible (ej. a partir de la sesión o del login)
                int usuarioId = Usuario.UsuarioId;

                // Crear la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection("Server=DESKTOP-2I6K8G4\\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;"))
                {
                    conn.Open();
                    string query = @"
                SELECT e.NombreEstado, COUNT(t.Id) AS Cantidad
                FROM Tareas t
                JOIN Estado e ON t.EstadoId = e.Id
                WHERE t.UsuarioId = @UsuarioId
                GROUP BY e.NombreEstado";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Añadir el parámetro UsuarioId
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        // Limpiar los datos existentes en el gráfico
                        ctProgresoPerfil.Series["EstadoTareas"].Points.Clear();

                        while (reader.Read())
                        {
                            string nombreEstado = reader["NombreEstado"].ToString();
                            int cantidad = Convert.ToInt32(reader["Cantidad"]);

                            // Añadir los puntos al gráfico
                            ctProgresoPerfil.Series["EstadoTareas"].Points.AddXY(nombreEstado, cantidad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmPerfil_Load(object sender, EventArgs e)
        {

            CargarImagenPerfil();
            CargarDatosTareas();

          
            int usuarioId = Usuario.UsuarioId;

            // Llamas al método para obtener el nombre de usuario
            string username = Usuario.ObtenerNombreUsuario(usuarioId);

            
            string email = Usuario.ObtenerEmailUsuario(usuarioId);

            
            if (!string.IsNullOrEmpty(username))
            {
                lblNicknameUSer.Text = username;
            }
            else
            {
                MessageBox.Show("No se pudo cargar el nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!string.IsNullOrEmpty(email))
            {
                lblGmailUser.Text = email; 
            }
            else
            {
                MessageBox.Show("No se pudo cargar el email del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ctProgresoPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}
