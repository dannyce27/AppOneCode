using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            set { id = value; }
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

        private void pbTaskComplete_Click(object sender, EventArgs e)
        {
            try
            {
                
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
    }
}
