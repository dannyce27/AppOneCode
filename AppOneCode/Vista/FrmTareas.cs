using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppOneCode.Modelo;

namespace AppOneCode.Vista
{
    public partial class FrmTareas : Form
    {

        private int paginaActual = 1; // Página actual
        private int elementosPorPagina = 8; // Elementos por página
        private List<Tareas2> listaTareas; // Lista de todas las tareas

        public FrmTareas()
        {
            InitializeComponent();
            LLenarTareas();
            ActualizarNumeroTareasCompletadas();

            
            paginaActual = 1; // Página inicial
            elementosPorPagina = 8; // Elementos por página
            LLenarTareas(); // Cargar los datos de la primera página
            ActualizarLabelPagina(); // Actualizar el label de la página
        }

        private void LLenarTareas()
        {
            flowLayoutPanel1.Controls.Clear();

            if (listaTareas == null)
            {
                Tareas2 obj = new Tareas2();
                listaTareas = obj.ObtenerTareas(); // Obtener todas las tareas como una lista
            }

            // Calcular los elementos que se mostrarán en la página actual
            int inicio = (paginaActual - 1) * elementosPorPagina;
            int fin = Math.Min(inicio + elementosPorPagina, listaTareas.Count);

            for (int i = inicio; i < fin; i++)
            {
                Tareas2 tarea = listaTareas[i];

                // Crear un UserControlTareas para cada tarea
                UserControlTareas userControlTareas = new UserControlTareas
                {
                    Id = tarea.Id,
                    Descripcion = tarea.Descripcion,
                    Prioridad = tarea.Prioridad,
                    Estado = tarea.Estado
                };

                // Agregar el control al FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(userControlTareas);
            }
        }

        private void ActualizarEtiquetaPagina()
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (txtBuscar.Text == "Buscar proyectos o tareas")
            {
                txtBuscar.ForeColor = Color.Gray;
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblinicio_Click(object sender, EventArgs e)
        {
            FrmInicio fI = new FrmInicio();
            this.Hide();
            fI.ShowDialog();
        }

        private void lblDasboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            this.Hide();
            frmDashboard.Show();
        }

        private void lblproyectos_Click(object sender, EventArgs e)
        {
            frmProyectos fp = new frmProyectos();
            this.Hide();
            fp.ShowDialog();
        }

        private void lblrecursos_Click(object sender, EventArgs e)
        {

        }

        private void pbAgregarProyecto_Click(object sender, EventArgs e)
        {
            FrmAgregarTareas frmAggTareas = new FrmAgregarTareas();
            this.Hide();
            frmAggTareas.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ActualizarNumeroTareasCompletadas()
        {
            Tareas2 objTareas = new Tareas2();
            int usuarioId = Usuario.UsuarioId; // Reemplazar con el ID real del usuario actual
            int tareasCompletadas = objTareas.ObtenerTareasCompletadasPorUsuario(usuarioId);

            lblNumeroTC.Text = $"{tareasCompletadas}";
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                LLenarTareas(); // Actualiza el contenido de la página
                ActualizarLabelPagina(); // Actualiza el label con la página actual
            }
        }

        private void ActualizarLabelPagina()
        {
            int totalPaginas = (int)Math.Ceiling((double)listaTareas.Count / elementosPorPagina);
            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";
        }

        private void btnSiguiiente_Click(object sender, EventArgs e)
        {
            // Comprobar si hay más páginas
            int totalPaginas = (int)Math.Ceiling((double)listaTareas.Count / elementosPorPagina);

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                LLenarTareas(); // Actualiza el contenido de la página
                ActualizarLabelPagina(); // Actualiza el label con la página actual
            }
        }

        private void botonPersonalizado1_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                LLenarTareas(); // Actualiza el contenido de la página
                ActualizarLabelPagina(); // Actualiza el label con la página actual
            }
        }

        private void botonPersonalizado2_Click(object sender, EventArgs e)
        {
            // Comprobar si hay más páginas
            int totalPaginas = (int)Math.Ceiling((double)listaTareas.Count / elementosPorPagina);

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                LLenarTareas(); // Actualiza el contenido de la página
                ActualizarLabelPagina(); // Actualiza el label con la página actual
            }
        }

        private void botonPersonalizado3_Click(object sender, EventArgs e)
        {
            FrmAgregarTareas frmAgregarTareas = new FrmAgregarTareas();
            this.Hide();
            frmAgregarTareas.ShowDialog();
        }
    }
}
