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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCambiarPerfil = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageTrabajador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctProgresoPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 31);
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
            this.pbMinimizeForm.Click += new System.EventHandler(this.pbMinimizeForm_Click);
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
            this.pbImageTrabajador.Location = new System.Drawing.Point(67, 122);
            this.pbImageTrabajador.Name = "pbImageTrabajador";
            this.pbImageTrabajador.Size = new System.Drawing.Size(162, 151);
            this.pbImageTrabajador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageTrabajador.TabIndex = 0;
            this.pbImageTrabajador.TabStop = false;
            this.pbImageTrabajador.Click += new System.EventHandler(this.pbImageTrabajador_Click);
            // 
            // lblNicknameUSer
            // 
            this.lblNicknameUSer.AutoSize = true;
            this.lblNicknameUSer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNicknameUSer.ForeColor = System.Drawing.Color.White;
            this.lblNicknameUSer.Location = new System.Drawing.Point(115, 346);
            this.lblNicknameUSer.Name = "lblNicknameUSer";
            this.lblNicknameUSer.Size = new System.Drawing.Size(58, 25);
            this.lblNicknameUSer.TabIndex = 93;
            this.lblNicknameUSer.Text = "NIck";
            // 
            // lblGmailUser
            // 
            this.lblGmailUser.AutoSize = true;
            this.lblGmailUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmailUser.ForeColor = System.Drawing.Color.White;
            this.lblGmailUser.Location = new System.Drawing.Point(38, 397);
            this.lblGmailUser.Name = "lblGmailUser";
            this.lblGmailUser.Size = new System.Drawing.Size(55, 20);
            this.lblGmailUser.TabIndex = 94;
            this.lblGmailUser.Text = "Gmail";
            // 
            // ctProgresoPerfil
            // 
            chartArea1.Name = "ChartArea1";
            this.ctProgresoPerfil.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ctProgresoPerfil.Legends.Add(legend1);
            this.ctProgresoPerfil.Location = new System.Drawing.Point(345, 195);
            this.ctProgresoPerfil.Name = "ctProgresoPerfil";
            this.ctProgresoPerfil.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "EstadoTareas";
            this.ctProgresoPerfil.Series.Add(series1);
            this.ctProgresoPerfil.Size = new System.Drawing.Size(363, 171);
            this.ctProgresoPerfil.TabIndex = 96;
            this.ctProgresoPerfil.Text = "chart1";
            this.ctProgresoPerfil.Click += new System.EventHandler(this.ctProgresoPerfil_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(90)))), ((int)(((byte)(143)))));
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(337, 176);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(379, 209);
            this.pictureBox9.TabIndex = 119;
            this.pictureBox9.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(338, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(367, 25);
            this.label5.TabIndex = 120;
            this.label5.Text = "Tareas completadas y pendientes";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ctProgresoPerfil);
            this.panel1.Controls.Add(this.btnCambiarPerfil);
            this.panel1.Controls.Add(this.pictureBox9);
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
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(30, 451);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 121;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnCambiarPerfil
            // 
            this.btnCambiarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarPerfil.Location = new System.Drawing.Point(76, 303);
            this.btnCambiarPerfil.Name = "btnCambiarPerfil";
            this.btnCambiarPerfil.Size = new System.Drawing.Size(139, 23);
            this.btnCambiarPerfil.TabIndex = 1;
            this.btnCambiarPerfil.Text = "Cambiar foto de Perfil";
            this.btnCambiarPerfil.UseVisualStyleBackColor = true;
            this.btnCambiarPerfil.Click += new System.EventHandler(this.btnCambiarPerfil_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(767, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(838, 509);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}