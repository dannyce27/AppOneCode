namespace AppOneCode.Vista
{
    partial class FrmCronometro
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCronometro));
            this.lblNumerosCrono = new System.Windows.Forms.Label();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMarcasTiempo = new System.Windows.Forms.ListBox();
            this.pbCloseForm = new System.Windows.Forms.PictureBox();
            this.pbMinimizeForm = new System.Windows.Forms.PictureBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPause = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            this.notifyIconCronometro = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumerosCrono
            // 
            this.lblNumerosCrono.AutoSize = true;
            this.lblNumerosCrono.BackColor = System.Drawing.Color.Silver;
            this.lblNumerosCrono.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumerosCrono.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumerosCrono.Location = new System.Drawing.Point(132, 25);
            this.lblNumerosCrono.Name = "lblNumerosCrono";
            this.lblNumerosCrono.Size = new System.Drawing.Size(126, 34);
            this.lblNumerosCrono.TabIndex = 95;
            this.lblNumerosCrono.Text = "00:00:00:00";
            // 
            // tmrTimer
            // 
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.lblNumerosCrono);
            this.panel1.Controls.Add(this.lbMarcasTiempo);
            this.panel1.Controls.Add(this.pbCloseForm);
            this.panel1.Controls.Add(this.pbMinimizeForm);
            this.panel1.Controls.Add(this.pbStop);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pbPause);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pbPlay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 242);
            this.panel1.TabIndex = 96;
            // 
            // lbMarcasTiempo
            // 
            this.lbMarcasTiempo.BackColor = System.Drawing.Color.Silver;
            this.lbMarcasTiempo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbMarcasTiempo.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarcasTiempo.FormattingEnabled = true;
            this.lbMarcasTiempo.ItemHeight = 22;
            this.lbMarcasTiempo.Location = new System.Drawing.Point(91, 151);
            this.lbMarcasTiempo.Name = "lbMarcasTiempo";
            this.lbMarcasTiempo.Size = new System.Drawing.Size(198, 70);
            this.lbMarcasTiempo.TabIndex = 97;
            this.lbMarcasTiempo.SelectedIndexChanged += new System.EventHandler(this.lbMarcasTiempo_SelectedIndexChanged);
            // 
            // pbCloseForm
            // 
            this.pbCloseForm.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbCloseForm.Image = global::AppOneCode.Properties.Resources.icons8_close_window_50;
            this.pbCloseForm.Location = new System.Drawing.Point(345, 12);
            this.pbCloseForm.Name = "pbCloseForm";
            this.pbCloseForm.Size = new System.Drawing.Size(20, 15);
            this.pbCloseForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCloseForm.TabIndex = 89;
            this.pbCloseForm.TabStop = false;
            this.pbCloseForm.Click += new System.EventHandler(this.pictureBox20_Click);
            // 
            // pbMinimizeForm
            // 
            this.pbMinimizeForm.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbMinimizeForm.Image = global::AppOneCode.Properties.Resources.icons8_minimize_window_30;
            this.pbMinimizeForm.Location = new System.Drawing.Point(322, 12);
            this.pbMinimizeForm.Name = "pbMinimizeForm";
            this.pbMinimizeForm.Size = new System.Drawing.Size(17, 15);
            this.pbMinimizeForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinimizeForm.TabIndex = 90;
            this.pbMinimizeForm.TabStop = false;
            this.pbMinimizeForm.Click += new System.EventHandler(this.pictureBox19_Click);
            // 
            // pbStop
            // 
            this.pbStop.BackColor = System.Drawing.Color.Silver;
            this.pbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStop.Image = ((System.Drawing.Image)(resources.GetObject("pbStop.Image")));
            this.pbStop.Location = new System.Drawing.Point(228, 81);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(30, 23);
            this.pbStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStop.TabIndex = 94;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marcas de Tiempo";
            // 
            // pbPause
            // 
            this.pbPause.BackColor = System.Drawing.Color.Silver;
            this.pbPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPause.Image = ((System.Drawing.Image)(resources.GetObject("pbPause.Image")));
            this.pbPause.Location = new System.Drawing.Point(183, 81);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(27, 23);
            this.pbPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPause.TabIndex = 93;
            this.pbPause.TabStop = false;
            this.pbPause.Click += new System.EventHandler(this.pbPause_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 91;
            this.pictureBox1.TabStop = false;
            // 
            // pbPlay
            // 
            this.pbPlay.BackColor = System.Drawing.Color.Silver;
            this.pbPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlay.Image = ((System.Drawing.Image)(resources.GetObject("pbPlay.Image")));
            this.pbPlay.Location = new System.Drawing.Point(136, 79);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(25, 23);
            this.pbPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlay.TabIndex = 92;
            this.pbPlay.TabStop = false;
            this.pbPlay.Click += new System.EventHandler(this.pbPlay_Click);
            // 
            // notifyIconCronometro
            // 
            this.notifyIconCronometro.Text = "Cronómetro en ejecución";
            this.notifyIconCronometro.Visible = true;
            this.notifyIconCronometro.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconCronometro_MouseDoubleClick);
            // 
            // FrmCronometro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 242);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCronometro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCronometro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCronometro_FormClosing);
            this.Load += new System.EventHandler(this.FrmCronometro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCloseForm;
        private System.Windows.Forms.PictureBox pbMinimizeForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbPlay;
        private System.Windows.Forms.PictureBox pbPause;
        private System.Windows.Forms.PictureBox pbStop;
        private System.Windows.Forms.Label lblNumerosCrono;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbMarcasTiempo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIconCronometro;
    }
}