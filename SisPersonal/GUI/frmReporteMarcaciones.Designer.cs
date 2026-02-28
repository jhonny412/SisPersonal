namespace GUI
{
    partial class frmReporteMarcaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteMarcaciones));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTrabajador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkExtras = new System.Windows.Forms.CheckBox();
            this.chkFaltas = new System.Windows.Forms.CheckBox();
            this.chkTardanzas = new System.Windows.Forms.CheckBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvMarcacion = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(410, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "REPORTE GENERAL DE MARCACIONES";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(1135, 420);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(98, 59);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(11, 420);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(94, 59);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "Exportar Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTrabajador);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 74);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Por Trabajador";
            // 
            // cboTrabajador
            // 
            this.cboTrabajador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cboTrabajador.FormattingEnabled = true;
            this.cboTrabajador.Location = new System.Drawing.Point(97, 27);
            this.cboTrabajador.Name = "cboTrabajador";
            this.cboTrabajador.Size = new System.Drawing.Size(208, 21);
            this.cboTrabajador.TabIndex = 16;
            this.cboTrabajador.SelectedIndexChanged += new System.EventHandler(this.cboTrabajador_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "SELECCIONE:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkExtras);
            this.groupBox2.Controls.Add(this.chkFaltas);
            this.groupBox2.Controls.Add(this.chkTardanzas);
            this.groupBox2.Controls.Add(this.chkTodos);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.dtpHasta);
            this.groupBox2.Controls.Add(this.dtpDesde);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(337, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 74);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Por Fechas";
            // 
            // chkExtras
            // 
            this.chkExtras.AutoSize = true;
            this.chkExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.chkExtras.Location = new System.Drawing.Point(642, 37);
            this.chkExtras.Name = "chkExtras";
            this.chkExtras.Size = new System.Drawing.Size(161, 17);
            this.chkExtras.TabIndex = 18;
            this.chkExtras.Text = "RESALTAR H. EXTRAS";
            this.chkExtras.UseVisualStyleBackColor = true;
            // 
            // chkFaltas
            // 
            this.chkFaltas.AutoSize = true;
            this.chkFaltas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.chkFaltas.Location = new System.Drawing.Point(642, 14);
            this.chkFaltas.Name = "chkFaltas";
            this.chkFaltas.Size = new System.Drawing.Size(170, 17);
            this.chkFaltas.TabIndex = 17;
            this.chkFaltas.Text = "RESALTAR TARDANZAS";
            this.chkFaltas.UseVisualStyleBackColor = true;
            // 
            // chkTardanzas
            // 
            this.chkTardanzas.AutoSize = true;
            this.chkTardanzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.chkTardanzas.Location = new System.Drawing.Point(393, 37);
            this.chkTardanzas.Name = "chkTardanzas";
            this.chkTardanzas.Size = new System.Drawing.Size(170, 17);
            this.chkTardanzas.TabIndex = 16;
            this.chkTardanzas.Text = "RESALTAR TARDANZAS";
            this.chkTardanzas.UseVisualStyleBackColor = true;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.chkTodos.Location = new System.Drawing.Point(393, 14);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(224, 17);
            this.chkTodos.TabIndex = 15;
            this.chkTodos.Text = "LISTAR TODOS LOS EMPLEADOS";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(849, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(43, 43);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.AllowDrop = true;
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(246, 27);
            this.dtpHasta.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(127, 20);
            this.dtpHasta.TabIndex = 1;
            this.dtpHasta.Value = new System.DateTime(2017, 8, 29, 0, 0, 0, 0);
            // 
            // dtpDesde
            // 
            this.dtpDesde.AllowDrop = true;
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(60, 27);
            this.dtpDesde.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(122, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.Value = new System.DateTime(2017, 11, 15, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label4.Location = new System.Drawing.Point(192, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "HASTA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "DESDE:";
            // 
            // Error
            // 
            this.Error.ContainerControl = this;
            this.Error.RightToLeft = true;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefrescar.BackColor = System.Drawing.Color.White;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefrescar.Location = new System.Drawing.Point(113, 420);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(94, 59);
            this.btnRefrescar.TabIndex = 14;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dgvMarcacion
            // 
            this.dgvMarcacion.AllowUserToAddRows = false;
            this.dgvMarcacion.AllowUserToDeleteRows = false;
            this.dgvMarcacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMarcacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMarcacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMarcacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvMarcacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcacion.GridColor = System.Drawing.Color.White;
            this.dgvMarcacion.Location = new System.Drawing.Point(12, 147);
            this.dgvMarcacion.Name = "dgvMarcacion";
            this.dgvMarcacion.ReadOnly = true;
            this.dgvMarcacion.RowHeadersWidth = 43;
            this.dgvMarcacion.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvMarcacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMarcacion.Size = new System.Drawing.Size(1223, 267);
            this.dgvMarcacion.TabIndex = 15;
            // 
            // frmReporteMarcaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1245, 490);
            this.Controls.Add(this.dgvMarcacion);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExcel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteMarcaciones";
            this.Text = "Reporte de Marcaciónes";
            this.Load += new System.EventHandler(this.frmReporteMarcaciones_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ErrorProvider Error;
        public System.Windows.Forms.DateTimePicker dtpHasta;
        protected System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvMarcacion;
        private System.Windows.Forms.ComboBox cboTrabajador;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.CheckBox chkTardanzas;
        private System.Windows.Forms.CheckBox chkExtras;
        private System.Windows.Forms.CheckBox chkFaltas;
    }
}