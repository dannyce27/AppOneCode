namespace AppOneCode.Vista
{
    partial class FrmPerfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPerfil));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMinimizeForm = new System.Windows.Forms.PictureBox();
            this.pbCloseForm = new System.Windows.Forms.PictureBox();
            this.pbImageTrabajador = new System.Windows.Forms.PictureBox();
            this.lblNicknameUSer = new System.Windows.Forms.Label();
            this.lblGmailUser = new System.Windows.Forms.Label();
            this.ctProgresoPerfil = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCambiarPerfil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageTrabajador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctProgresoPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(352, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Perfil";
            // 
            // pbMinimizeForm
            // 
            this.pbMinimizeForm.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbMinimizeForm.Image = global::AppOneCode.Properties.Resources.icons8_minimize_window_30;
            this.pbMinimizeForm.Location = new System.Drawing.Point(747, 12);
            this.pbMinimizeForm.Name = "pbMinimizeForm";
            this.pbMinimizeForm.Size = new System.Drawing.Size(32, 29);
            this.pbMinimizeForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinimizeForm.TabIndex = 92;
            this.pbMinimizeForm.TabStop = false;
            // 
            // pbCloseForm
            // 
            this.pbCloseForm.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbCloseForm.Image = global::AppOneCode.Properties.Resources.icons8_close_window_50;
            this.pbCloseForm.Location = new System.Drawing.Point(794, 12);
            this.pbCloseForm.Name = "pbCloseForm";
            this.pbCloseForm.Size = new System.Drawing.Size(32, 29);
            this.pbCloseForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCloseForm.TabIndex = 91;
            this.pbCloseForm.TabStop = false;
            this.pbCloseForm.Click += new System.EventHandler(this.pbCloseForm_Click);
            // 
            // pbImageTrabajador
            // 
            this.pbImageTrabajador.Image = ((System.Drawing.Image)(resources.GetObject("pbImageTrabajador.Image")));
            this.pbImageTrabajador.Location = new System.Drawing.Point(55, 33);
            this.pbImageTrabajador.Name = "pbImageTrabajador";
            this.pbImageTrabajador.Size = new System.Drawing.Size(162, 151);
            this.pbImageTrabajador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageTrabajador.TabIndex = 0;
            this.pbImageTrabajador.TabStop = false;
            // 
            // lblNicknameUSer
            // 
            this.lblNicknameUSer.AutoSize = true;
            this.lblNicknameUSer.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNicknameUSer.ForeColor = System.Drawing.Color.White;
            this.lblNicknameUSer.Location = new System.Drawing.Point(103, 257);
            this.lblNicknameUSer.Name = "lblNicknameUSer";
            this.lblNicknameUSer.Size = new System.Drawing.Size(65, 37);
            this.lblNicknameUSer.TabIndex = 93;
            this.lblNicknameUSer.Text = "NIck";
            // 
            // lblGmailUser
            // 
            this.lblGmailUser.AutoSize = true;
            this.lblGmailUser.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmailUser.ForeColor = System.Drawing.Color.White;
            this.lblGmailUser.Location = new System.Drawing.Point(26, 308);
            this.lblGmailUser.Name = "lblGmailUser";
            this.lblGmailUser.Size = new System.Drawing.Size(62, 28);
            this.lblGmailUser.TabIndex = 94;
            this.lblGmailUser.Text = "Gmail";
            // 
            // ctProgresoPerfil
            // 
            chartArea3.Name = "ChartArea1";
            this.ctProgresoPerfil.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ctProgresoPerfil.Legends.Add(legend3);
            this.ctProgresoPerfil.Location = new System.Drawing.Point(388, 197);
            this.ctProgresoPerfil.Name = "ctProgresoPerfil";
            this.ctProgresoPerfil.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "EstadoTareas";
            this.ctProgresoPerfil.Series.Add(series3);
            this.ctProgresoPerfil.Size = new System.Drawing.Size(363, 171);
            this.ctProgresoPerfil.TabIndex = 96;
            this.ctProgresoPerfil.Text = "chart1";
            this.ctProgresoPerfil.Click += new System.EventHandler(this.ctProgresoPerfil_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(90)))), ((int)(((byte)(143)))));
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(360, 144);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(420, 243);
            this.pictureBox9.TabIndex = 119;
            this.pictureBox9.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(90)))), ((int)(((byte)(143)))));
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(423, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 28);
            this.label5.TabIndex = 120;
            this.label5.Text = "Tareas completadas y pendientes";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCambiarPerfil);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblGmailUser);
            this.panel1.Controls.Add(this.lblNicknameUSer);
            this.panel1.Controls.Add(this.pbImageTrabajador);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 509);
            this.panel1.TabIndex = 121;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 413);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCambiarPerfil
            // 
            this.btnCambiarPerfil.Font = new System.Drawing.Font("Poppins Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarPerfil.Location = new System.Drawing.Point(64, 214);
            this.btnCambiarPerfil.Name = "btnCambiarPerfil";
            this.btnCambiarPerfil.Size = new System.Drawing.Size(139, 23);
            this.btnCambiarPerfil.TabIndex = 1;
            this.btnCambiarPerfil.Text = "Cambiar foto de Perfil";
            this.btnCambiarPerfil.UseVisualStyleBackColor = true;
            this.btnCambiarPerfil.Click += new System.EventHandler(this.btnCambiarPerfil_Click);
            // 
            // FrmPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(838, 509);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctProgresoPerfil);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pbMinimizeForm);
            this.Controls.Add(this.pbCloseForm);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPerfil";
            this.Load += new System.EventHandler(this.FrmPerfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageTrabajador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctProgresoPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImageTrabajador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMinimizeForm;
        private System.Windows.Forms.PictureBox pbCloseForm;
        private System.Windows.Forms.Label lblNicknameUSer;
        private System.Windows.Forms.Label lblGmailUser;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctProgresoPerfil;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCambiarPerfil;
    }
}