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
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
using static AppOneCode.Vista.user;


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

        private async void FrmChat_Load(object sender, EventArgs e)
        {
            await LeerMensajes(); // Load messages when the form loads

            EscucharMensajesEnTiempoReal(); // Start listening for real-time messages

            pChatporUsuario.AutoScroll = true; // Habilita el desplazamiento

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

            string nombreUsuario = ObtenerNombreUsuario();

            // Crear un nuevo mensaje con un timestamp
            var nuevoMensaje = new
            {
                message = mensaje,
                sender = nombreUsuario,  // El usuario que envía el mensaje
                timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()  // Timestamp actual
            };

            // Usar el timestamp como clave única para cada mensaje
            string messageKey = "message" + nuevoMensaje.timestamp;

            // Agregar el mensaje a la base de datos con PutAsync
            await chatRef.Child(messageKey).PutAsync(nuevoMensaje);

            // Puedes mostrar un mensaje para verificar que el mensaje fue enviado correctamente
            MessageBox.Show("Mensaje enviado");
        }

        private string ObtenerNombreUsuario()
        {
            // Suponiendo que tienes un objeto de usuario que contiene la información
            // Si estás utilizando un sistema de autenticación, este método puede adaptarse según tu implementación

            // Ejemplo simple, reemplaza esto con tu lógica para obtener el nombre
            int usuarioId = Usuario.UsuarioId;

            string nombreUsuario = Usuario.ObtenerNombreUsuario(usuarioId); // Aquí puedes poner la lógica para obtener el nombre real

            return nombreUsuario;
        }
        private async Task LeerMensajes()
        {
            try
            {
                // Reference to the messages node in Firebase
                var chatRef = firebaseClient
                    .Child("chats")
                    .Child("chat1")
                    .Child("messages");

                // Fetch messages from Firebase
                var messages = await chatRef.OnceAsync<dynamic>();

                // Clear the chat panel before adding new messages
                pChatporUsuario.Controls.Clear();

                // Iterate through the messages and add them to the chat panel
                foreach (var message in messages)
                {
                    string sender = message.Object.sender;
                    string messageText = message.Object.message;

                    // Add the message to the chat panel
                    AgregarMensajeAlChat(sender, messageText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los mensajes: " + ex.Message);
            }
        }




        private void AgregarMensajeAlChat(string sender, string message)
        {
            // Create a new Label for the message
            Label lblMensaje = new Label
            {
                Text = $"{sender}: {message}",
                AutoSize = true,
                Font = new Font("Poppins", 12),
                ForeColor = Color.White,
                Padding = new Padding(5),
                Margin = new Padding(5)
            };

            // Add the Label to the chat panel
            pChatporUsuario.Controls.Add(lblMensaje);

            // Scroll to the bottom of the panel to show the latest message
            pChatporUsuario.ScrollControlIntoView(lblMensaje);
        }

        public class FirebaseMessage
        {
            public string sender { get; set; }
            public string message { get; set; }
            public long timestamp { get; set; }
        }

        public class FirebaseObserver : IObserver<FirebaseEvent<FirebaseMessage>>
        {
            private readonly Action<FirebaseEvent<FirebaseMessage>> _onNext;
            private readonly Action<Exception> _onError;
            private readonly Action _onCompleted;

            public FirebaseObserver(Action<FirebaseEvent<FirebaseMessage>> onNext, Action<Exception> onError = null, Action onCompleted = null)
            {
                _onNext = onNext;
                _onError = onError;
                _onCompleted = onCompleted;
            }

            public void OnNext(FirebaseEvent<FirebaseMessage> value)
            {
                _onNext?.Invoke(value);
            }

            public void OnError(Exception error)
            {
                _onError?.Invoke(error);
            }

            public void OnCompleted()
            {
                _onCompleted?.Invoke();
            }
        }

        private void EscucharMensajesEnTiempoReal()
        {
            var chatRef = firebaseClient
                .Child("chats")
                .Child("chat1")
                .Child("messages");

            // Listen for real-time updates using FirebaseMessage
            var observable = chatRef.AsObservable<FirebaseMessage>();

            // Create a custom observer
            var observer = new FirebaseObserver(
                onNext: messageEvent =>
                {
                    if (messageEvent.Object != null)
                    {
                        // Safely access properties
                        string sender = messageEvent.Object.sender;
                        string messageText = messageEvent.Object.message;

                        // Add the message to the chat panel
                        this.Invoke((MethodInvoker)delegate
                        {
                            AgregarMensajeAlChat(sender, messageText);
                        });
                    }
                },
                onError: ex =>
                {
                    // Handle any errors
                    MessageBox.Show("Error al recibir mensajes: " + ex.Message);
                },
                onCompleted: () =>
                {
                    // Handle completion (if needed)
                    MessageBox.Show("La conexión con el chat se ha cerrado.");
                }
            );

            // Subscribe to the observable using the custom observer
            observable.Subscribe(observer);
        }

        private async void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            string mensaje = txtMensaje.Text.Trim();

            if (!string.IsNullOrEmpty(mensaje))
            {
                await EnviarMensaje(mensaje);
                txtMensaje.Clear();
            }
        }

        private async void txtMensaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Detecta la tecla Enter
            {
                e.Handled = true; // Evita que se agregue un salto de línea en el TextBox
                string mensaje = txtMensaje.Text.Trim();

                if (!string.IsNullOrEmpty(mensaje))
                {
                    await EnviarMensaje(mensaje);
                    txtMensaje.Clear();
                }
            }
        }

       

    }





}
