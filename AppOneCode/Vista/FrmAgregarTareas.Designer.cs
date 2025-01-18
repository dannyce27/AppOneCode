namespace AppOneCode.Vista
{
    partial class FrmAgregarTareas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarTareas));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMostrarProyectosI = new System.Windows.Forms.DataGridView();
            this.txtSearchProyect = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescP = new System.Windows.Forms.TextBox();
            this.txtNombreProyecto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEmpleadoAsignado = new System.Windows.Forms.ComboBox();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbActualizarTarea = new System.Windows.Forms.PictureBox();
            this.pbEliminarProyecto = new System.Windows.Forms.PictureBox();
            this.pbAgregarProyecto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarProyectosI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActualizarTarea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminarProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregarProyecto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(448, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tareas";
            // 
            // dgvMostrarProyectosI
            // 
            this.dgvMostrarProyectosI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMostrarProyectosI.BackgroundColor = System.Drawing.Color.White;
            this.dgvMostrarProyectosI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrarProyectosI.Location = new System.Drawing.Point(238, 518);
            this.dgvMostrarProyectosI.Name = "dgvMostrarProyectosI";
            this.dgvMostrarProyectosI.Size = new System.Drawing.Size(635, 252);
            this.dgvMostrarProyectosI.TabIndex = 130;
            // 
            // txtSearchProyect
            // 
            this.txtSearchProyect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProyect.Location = new System.Drawing.Point(366, 448);
            this.txtSearchProyect.Name = "txtSearchProyect";
            this.txtSearchProyect.Size = new System.Drawing.Size(364, 20);
            this.txtSearchProyect.TabIndex = 129;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(295, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 128;
            this.label7.Text = "Buscar";
            // 
            // txtDescP
            // 
            this.txtDescP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescP.Location = new System.Drawing.Point(366, 119);
            this.txtDescP.Name = "txtDescP";
            this.txtDescP.Size = new System.Drawing.Size(364, 20);
            this.txtDescP.TabIndex = 123;
            this.txtDescP.TextChanged += new System.EventHandler(this.txtEncargadoProyecto_TextChanged);
            // 
            // txtNombreProyecto
            // 
            this.txtNombreProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProyecto.Location = new System.Drawing.Point(276, -30);
            this.txtNombreProyecto.Name = "txtNombreProyecto";
            this.txtNombreProyecto.Size = new System.Drawing.Size(364, 20);
            this.txtNombreProyecto.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(234, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 121;
            this.label6.Text = "Descripción:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(163, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 20);
            this.label5.TabIndex = 120;
            this.label5.Text = "Empleado Asignado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(252, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 119;
            this.label4.Text = "Prioridad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(149, -30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 118;
            this.label3.Text = "Nombre:";
            // 
            // cmbEmpleadoAsignado
            // 
            this.cmbEmpleadoAsignado.FormattingEnabled = true;
            this.cmbEmpleadoAsignado.Location = new System.Drawing.Point(366, 166);
            this.cmbEmpleadoAsignado.Name = "cmbEmpleadoAsignado";
            this.cmbEmpleadoAsignado.Size = new System.Drawing.Size(364, 21);
            this.cmbEmpleadoAsignado.TabIndex = 132;
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Location = new System.Drawing.Point(366, 220);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(364, 21);
            this.cmbPrioridad.TabIndex = 133;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(366, 274);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(364, 21);
            this.cmbEstado.TabIndex = 135;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(252, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 134;
            this.label2.Text = "Estado:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 138;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox19
            // 
            this.pictureBox19.Image = global::AppOneCode.Properties.Resources.icons8_minimize_window_30;
            this.pictureBox19.Location = new System.Drawing.Point(965, 12);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(32, 29);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox19.TabIndex = 137;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Click += new System.EventHandler(this.pictureBox19_Click);
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = global::AppOneCode.Properties.Resources.icons8_close_window_50;
            this.pictureBox20.Location = new System.Drawing.Point(1003, 12);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(32, 29);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 136;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Click += new System.EventHandler(this.pictureBox20_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(774, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 291);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 131;
            this.pictureBox1.TabStop = false;
            // 
            // pbActualizarTarea
            // 
            this.pbActualizarTarea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.pbActualizarTarea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbActualizarTarea.Image = ((System.Drawing.Image)(resources.GetObject("pbActualizarTarea.Image")));
            this.pbActualizarTarea.Location = new System.Drawing.Point(665, 355);
            this.pbActualizarTarea.Name = "pbActualizarTarea";
            this.pbActualizarTarea.Size = new System.Drawing.Size(65, 52);
            this.pbActualizarTarea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbActualizarTarea.TabIndex = 127;
            this.pbActualizarTarea.TabStop = false;
            this.pbActualizarTarea.Click += new System.EventHandler(this.pbActualizarProyecto_Click);
            // 
            // pbEliminarProyecto
            // 
            this.pbEliminarProyecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.pbEliminarProyecto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEliminarProyecto.Image = ((System.Drawing.Image)(resources.GetObject("pbEliminarProyecto.Image")));
            this.pbEliminarProyecto.Location = new System.Drawing.Point(513, 355);
            this.pbEliminarProyecto.Name = "pbEliminarProyecto";
            this.pbEliminarProyecto.Size = new System.Drawing.Size(65, 52);
            this.pbEliminarProyecto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEliminarProyecto.TabIndex = 126;
            this.pbEliminarProyecto.TabStop = false;
            this.pbEliminarProyecto.Click += new System.EventHandler(this.pbEliminarProyecto_Click);
            // 
            // pbAgregarProyecto
            // 
            this.pbAgregarProyecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.pbAgregarProyecto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAgregarProyecto.Image = ((System.Drawing.Image)(resources.GetObject("pbAgregarProyecto.Image")));
            this.pbAgregarProyecto.Location = new System.Drawing.Point(366, 355);
            this.pbAgregarProyecto.Name = "pbAgregarProyecto";
            this.pbAgregarProyecto.Size = new System.Drawing.Size(62, 52);
            this.pbAgregarProyecto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAgregarProyecto.TabIndex = 117;
            this.pbAgregarProyecto.TabStop = false;
            this.pbAgregarProyecto.Click += new System.EventHandler(this.pbAgregarProyecto_Click);
            // 
            // FrmAgregarTareas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1058, 797);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox19);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.cmbEmpleadoAsignado);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvMostrarProyectosI);
            this.Controls.Add(this.txtSearchProyect);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbActualizarTarea);
            this.Controls.Add(this.pbEliminarProyecto);
            this.Controls.Add(this.pbAgregarProyecto);
            this.Controls.Add(this.txtDescP);
            this.Controls.Add(this.txtNombreProyecto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarTareas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAgregarTareas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarProyectosI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActualizarTarea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminarProyecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregarProyecto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMostrarProyectosI;
        private System.Windows.Forms.TextBox txtSearchProyect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbActualizarTarea;
        private System.Windows.Forms.PictureBox pbEliminarProyecto;
        private System.Windows.Forms.PictureBox pbAgregarProyecto;
        private System.Windows.Forms.TextBox txtDescP;
        private System.Windows.Forms.TextBox txtNombreProyecto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbEmpleadoAsignado;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}