using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppOneCode.Vista;

using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using Firebase.Database;


using static AppOneCode.Vista.user;
using Firebase.Database.Query;

namespace AppOneCode
{
    public partial class FrmChat : Form
    {
        private FirebaseClient firebaseClient;

        private int paginaActual = 1; // Página actual
        private int elementosPorPagina = 5; // Elementos por página
        private List<Usuario> listaUsuarios; // Lista de todos los usuarios

        public FrmChat()
        {
            InitializeComponent();
            LlenarUsuarios();
            ActualizarLabelPagina();

            firebaseClient = new FirebaseClient("https://onecode-1d62d-default-rtdb.firebaseio.com/");
        }

        private void LlenarUsuarios()
        {
            flpUsuariosLista.Controls.Clear();

            // Verificar si la lista de usuarios es nula antes de continuar
            if (listaUsuarios == null)
            {
                listaUsuarios = Usuario.ObtenerUsuarios(); // Asignar a la variable de clase
            }

            // Evitar NullReferenceException si la lista sigue siendo nula
            if (listaUsuarios == null || listaUsuarios.Count == 0)
            {
                MessageBox.Show("No hay usuarios disponibles.");
                return;
            }

            // Calcular los elementos a mostrar en la página actual
            int inicio = (paginaActual - 1) * elementosPorPagina;
            int fin = Math.Min(inicio + elementosPorPagina, listaUsuarios.Count);

            for (int i = inicio; i < fin; i++)
            {
                Usuario usuario = listaUsuarios[i];

                // Crear un nuevo UserControl para cada usuario
                user userControl = new user
                {
                    Id = usuario.Id,
                    Name = usuario.Username
                };

                // Asignar el nombre al Label dentro del UserControl
                Label lblNombreUsuario = (Label)userControl.Controls.Find("lblNombreUsuario", true).FirstOrDefault();
                if (lblNombreUsuario != null)
                {
                    lblNombreUsuario.Text = usuario.Username;
                }

                // Asignar imagen al PictureBox dentro del UserControl
                PictureBox pbFotoPerfil = (PictureBox)userControl.Controls.Find("pbFotoPerfil", true).FirstOrDefault();
                if (pbFotoPerfil != null && usuario.ImagenPerfil != null)
                {
                    using (MemoryStream ms = new MemoryStream(usuario.ImagenPerfil))
                    {
                        pbFotoPerfil.Image = Image.FromStream(ms);
                        pbFotoPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }

                userControl.UsuarioSeleccionado += UserControl_UsuarioSeleccionado;

                // Agregar el UserControl al FlowLayoutPanel
                flpUsuariosLista.Controls.Add(userControl);
            }
        }


        private void ActualizarLabelPagina()
        {
            int totalPaginas = (int)Math.Ceiling((double)listaUsuarios.Count / elementosPorPagina);
            lblNumPagina.Text = $"Página {paginaActual} de {totalPaginas}";
        }

        private void FrmChat_Load(object sender, EventArgs e)
        {

        }

        private void flpUsuariosLista_Paint(object sender, PaintEventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MostrarChatUsuario(Usuario usuario)
        {
            lblChatNombreUsuario.Text = usuario.Username; // Cambia el nombre del usuario en el panel
            pChatporUsuario.Controls.Clear(); // Limpia el panel antes de mostrar el nuevo chat

            // Agregar un control de chat dinámico (Ejemplo: un Label o TextBox para mensajes)
            Label lblMensaje = new Label
            {
                Text = $"Chat con {usuario.Username}",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White
            };

            pChatporUsuario.Controls.Add(lblMensaje);
        }

        private void UserControl_UsuarioSeleccionado(object sender, UsuarioEventArgs e)
        {
            // Accede al usuario desde e.Usuario
            MostrarChatUsuario(e.Usuario);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                LlenarUsuarios(); // Actualiza la lista
                ActualizarLabelPagina();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = (int)Math.Ceiling((double)listaUsuarios.Count / elementosPorPagina);

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                LlenarUsuarios(); // Actualiza la lista
                ActualizarLabelPagina();
            }
        }

        private async Task EnviarMensaje(string mensaje)
        {
            var chatRef = firebaseClient
                .Child("chats")
                .Child("chat1")
                .Child("messages");

            // Crear un nuevo mensaje con un timestamp
            var nuevoMensaje = new
            {
                message = mensaje,
                sender = "User1",  // El usuario que envía el mensaje
                timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()  // Timestamp actual
            };

            // Usar el timestamp como clave única para cada mensaje
            string messageKey = "message" + nuevoMensaje.timestamp;

            // Agregar el mensaje a la base de datos con PutAsync
            await chatRef.Child(messageKey).PutAsync(nuevoMensaje);

            // Puedes mostrar un mensaje para verificar que el mensaje fue enviado correctamente
            MessageBox.Show("Mensaje enviado");
        }

     





        private void AgregarMensajeAlChat(string sender, string message)
        {
            // Agregar el mensaje al panel de chat (puedes usar un Label o un TextBox)
            Label lblMensaje = new Label
            {
                Text = $"{sender}: {message}",
                AutoSize = true,
                Font = new Font("Arial", 12),
                ForeColor = Color.Black
            };

            pChatporUsuario.Controls.Add(lblMensaje);
        }


    }



}
