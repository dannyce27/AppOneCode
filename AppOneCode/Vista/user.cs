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
    public partial class user : UserControl
    {
        public event EventHandler<UsuarioEventArgs> UsuarioSeleccionado;

        private int id;
        private string name;
        private bool estadoOnline;
        public bool EstadoOnline
        {
            get { return estadoOnline; }
            set
            {
                estadoOnline = value;
                ActualizarEstado();
            }
        }




        public user()
        {
            InitializeComponent();

        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;

            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }


        private void user_Load(object sender, EventArgs e)
        {

        }

        private void pbEstado_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarEstado()
        {
            if (pbEstado != null)
            {
                pbEstado.BackColor = EstadoOnline ? Color.Green : Color.Red;
            }
        }

        private void user_Click(object sender, EventArgs e)
        {
            OnUsuarioSeleccionado();
        }

        private void OnUsuarioSeleccionado()
        {
            Usuario usuario = new Usuario { Id = this.Id, Username = this.Name };
            UsuarioSeleccionado?.Invoke(this, new UsuarioEventArgs(usuario));
        }

        public class UsuarioEventArgs : EventArgs
        {
            public Usuario Usuario { get; }

            public UsuarioEventArgs(Usuario usuario)
            {
                Usuario = usuario;
            }
        }

    }
}
