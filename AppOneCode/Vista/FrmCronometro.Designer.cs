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
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            this.pbPause = new System.Windows.Forms.PictureBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.lblNumerosCrono = new System.Windows.Forms.Label();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox20
            // 
            this.pictureBox20.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox20.Image = global::AppOneCode.Properties.Resources.icons8_close_window_50;
            this.pictureBox20.Location = new System.Drawing.Point(620, 12);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(32, 29);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 89;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Click += new System.EventHandler(this.pictureBox20_Click);
            // 
            // pictureBox19
            // 
            this.pictureBox19.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox19.Image = global::AppOneCode.Properties.Resources.icons8_minimize_window_30;
            this.pictureBox19.Location = new System.Drawing.Point(573, 12);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(32, 29);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox19.TabIndex = 90;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Click += new System.EventHandler(this.pictureBox19_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 91;
            this.pictureBox1.TabStop = false;
            // 
            // pbPlay
            // 
            this.pbPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.pbPlay.Image = ((System.Drawing.Image)(resources.GetObject("pbPlay.Image")));
            this.pbPlay.Location = new System.Drawing.Point(269, 150);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(86, 68);
            this.pbPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlay.TabIndex = 92;
            this.pbPlay.TabStop = false;
            this.pbPlay.Click += new System.EventHandler(this.pbPlay_Click);
            // 
            // pbPause
            // 
            this.pbPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.pbPause.Image = ((System.Drawing.Image)(resources.GetObject("pbPause.Image")));
            this.pbPause.Location = new System.Drawing.Point(387, 150);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(87, 68);
            this.pbPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPause.TabIndex = 93;
            this.pbPause.TabStop = false;
            this.pbPause.Click += new System.EventHandler(this.pbPause_Click);
            // 
            // pbStop
            // 
            this.pbStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.pbStop.Image = ((System.Drawing.Image)(resources.GetObject("pbStop.Image")));
            this.pbStop.Location = new System.Drawing.Point(503, 150);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(87, 68);
            this.pbStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStop.TabIndex = 94;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
            // 
            // lblNumerosCrono
            // 
            this.lblNumerosCrono.AutoSize = true;
            this.lblNumerosCrono.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumerosCrono.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumerosCrono.Location = new System.Drawing.Point(332, 81);
            this.lblNumerosCrono.Name = "lblNumerosCrono";
            this.lblNumerosCrono.Size = new System.Drawing.Size(188, 48);
            this.lblNumerosCrono.TabIndex = 95;
            this.lblNumerosCrono.Text = "00:00:00:00";
            // 
            // tmrTimer
            // 
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // FrmCronometro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(664, 285);
            this.Controls.Add(this.lblNumerosCrono);
            this.Controls.Add(this.pbStop);
            this.Controls.Add(this.pbPause);
            this.Controls.Add(this.pbPlay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox19);
            this.Controls.Add(this.pictureBox20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCronometro";
            this.Text = "FrmCronometro";
            this.Load += new System.EventHandler(this.FrmCronometro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbPlay;
        private System.Windows.Forms.PictureBox pbPause;
        private System.Windows.Forms.PictureBox pbStop;
        private System.Windows.Forms.Label lblNumerosCrono;
        private System.Windows.Forms.Timer tmrTimer;
    }
}