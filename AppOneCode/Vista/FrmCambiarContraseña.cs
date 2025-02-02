using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppOneCode.Vista
{
    public partial class FrmCambiarContraseña : Form
    {
        public FrmCambiarContraseña()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCambiarContraseña = new AppOneCode.Modelo.BotonPersonalizado();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.txtContrasenaUsuarioN = new System.Windows.Forms.TextBox();
            this.txtemailR = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtContrasenaUsuarioConfirm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtContrasenaUsuarioConfirm);
            this.panel1.Controls.Add(this.btnCambiarContraseña);
            this.panel1.Controls.Add(this.pictureBox10);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.txtContrasenaUsuarioN);
            this.panel1.Controls.Add(this.txtemailR);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 404);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(146, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cambiar Contraseña";
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.BackColor = System.Drawing.Color.White;
            this.btnCambiarContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarContraseña.FlatAppearance.BorderSize = 0;
            this.btnCambiarContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarContraseña.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarContraseña.ForeColor = System.Drawing.Color.Black;
            this.btnCambiarContraseña.Location = new System.Drawing.Point(183, 329);
            this.btnCambiarContraseña.Margin = new System.Windows.Forms.Padding(0);
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            this.btnCambiarContraseña.Size = new System.Drawing.Size(233, 40);
            this.btnCambiarContraseña.TabIndex = 33;
            this.btnCambiarContraseña.Text = "Cambiar Contraseña";
            this.btnCambiarContraseña.UseVisualStyleBackColor = false;
            this.btnCambiarContraseña.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.White;
            this.pictureBox10.Image = global::AppOneCode.Properties.Resources.icons8_mail_50;
            this.pictureBox10.Location = new System.Drawing.Point(182, 125);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(34, 29);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 32;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.Image = global::AppOneCode.Properties.Resources.icons8_password_24;
            this.pictureBox8.Location = new System.Drawing.Point(183, 200);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(33, 30);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 31;
            this.pictureBox8.TabStop = false;
            // 
            // txtContrasenaUsuarioN
            // 
            this.txtContrasenaUsuarioN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasenaUsuarioN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenaUsuarioN.Location = new System.Drawing.Point(222, 203);
            this.txtContrasenaUsuarioN.Name = "txtContrasenaUsuarioN";
            this.txtContrasenaUsuarioN.PasswordChar = '*';
            this.txtContrasenaUsuarioN.Size = new System.Drawing.Size(194, 22);
            this.txtContrasenaUsuarioN.TabIndex = 30;
            this.txtContrasenaUsuarioN.TextChanged += new System.EventHandler(this.txtContrasenaUsuarioN_TextChanged);
            // 
            // txtemailR
            // 
            this.txtemailR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtemailR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemailR.Location = new System.Drawing.Point(222, 125);
            this.txtemailR.Name = "txtemailR";
            this.txtemailR.Size = new System.Drawing.Size(194, 22);
            this.txtemailR.TabIndex = 29;
            this.txtemailR.TextChanged += new System.EventHandler(this.txtemailR_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::AppOneCode.Properties.Resources.icons8_password_24;
            this.pictureBox1.Location = new System.Drawing.Point(183, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // txtContrasenaUsuarioConfirm
            // 
            this.txtContrasenaUsuarioConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasenaUsuarioConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenaUsuarioConfirm.Location = new System.Drawing.Point(222, 275);
            this.txtContrasenaUsuarioConfirm.Name = "txtContrasenaUsuarioConfirm";
            this.txtContrasenaUsuarioConfirm.PasswordChar = '*';
            this.txtContrasenaUsuarioConfirm.Size = new System.Drawing.Size(194, 22);
            this.txtContrasenaUsuarioConfirm.TabIndex = 34;
            this.txtContrasenaUsuarioConfirm.TextChanged += new System.EventHandler(this.txtContrasenaUsuarioConfirm_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(238, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "Correo Electronico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(238, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Nueva Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(238, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 23);
            this.label4.TabIndex = 38;
            this.label4.Text = "ConfirmarContraseña";
            // 
            // FrmCambiarContraseña
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(616, 404);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCambiarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCambiarContraseña_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void FrmCambiarContraseña_Load(object sender, EventArgs e)
        {
            int radio = 30; // Ajusta el radio de curvatura (entre mas alto mas se ve la curva)

           
            AplicarBordesRedondeados(this, radio);
            AplicarBordesRedondeados(panel1, radio - 5);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void AplicarBordesRedondeados(Control control, int radio)
        {
            // Aplicar bordes redondeados a cualquier control (Formulario o Panel)
            GraphicsPath path = CrearRectanguloRedondeado(control.ClientRectangle, radio);
            control.Region = new Region(path);
        }

        private GraphicsPath CrearRectanguloRedondeado(Rectangle rect, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radio * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void txtemailR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasenaUsuarioN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasenaUsuarioConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            string email = txtemailR.Text.Trim();
            string nuevaContrasena = txtContrasenaUsuarioN.Text.Trim();
            string confirmarContrasena = txtContrasenaUsuarioConfirm.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nuevaContrasena) || string.IsNullOrEmpty(confirmarContrasena))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nuevaContrasena != confirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuario = new Usuario();
            bool cambioExitoso = usuario.CambiarContraseñaPorCorreo(email, nuevaContrasena);

            if (cambioExitoso)
            {
                MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmLogin frl = new FrmLogin();
                this.Hide();
                frl.ShowDialog();
                
                
            }
            else
            {
                MessageBox.Show("No se encontró el correo o hubo un error al cambiar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
