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

namespace AppOneCode
{
    public partial class FrmChat : Form
    {

        private int paginaActual = 1; // Página actual
        private int elementosPorPagina = 5; // Elementos por página
        private List<Usuario> listaUsuarios; // Lista de todos los usuarios

        public FrmChat()
        {
            InitializeComponent();
            LlenarUsuarios();
            ActualizarLabelPagina();
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
    }
}
