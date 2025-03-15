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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaFinalizacion = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.botonPersonalizado1 = new AppOneCode.Modelo.BotonPersonalizado();
            this.botonPersonalizado2 = new AppOneCode.Modelo.BotonPersonalizado();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbProyectos = new System.Windows.Forms.ComboBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.botonPersonalizado3 = new AppOneCode.Modelo.BotonPersonalizado();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarProyectosI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActualizarTarea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminarProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregarProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(831, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tareas";
            // 
            // dgvMostrarProyectosI
            // 
            this.dgvMostrarProyectosI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMostrarProyectosI.BackgroundColor = System.Drawing.Color.White;
            this.dgvMostrarProyectosI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMostrarProyectosI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMostrarProyectosI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrarProyectosI.EnableHeadersVisualStyles = false;
            this.dgvMostrarProyectosI.GridColor = System.Drawing.SystemColors.Control;
            this.dgvMostrarProyectosI.Location = new System.Drawing.Point(81, 518);
            this.dgvMostrarProyectosI.Name = "dgvMostrarProyectosI";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(90)))), ((int)(((byte)(143)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMostrarProyectosI.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMostrarProyectosI.Size = new System.Drawing.Size(587, 252);
            this.dgvMostrarProyectosI.TabIndex = 130;
            // 
            // txtSearchProyect
            // 
            this.txtSearchProyect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProyect.Location = new System.Drawing.Point(768, 529);
            this.txtSearchProyect.Name = "txtSearchProyect";
            this.txtSearchProyect.Size = new System.Drawing.Size(204, 20);
            this.txtSearchProyect.TabIndex = 129;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(843, 490);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 128;
            this.label7.Text = "Buscar";
            // 
            // txtDescP
            // 
            this.txtDescP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescP.Location = new System.Drawing.Point(339, 55);
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
            this.label6.Location = new System.Drawing.Point(207, 59);
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
            this.label5.Location = new System.Drawing.Point(136, 104);
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
            this.label4.Location = new System.Drawing.Point(225, 157);
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
            this.cmbEmpleadoAsignado.Location = new System.Drawing.Point(339, 102);
            this.cmbEmpleadoAsignado.Name = "cmbEmpleadoAsignado";
            this.cmbEmpleadoAsignado.Size = new System.Drawing.Size(364, 21);
            this.cmbEmpleadoAsignado.TabIndex = 132;
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Location = new System.Drawing.Point(339, 156);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(364, 21);
            this.cmbPrioridad.TabIndex = 133;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(339, 210);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(364, 21);
            this.cmbEstado.TabIndex = 135;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(225, 211);
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
            this.pictureBox1.Location = new System.Drawing.Point(768, 156);
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
            this.pbActualizarTarea.Location = new System.Drawing.Point(638, 430);
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
            this.pbEliminarProyecto.Location = new System.Drawing.Point(476, 430);
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
            this.pbAgregarProyecto.Location = new System.Drawing.Point(328, 430);
            this.pbAgregarProyecto.Name = "pbAgregarProyecto";
            this.pbAgregarProyecto.Size = new System.Drawing.Size(62, 52);
            this.pbAgregarProyecto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAgregarProyecto.TabIndex = 117;
            this.pbAgregarProyecto.TabStop = false;
            this.pbAgregarProyecto.Click += new System.EventHandler(this.pbAgregarProyecto_Click);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(339, 257);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(364, 20);
            this.dtpFechaInicio.TabIndex = 139;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.White;
            this.lbl.Location = new System.Drawing.Point(173, 257);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(137, 20);
            this.lbl.TabIndex = 140;
            this.lbl.Text = "Fecha de Inicio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(121, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 20);
            this.label8.TabIndex = 142;
            this.label8.Text = "Fecha de Finalizacion:";
            // 
            // dtpFechaFinalizacion
            // 
            this.dtpFechaFinalizacion.Location = new System.Drawing.Point(339, 307);
            this.dtpFechaFinalizacion.Name = "dtpFechaFinalizacion";
            this.dtpFechaFinalizacion.Size = new System.Drawing.Size(364, 20);
            this.dtpFechaFinalizacion.TabIndex = 141;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(797, 605);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 143;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(797, 678);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 144;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(834, 571);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 145;
            this.label9.Text = "Buscar de el:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(856, 645);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 20);
            this.label10.TabIndex = 146;
            this.label10.Text = " Hasta";
            // 
            // botonPersonalizado1
            // 
            this.botonPersonalizado1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.botonPersonalizado1.FlatAppearance.BorderSize = 0;
            this.botonPersonalizado1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonPersonalizado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPersonalizado1.ForeColor = System.Drawing.Color.White;
            this.botonPersonalizado1.Location = new System.Drawing.Point(839, 714);
            this.botonPersonalizado1.Name = "botonPersonalizado1";
            this.botonPersonalizado1.Size = new System.Drawing.Size(98, 33);
            this.botonPersonalizado1.TabIndex = 149;
            this.botonPersonalizado1.Text = "Buscar";
            this.botonPersonalizado1.UseVisualStyleBackColor = false;
            this.botonPersonalizado1.Click += new System.EventHandler(this.botonPersonalizado1_Click_1);
            // 
            // botonPersonalizado2
            // 
            this.botonPersonalizado2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.botonPersonalizado2.FlatAppearance.BorderSize = 0;
            this.botonPersonalizado2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonPersonalizado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPersonalizado2.ForeColor = System.Drawing.Color.White;
            this.botonPersonalizado2.Location = new System.Drawing.Point(978, 518);
            this.botonPersonalizado2.Name = "botonPersonalizado2";
            this.botonPersonalizado2.Size = new System.Drawing.Size(68, 40);
            this.botonPersonalizado2.TabIndex = 150;
            this.botonPersonalizado2.Text = "Buscar";
            this.botonPersonalizado2.UseVisualStyleBackColor = false;
            this.botonPersonalizado2.Click += new System.EventHandler(this.botonPersonalizado2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(146, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 20);
            this.label11.TabIndex = 151;
            this.label11.Text = "Proyecto Asignado:";
            // 
            // cmbProyectos
            // 
            this.cmbProyectos.FormattingEnabled = true;
            this.cmbProyectos.Location = new System.Drawing.Point(339, 353);
            this.cmbProyectos.Name = "cmbProyectos";
            this.cmbProyectos.Size = new System.Drawing.Size(364, 21);
            this.cmbProyectos.TabIndex = 152;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(-4, 490);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(758, 299);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 170;
            this.pictureBox12.TabStop = false;
            // 
            // botonPersonalizado3
            // 
            this.botonPersonalizado3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.botonPersonalizado3.FlatAppearance.BorderSize = 0;
            this.botonPersonalizado3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonPersonalizado3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPersonalizado3.ForeColor = System.Drawing.Color.White;
            this.botonPersonalizado3.Location = new System.Drawing.Point(25, 430);
            this.botonPersonalizado3.Name = "botonPersonalizado3";
            this.botonPersonalizado3.Size = new System.Drawing.Size(150, 40);
            this.botonPersonalizado3.TabIndex = 171;
            this.botonPersonalizado3.Text = "Tareas repetitivas";
            this.botonPersonalizado3.UseVisualStyleBackColor = false;
            // 
            // FrmAgregarTareas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1058, 797);
            this.Controls.Add(this.botonPersonalizado3);
            this.Controls.Add(this.cmbProyectos);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.botonPersonalizado2);
            this.Controls.Add(this.botonPersonalizado1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpFechaFinalizacion);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dtpFechaInicio);
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
            this.Controls.Add(this.pictureBox12);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaFinalizacion;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Modelo.BotonPersonalizado botonPersonalizado1;
        private Modelo.BotonPersonalizado botonPersonalizado2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbProyectos;
        private System.Windows.Forms.PictureBox pictureBox12;
        private Modelo.BotonPersonalizado botonPersonalizado3;
    }
}