using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppOneCode.Modelo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppOneCode.Vista
{


    public partial class UserControlTareas : UserControl
    {
        

        private int id = 0;
        private string descripcion = "Descripcion Tarea";
        private string prioridad;
        private string estado;
        public UserControlTareas()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                CargarImagenEncargado(); // Cargar la imagen automáticamente al asignar un Id
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; lblDescTarea.Text = value; }  // Aquí asignamos el valor a una etiqueta
        }

        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; lblPrioridad.Text = value; }  // Aquí asignamos el valor a una etiqueta
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; lblEstado.Text = value; }  // Aquí asignamos el valor a una etiqueta
        }


        private void pbAgregarComent_Click(object sender, EventArgs e)
        {
            // Obtener el correo del encargado del proyecto
            string correoEncargado = ObtenerCorreoEncargadoProyecto(this.Id);

            // Verificar si se obtuvo un correo
            if (!string.IsNullOrEmpty(correoEncargado))
            {
                // Mostrar el mensaje con el correo
                MessageBox.Show($"Puedes contactar con el encargado de proyecto que te asignó la tarea por medio de Zoho: {correoEncargado}",
                                "Contacto con el encargado del proyecto",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró el correo del encargado del proyecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerCorreoEncargadoProyecto(int idTarea)
        {
            string correoEncargado = string.Empty;

            try
            {
                // Consulta para obtener el correo del encargado del proyecto
                string query = @"SELECT U.Email 
                         FROM Trabajo Tr
                         JOIN Users U ON Tr.IdEncargado = U.Id
                         JOIN Tareas T ON T.idProyecto = Tr.Id
                         WHERE T.Id = @idTarea";

                using (SqlConnection conn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idTarea", idTarea);
                        correoEncargado = cmd.ExecuteScalar() as string;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el correo del encargado del proyecto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return correoEncargado;
        }


        private string ObtenerNombreEncargadoProyecto(int idTarea)
        {
            string username = string.Empty;

            try
            {
                // Consulta SQL para obtener el nombre del encargado del proyecto
                string query = @"SELECT U.Username 
                         FROM Trabajo Tr
                         JOIN Users U ON Tr.IdEncargado = U.Id
                         JOIN Tareas T ON T.idProyecto = Tr.Id
                         WHERE T.Id = @idTarea";

                using (SqlConnection conn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idTarea", idTarea);
                        username = cmd.ExecuteScalar() as string;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el nombre del encargado del proyecto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return username;
        }




        private void CargarImagenEncargado()
        {
            if (id <= 0)
            {
                pbEncargadoTarea.Image = Properties.Resources.icons8_close_32; // Imagen por defecto
                return;
            }

            try
            {
                byte[] imagenBytes = Usuario.CargarImagenUsuario(Usuario.UsuarioId);

                if (imagenBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        pbEncargadoTarea.Image = Image.FromStream(ms);
                        pbEncargadoTarea.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    pbEncargadoTarea.Image = Properties.Resources.icons8_close_32;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen del encargado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radio = 27;
            var rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Borde
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }

                // Fondo
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int radio = 27;
            var rect = this.ClientRectangle;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPrioridad_Click(object sender, EventArgs e)
        {

        }
        private int ObtenerUsuarioAsignadoTarea(int idTarea)
        {
            int usuarioAsignadoId = 0;

            try
            {
                // Consulta SQL para obtener el ID del usuario asignado a la tarea
                string query = @"SELECT UsuarioId 
                         FROM Tareas 
                         WHERE Id = @idTarea";

                using (SqlConnection conn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idTarea", idTarea);
                        usuarioAsignadoId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el usuario asignado a la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return usuarioAsignadoId;
        }

        private void pbTaskComplete_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID del usuario asignado a la tarea
                int usuarioAsignadoId = ObtenerUsuarioAsignadoTarea(this.Id);

                // Obtener el ID del usuario actual
                int usuarioActualId = Usuario.UsuarioId; // Asume que tienes una propiedad estática para el ID del usuario actual

                // Verificar si el usuario actual es el asignado a la tarea
                if (usuarioActualId != usuarioAsignadoId)
                {
                    MessageBox.Show("No eres el encargado de esta tarea. No puedes marcarla como completada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir del método si no es el usuario asignado
                }

                // Crear modelo de tarea
                Tareas2 tareaModel = new Tareas2
                {
                    Id = this.Id, // Id de la tarea actual
                    Estado = "Completada" // Nuevo estado
                };

                // Actualizar el estado en la base de datos
                if (tareaModel.ActualizarEstado())
                {
                    // Actualizar la etiqueta del estado en el UserControl
                    this.Estado = "Completada";
                    MessageBox.Show("La tarea ha sido marcada como completada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Obtener el correo del encargado usando el método ya implementado
                    string correoEncargado = ObtenerCorreoEncargadoProyecto(this.Id);
                    string username = ObtenerNombreEncargadoProyecto(this.Id);
                    string nombreProyecto = ObtenerNombreProyecto(this.Id);
                    string usernameCompleto = ObtenerNombreUsuarioAsignado(this.Id);

                    // Verificar si se obtuvo el correo
                    if (!string.IsNullOrEmpty(correoEncargado))
                    {
                        // Crear el servicio de correo para enviar la notificación
                        EmailService emailService = new EmailService();
                        emailService.EnviarNotificacionTareaCompletada(correoEncargado, username, usernameCompleto, nombreProyecto, this.Descripcion);

                        MessageBox.Show("Correo enviado al encargado del proyecto.", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el correo del encargado del proyecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo completar la tarea.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerNombreUsuarioAsignado(int idTarea)
        {
            string nombreUsuario = string.Empty;

            try
            {
                // Consulta SQL para obtener el nombre del usuario asignado a la tarea
                string query = @"SELECT U.Username 
                         FROM Users U
                         INNER JOIN Tareas T ON U.Id = T.UsuarioId
                         WHERE T.Id = @idTarea";

                using (SqlConnection conn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idTarea", idTarea);
                        nombreUsuario = cmd.ExecuteScalar() as string;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el nombre del usuario asignado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return nombreUsuario;
        }

        private string ObtenerNombreProyecto(int idTarea)
        {
            string nombreProyecto = string  .Empty;

            try
            {
                
                string query = @"SELECT P.Nombre 
                         FROM Trabajo P
                         JOIN Tareas T ON P.Id = T.idProyecto
                         WHERE T.Id = @idTarea";

                using (SqlConnection conn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idTarea", idTarea);
                        nombreProyecto = cmd.ExecuteScalar() as string;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el nombre del proyecto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return nombreProyecto;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCronometro frmC = new FrmCronometro();
                frmC.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbEncargadoTarea_MouseHover(object sender, EventArgs e)
        {
            // ID de la tarea seleccionada
            int tareaId = id;
            if (tareaId <= 0)
            {
                toolTip1.SetToolTip(pbEncargadoTarea, "No hay una tarea seleccionada.");
                return;
            }

            Tareas2 tareas2 = new Tareas2();
            string encargado = tareas2.ObtenerNombreUsuarioAsignado(tareaId);

            if (!string.IsNullOrEmpty(encargado))
            {
                toolTip1.SetToolTip(pbEncargadoTarea, $"Encargado: {encargado}");
            }
            else
            {
                toolTip1.SetToolTip(pbEncargadoTarea, "No se encontró el encargado de esta tarea.");
            }


        }

        private void pbEncargadoTarea_Click(object sender, EventArgs e)
        {

        }

        private void UserControlTareas_Load(object sender, EventArgs e)
        {

            CargarImagenEncargado();

        }

        private void lblDescTarea_Click(object sender, EventArgs e)
        {

        }
    }
}
