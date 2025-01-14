namespace AppOneCode.Vista
{
    partial class UserControlTareas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlTareas));
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblDescTarea = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pbTaskComplete = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbAgregarComent = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbEncargadoTarea = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTaskComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregarComent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEncargadoTarea)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrioridad.Location = new System.Drawing.Point(482, 12);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(73, 23);
            this.lblPrioridad.TabIndex = 4;
            this.lblPrioridad.Text = "Prioridad";
            this.lblPrioridad.Click += new System.EventHandler(this.lblPrioridad_Click);
            // 
            // lblDescTarea
            // 
            this.lblDescTarea.AutoSize = true;
            this.lblDescTarea.Font = new System.Drawing.Font("Poppins Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescTarea.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDescTarea.Location = new System.Drawing.Point(53, 12);
            this.lblDescTarea.Name = "lblDescTarea";
            this.lblDescTarea.Size = new System.Drawing.Size(147, 22);
            this.lblDescTarea.TabIndex = 1;
            this.lblDescTarea.Text = "Descripcion de la Tarea";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pbTaskComplete);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.pbEncargadoTarea);
            this.panel1.Controls.Add(this.lblPrioridad);
            this.panel1.Controls.Add(this.pbAgregarComent);
            this.panel1.Controls.Add(this.lblDescTarea);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 47);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(688, 11);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(55, 23);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado";
            // 
            // pbTaskComplete
            // 
            this.pbTaskComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTaskComplete.Image = ((System.Drawing.Image)(resources.GetObject("pbTaskComplete.Image")));
            this.pbTaskComplete.Location = new System.Drawing.Point(872, 12);
            this.pbTaskComplete.Name = "pbTaskComplete";
            this.pbTaskComplete.Size = new System.Drawing.Size(28, 23);
            this.pbTaskComplete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTaskComplete.TabIndex = 9;
            this.pbTaskComplete.TabStop = false;
            this.pbTaskComplete.Click += new System.EventHandler(this.pbTaskComplete_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(817, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pbAgregarComent
            // 
            this.pbAgregarComent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAgregarComent.Image = ((System.Drawing.Image)(resources.GetObject("pbAgregarComent.Image")));
            this.pbAgregarComent.Location = new System.Drawing.Point(411, 12);
            this.pbAgregarComent.Name = "pbAgregarComent";
            this.pbAgregarComent.Size = new System.Drawing.Size(29, 26);
            this.pbAgregarComent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAgregarComent.TabIndex = 2;
            this.pbAgregarComent.TabStop = false;
            this.pbAgregarComent.Click += new System.EventHandler(this.pbAgregarComent_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(669, -1);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(94, 48);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.pictureBox3.Location = new System.Drawing.Point(460, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(123, 48);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pbEncargadoTarea
            // 
            this.pbEncargadoTarea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEncargadoTarea.Image = ((System.Drawing.Image)(resources.GetObject("pbEncargadoTarea.Image")));
            this.pbEncargadoTarea.Location = new System.Drawing.Point(615, 12);
            this.pbEncargadoTarea.Name = "pbEncargadoTarea";
            this.pbEncargadoTarea.Size = new System.Drawing.Size(48, 23);
            this.pbEncargadoTarea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEncargadoTarea.TabIndex = 5;
            this.pbEncargadoTarea.TabStop = false;
            // 
            // UserControlTareas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panel1);
            this.Name = "UserControlTareas";
            this.Size = new System.Drawing.Size(955, 47);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTaskComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregarComent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEncargadoTarea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Label lblDescTarea;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbTaskComplete;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pbEncargadoTarea;
        private System.Windows.Forms.PictureBox pbAgregarComent;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}
