namespace AppOneCode.Vista
{
    partial class UserControlTareasPendientes
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
            this.lblNombreTareaPendiente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombreTareaPendiente
            // 
            this.lblNombreTareaPendiente.AutoSize = true;
            this.lblNombreTareaPendiente.Font = new System.Drawing.Font("Poppins Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreTareaPendiente.Location = new System.Drawing.Point(25, 12);
            this.lblNombreTareaPendiente.Name = "lblNombreTareaPendiente";
            this.lblNombreTareaPendiente.Size = new System.Drawing.Size(210, 28);
            this.lblNombreTareaPendiente.TabIndex = 0;
            this.lblNombreTareaPendiente.Text = "Nombre Tarea Pendiente";
            // 
            // UserControlTareasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(90)))), ((int)(((byte)(143)))));
            this.Controls.Add(this.lblNombreTareaPendiente);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UserControlTareasPendientes";
            this.Size = new System.Drawing.Size(260, 51);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreTareaPendiente;
    }
}
