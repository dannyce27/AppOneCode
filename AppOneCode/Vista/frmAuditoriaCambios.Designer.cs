﻿namespace AppOneCode.Vista
{
    partial class frmAuditoriaCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuditoriaCambios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.botonPersonalizado1 = new AppOneCode.Modelo.BotonPersonalizado();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvCambiosProyectos = new System.Windows.Forms.DataGridView();
            this.dgvCambiosTareas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambiosProyectos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambiosTareas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.botonPersonalizado1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.dgvCambiosProyectos);
            this.panel1.Controls.Add(this.dgvCambiosTareas);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 658);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // botonPersonalizado1
            // 
            this.botonPersonalizado1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.botonPersonalizado1.FlatAppearance.BorderSize = 0;
            this.botonPersonalizado1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonPersonalizado1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPersonalizado1.ForeColor = System.Drawing.Color.White;
            this.botonPersonalizado1.Location = new System.Drawing.Point(28, 46);
            this.botonPersonalizado1.Name = "botonPersonalizado1";
            this.botonPersonalizado1.Size = new System.Drawing.Size(150, 54);
            this.botonPersonalizado1.TabIndex = 134;
            this.botonPersonalizado1.Text = "Volver";
            this.botonPersonalizado1.UseVisualStyleBackColor = false;
            this.botonPersonalizado1.Click += new System.EventHandler(this.botonPersonalizado1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(861, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 133;
            this.pictureBox1.TabStop = false;
            // 
            // dgvCambiosProyectos
            // 
            this.dgvCambiosProyectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCambiosProyectos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCambiosProyectos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCambiosProyectos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCambiosProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCambiosProyectos.EnableHeadersVisualStyles = false;
            this.dgvCambiosProyectos.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCambiosProyectos.Location = new System.Drawing.Point(28, 427);
            this.dgvCambiosProyectos.Name = "dgvCambiosProyectos";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(90)))), ((int)(((byte)(143)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCambiosProyectos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCambiosProyectos.Size = new System.Drawing.Size(955, 219);
            this.dgvCambiosProyectos.TabIndex = 132;
            this.dgvCambiosProyectos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCambiosProyectos_CellContentClick);
            // 
            // dgvCambiosTareas
            // 
            this.dgvCambiosTareas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCambiosTareas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCambiosTareas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Poppins Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCambiosTareas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCambiosTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCambiosTareas.EnableHeadersVisualStyles = false;
            this.dgvCambiosTareas.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCambiosTareas.Location = new System.Drawing.Point(28, 173);
            this.dgvCambiosTareas.Name = "dgvCambiosTareas";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(90)))), ((int)(((byte)(143)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCambiosTareas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCambiosTareas.Size = new System.Drawing.Size(955, 198);
            this.dgvCambiosTareas.TabIndex = 131;
            this.dgvCambiosTareas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCambiosTareas_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(477, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Proyectos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(484, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tareas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(389, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cambios en Tareas y Proyectos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "Auditoria";
            // 
            // frmAuditoriaCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1009, 658);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Poppins Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAuditoriaCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAuditoriaCambios";
            this.Load += new System.EventHandler(this.frmAuditoriaCambios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambiosProyectos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambiosTareas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Modelo.BotonPersonalizado botonPersonalizado1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvCambiosProyectos;
        private System.Windows.Forms.DataGridView dgvCambiosTareas;
    }
}