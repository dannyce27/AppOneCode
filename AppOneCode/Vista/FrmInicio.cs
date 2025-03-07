﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppOneCode.Vista;

namespace AppOneCode
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            int usuarioId = Usuario.UsuarioId;

            // Llamas al método para obtener el nombre de usuario
            string username = Usuario.ObtenerNombreUsuario(usuarioId);


            if (!string.IsNullOrEmpty(username))
            {
                lblUsername.Text = username;
            }
            else
            {
                MessageBox.Show("No se pudo cargar el nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbltareas_Click(object sender, EventArgs e)
        {
            FrmTareas Ft = new FrmTareas();
            this.Hide();
            Ft.ShowDialog();
        }

        private void lblinicio_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            FrmDashboard Ft = new FrmDashboard();
            this.Hide();
            Ft.ShowDialog();
        }

        private void lblproyectos_Click(object sender, EventArgs e)
        {
            frmProyectos frm = new frmProyectos();
            this.Hide();
            frm.ShowDialog();
        }

        private void lblrecursos_Click(object sender, EventArgs e)
        {

        }

        private void lblfaq_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblchat_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int idTipoUsuario = Usuario.ObtenerIdTipoUsuario(Usuario.UsuarioId); // Obtiene el tipo de usuario

            switch (idTipoUsuario)
            {
                case 1: // Administrador
                    frmAgregarUsuario frmAdmin = new frmAgregarUsuario();
                    this.Hide();
                    frmAdmin.Show();
                    break;
                case 2: // Empleado
                    FrmPerfil frmEmpleado = new FrmPerfil();
                    this.Hide();
                    frmEmpleado.Show();
                    break;
                default:
                    MessageBox.Show("Rol no reconocido. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }

        }

        private void botonPersonalizado1_Click(object sender, EventArgs e)
        {
            FrmChat Ft = new FrmChat();
            this.Hide();
            Ft.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
