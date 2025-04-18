﻿using System;
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
            private string chatIdActual = "";
            private IDisposable subscription;

            public FrmChat()
            {
                InitializeComponent();
                LlenarUsuarios();
                ActualizarLabelPagina();

                firebaseClient = new FirebaseClient("https://onecode-1d62d-default-rtdb.firebaseio.com/");
            }
            private string GenerarChatId(int usuarioId)
            {
                // Ejemplo: Combina el ID del usuario actual y el seleccionado
                int miUsuarioId = Usuario.UsuarioId;
                return miUsuarioId < usuarioId
                    ? $"{miUsuarioId}-{usuarioId}"
                    : $"{usuarioId}-{miUsuarioId}";
            }

            private void LlenarUsuarios()
            {
                flpUsuariosLista.Controls.Clear();

           
                if (listaUsuarios == null)
                {
                    listaUsuarios = Usuario.ObtenerUsuarios(); 
                }

            
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

               
                    user userControl = new user
                    {
                        Id = usuario.Id,
                        Name = usuario.Username
                    };

                
                    Label lblNombreUsuario = (Label)userControl.Controls.Find("lblNombreUsuario", true).FirstOrDefault();
                    if (lblNombreUsuario != null)
                    {
                        lblNombreUsuario.Text = usuario.Username;
                    }

                
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
                await LeerMensajes(); 

                EscucharMensajesEnTiempoReal(); 

                pChatporUsuario.AutoScroll = true; 

            }

            private void flpUsuariosLista_Paint(object sender, PaintEventArgs e)
            {

            }



            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void MostrarChatUsuario(Usuario usuario)
            {
                lblChatNombreUsuario.Text = usuario.Username;
                pChatporUsuario.Controls.Clear();

           
                chatIdActual = GenerarChatId(usuario.Id);

            
                LeerMensajes();
                EscucharMensajesEnTiempoReal();
            }

            private void UserControl_UsuarioSeleccionado(object sender, UsuarioEventArgs e)
            {
          
                MostrarChatUsuario(e.Usuario);
            }

            private void btnAnterior_Click(object sender, EventArgs e)
            {
                if (paginaActual > 1)
                {
                    paginaActual--;
                    LlenarUsuarios();
                    ActualizarLabelPagina();
                }
            }

            private void btnSiguiente_Click(object sender, EventArgs e)
            {
                int totalPaginas = (int)Math.Ceiling((double)listaUsuarios.Count / elementosPorPagina);

                if (paginaActual < totalPaginas)
                {
                    paginaActual++;
                    LlenarUsuarios(); 
                    ActualizarLabelPagina();
                }
            }

            private async Task EnviarMensaje(string mensaje)
            {
                if (string.IsNullOrEmpty(chatIdActual))
                {
                    MessageBox.Show("Selecciona un usuario primero");
                    return;
                }

                var chatRef = firebaseClient
                    .Child("chats")
                    .Child(chatIdActual)
                    .Child("messages");

                var nuevoMensaje = new FirebaseMessage
                {
                    sender = ObtenerNombreUsuario(),
                    message = mensaje,
                    timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()  
                };

                string messageKey = "message" + nuevoMensaje.timestamp;
                await chatRef.Child(messageKey).PutAsync(nuevoMensaje);
            }

            private string ObtenerNombreUsuario()
            {
            
                int usuarioId = Usuario.UsuarioId;

                string nombreUsuario = Usuario.ObtenerNombreUsuario(usuarioId); 

                return nombreUsuario;
            }
            private async Task LeerMensajes()
            {
                try
                {
                    if (string.IsNullOrEmpty(chatIdActual)) return;

                    var chatRef = firebaseClient
                        .Child("chats")
                        .Child(chatIdActual)
                        .Child("messages");

                    var messages = await chatRef
                        .OrderBy("timestamp")  // Ordenar por timestamp
                        .OnceAsync<FirebaseMessage>();

                    // Limpiar el panel antes de agregar mensajes
                    pChatporUsuario.Controls.Clear();

                    foreach (var message in messages)
                    {
                        AgregarMensajeAlChat(message.Object.sender, message.Object.message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer mensajes: " + ex.Message);
                }
            }




            private void AgregarMensajeAlChat(string sender, string message)
            {
                bool esMensajeEnviadoPorMiUsuario = sender == ObtenerNombreUsuario();

           
                Panel panelMensaje = new Panel
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    MaximumSize = new Size(pChatporUsuario.Width - 20, 0) // Evitar que los mensajes se desborden
                };

                // Crear un Label para el mensaje
                Label lblMensaje = new Label
                {
                    Text = $"{sender}: {message}",
                    AutoSize = true,
                    Font = new Font("Poppins", 12),
                    ForeColor = Color.White,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    MaximumSize = new Size(pChatporUsuario.Width - 20, 0), // Evitar que el mensaje se desborde
                };

                // Asignar el fondo y alineación según si es enviado o recibido
                if (esMensajeEnviadoPorMiUsuario)
                {
                    lblMensaje.TextAlign = ContentAlignment.MiddleLeft; // Alinear texto a la izquierda
                    lblMensaje.BackColor = Color.FromArgb(0, 122, 255); // Color para los mensajes enviados
                }
                else
                {
                    lblMensaje.TextAlign = ContentAlignment.MiddleRight; // Alinear texto a la derecha
                    lblMensaje.BackColor = Color.Gray; // Color para los mensajes recibidos
                }

        
                panelMensaje.Controls.Add(lblMensaje);

          
                pChatporUsuario.Controls.Add(panelMensaje);

            
                pChatporUsuario.ScrollControlIntoView(panelMensaje);
                pChatporUsuario.AutoScrollOffset = new Point(0, panelMensaje.Bottom);
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
            if (string.IsNullOrEmpty(chatIdActual)) return;

            var chatRef = firebaseClient
                .Child("chats")
                .Child(chatIdActual)
                .Child("messages");

            // Escuchar actualizaciones en tiempo real
            var observable = chatRef.AsObservable<FirebaseMessage>();

            // Crear un observador personalizado
            var observer = new FirebaseObserver(
                    onNext: messageEvent =>
                    {
                        if (messageEvent.Object != null)
                        {
                            string sender = messageEvent.Object.sender;
                            string messageText = messageEvent.Object.message;

                            // Agregar el mensaje al panel
                            this.Invoke((MethodInvoker)delegate
                            {
                                AgregarMensajeAlChat(sender, messageText);
                            });
                        }
                    },
                    onError: ex =>
                    {
                        MessageBox.Show("Error al recibir mensajes: " + ex.Message);
                    },
                    onCompleted: () =>
                    {
                        MessageBox.Show("La conexión con el chat se ha cerrado.");
                    }
                );


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
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string mensaje = txtMensaje.Text.Trim();

                if (!string.IsNullOrEmpty(mensaje))
                {
                    await EnviarMensaje(mensaje);
                    txtMensaje.Clear();
                }
            }
        }

        private async Task<List<Usuario>> ObtenerUsuariosMasRecientes()
        {
            Dictionary<int, long> ultimosChats = new Dictionary<int, long>();

            // Recorre los chats en Firebase para identificar los usuarios y su último mensaje
            var chats = await firebaseClient.Child("chats").OnceAsync<object>();

            foreach (var chat in chats)
            {
                string chatId = chat.Key;
                string[] ids = chatId.Split('-');

                if (ids.Length != 2) continue;

                if (!int.TryParse(ids[0], out int id1) || !int.TryParse(ids[1], out int id2)) continue;

                int otroUsuarioId = (id1 == Usuario.UsuarioId) ? id2 : (id2 == Usuario.UsuarioId ? id1 : -1);
                if (otroUsuarioId == -1) continue;

                // Obtener el último mensaje del chat
                var mensajes = await firebaseClient.Child("chats").Child(chatId).Child("messages")
                    .OrderBy("timestamp").LimitToLast(1).OnceAsync<FirebaseMessage>();

                if (mensajes.Any())
                {
                    long timestamp = mensajes.First().Object.timestamp;
                    if (!ultimosChats.ContainsKey(otroUsuarioId) || ultimosChats[otroUsuarioId] < timestamp)
                    {
                        ultimosChats[otroUsuarioId] = timestamp;
                    }
                }
            }

            // Ordenar usuarios por el último timestamp de chat en orden descendente
            var usuariosOrdenados = Usuario.ObtenerUsuarios()
                .Where(u => ultimosChats.ContainsKey(u.Id))
                .OrderByDescending(u => ultimosChats[u.Id])
                .ToList();

            return usuariosOrdenados;
        }


        private async void botonPersonalizado1_Click(object sender, EventArgs e)
            {
            listaUsuarios = await ObtenerUsuariosMasRecientes();
            paginaActual = 1; // Resetear a la primera página
            LlenarUsuarios();
            ActualizarLabelPagina();

        }




    }

}
