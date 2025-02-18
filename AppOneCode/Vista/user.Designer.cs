namespace AppOneCode.Vista
{
    partial class user
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(user));
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.pbEstado = new System.Windows.Forms.PictureBox();
            this.pbFotoPerfil = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(85, 30);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(96, 16);
            this.lblNombreUsuario.TabIndex = 144;
            this.lblNombreUsuario.Text = "Daniel Soriano";
            // 
            // pbEstado
            // 
            this.pbEstado.Image = ((System.Drawing.Image)(resources.GetObject("pbEstado.Image")));
            this.pbEstado.Location = new System.Drawing.Point(45, 51);
            this.pbEstado.Name = "pbEstado";
            this.pbEstado.Size = new System.Drawing.Size(14, 14);
            this.pbEstado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEstado.TabIndex = 143;
            this.pbEstado.TabStop = false;
            this.pbEstado.Click += new System.EventHandler(this.pbEstado_Click);
            // 
            // pbFotoPerfil
            // 
            this.pbFotoPerfil.Image = ((System.Drawing.Image)(resources.GetObject("pbFotoPerfil.Image")));
            this.pbFotoPerfil.Location = new System.Drawing.Point(13, 14);
            this.pbFotoPerfil.Name = "pbFotoPerfil";
            this.pbFotoPerfil.Size = new System.Drawing.Size(46, 46);
            this.pbFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoPerfil.TabIndex = 142;
            this.pbFotoPerfil.TabStop = false;
            // 
            // user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.pbEstado);
            this.Controls.Add(this.pbFotoPerfil);
            this.Name = "user";
            this.Size = new System.Drawing.Size(224, 78);
            this.Load += new System.EventHandler(this.user_Load);
            this.Click += new System.EventHandler(this.user_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.PictureBox pbEstado;
        private System.Windows.Forms.PictureBox pbFotoPerfil;
    }
}
