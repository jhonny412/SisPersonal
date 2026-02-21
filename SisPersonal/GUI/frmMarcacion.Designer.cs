namespace GUI
{
    partial class frmMarcacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarcacion));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkRetornoRefrigerio = new System.Windows.Forms.CheckBox();
            this.chkSalidaRefrigerio = new System.Windows.Forms.CheckBox();
            this.chkSalida = new System.Windows.Forms.CheckBox();
            this.chkEntrada = new System.Windows.Forms.CheckBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblIdPersonal = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtObservacion = new System.Windows.Forms.RichTextBox();
            this.txtIdMarcacion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(49, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marcacion de Asistencias de Personal";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblNombres);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identificacion";
            // 
            // lblNombres
            // 
            this.lblNombres.BackColor = System.Drawing.Color.DarkRed;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.ForeColor = System.Drawing.Color.White;
            this.lblNombres.Location = new System.Drawing.Point(250, 32);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(479, 21);
            this.lblNombres.TabIndex = 2;
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(132, 32);
            this.txtDni.MaxLength = 8;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(118, 21);
            this.txtDni.TabIndex = 1;
            this.txtDni.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "INGRESE Nº DNI:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.Navy;
            this.lblHora.Location = new System.Drawing.Point(630, 56);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(111, 29);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "00:00:00";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.chkRetornoRefrigerio);
            this.groupBox2.Controls.Add(this.chkSalidaRefrigerio);
            this.groupBox2.Controls.Add(this.chkSalida);
            this.groupBox2.Controls.Add(this.chkEntrada);
            this.groupBox2.Controls.Add(this.btnGrabar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 77);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Marcacion";
            // 
            // chkRetornoRefrigerio
            // 
            this.chkRetornoRefrigerio.AutoSize = true;
            this.chkRetornoRefrigerio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetornoRefrigerio.Location = new System.Drawing.Point(356, 34);
            this.chkRetornoRefrigerio.Name = "chkRetornoRefrigerio";
            this.chkRetornoRefrigerio.Size = new System.Drawing.Size(167, 17);
            this.chkRetornoRefrigerio.TabIndex = 5;
            this.chkRetornoRefrigerio.Text = "RETORNO REFRIGERIO";
            this.chkRetornoRefrigerio.UseVisualStyleBackColor = true;
            this.chkRetornoRefrigerio.CheckedChanged += new System.EventHandler(this.chkRetornoRefrigerio_CheckedChanged);
            // 
            // chkSalidaRefrigerio
            // 
            this.chkSalidaRefrigerio.AutoSize = true;
            this.chkSalidaRefrigerio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSalidaRefrigerio.Location = new System.Drawing.Point(157, 34);
            this.chkSalidaRefrigerio.Name = "chkSalidaRefrigerio";
            this.chkSalidaRefrigerio.Size = new System.Drawing.Size(150, 17);
            this.chkSalidaRefrigerio.TabIndex = 5;
            this.chkSalidaRefrigerio.Text = "SALIDA REFRIGERIO";
            this.chkSalidaRefrigerio.UseVisualStyleBackColor = true;
            this.chkSalidaRefrigerio.CheckedChanged += new System.EventHandler(this.chkSalidaRefrigerio_CheckedChanged);
            // 
            // chkSalida
            // 
            this.chkSalida.AutoSize = true;
            this.chkSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSalida.Location = new System.Drawing.Point(561, 34);
            this.chkSalida.Name = "chkSalida";
            this.chkSalida.Size = new System.Drawing.Size(70, 17);
            this.chkSalida.TabIndex = 5;
            this.chkSalida.Text = "SALIDA";
            this.chkSalida.UseVisualStyleBackColor = true;
            this.chkSalida.CheckedChanged += new System.EventHandler(this.chkSalida_CheckedChanged);
            // 
            // chkEntrada
            // 
            this.chkEntrada.AutoSize = true;
            this.chkEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEntrada.Location = new System.Drawing.Point(19, 34);
            this.chkEntrada.Name = "chkEntrada";
            this.chkEntrada.Size = new System.Drawing.Size(85, 17);
            this.chkEntrada.TabIndex = 5;
            this.chkEntrada.Text = "ENTRADA";
            this.chkEntrada.UseVisualStyleBackColor = true;
            this.chkEntrada.CheckedChanged += new System.EventHandler(this.chkEntrada_CheckedChanged);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Transparent;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Location = new System.Drawing.Point(696, 18);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 47);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Navy;
            this.lblFecha.Location = new System.Drawing.Point(631, 22);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(79, 20);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "00:00:00";
            // 
            // lblIdPersonal
            // 
            this.lblIdPersonal.AutoSize = true;
            this.lblIdPersonal.Location = new System.Drawing.Point(13, 56);
            this.lblIdPersonal.Name = "lblIdPersonal";
            this.lblIdPersonal.Size = new System.Drawing.Size(35, 13);
            this.lblIdPersonal.TabIndex = 5;
            this.lblIdPersonal.Text = "label3";
            this.lblIdPersonal.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtObservacion);
            this.groupBox3.Location = new System.Drawing.Point(12, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(777, 69);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Observaciones";
            // 
            // txtObservacion
            // 
            this.txtObservacion.AutoWordSelection = true;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservacion.Location = new System.Drawing.Point(3, 16);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(771, 50);
            this.txtObservacion.TabIndex = 0;
            this.txtObservacion.Text = "";
            this.txtObservacion.TextChanged += new System.EventHandler(this.txtObservacion_TextChanged);
            // 
            // txtIdMarcacion
            // 
            this.txtIdMarcacion.Location = new System.Drawing.Point(332, 56);
            this.txtIdMarcacion.Name = "txtIdMarcacion";
            this.txtIdMarcacion.Size = new System.Drawing.Size(100, 20);
            this.txtIdMarcacion.TabIndex = 7;
            this.txtIdMarcacion.Visible = false;
            // 
            // frmMarcacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(801, 332);
            this.Controls.Add(this.txtIdMarcacion);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblIdPersonal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMarcacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcación de Asistencias";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMarcacion_FormClosed);
            this.Load += new System.EventHandler(this.frmMarcacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkRetornoRefrigerio;
        private System.Windows.Forms.CheckBox chkSalidaRefrigerio;
        private System.Windows.Forms.CheckBox chkSalida;
        private System.Windows.Forms.CheckBox chkEntrada;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblIdPersonal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtObservacion;
        private System.Windows.Forms.TextBox txtIdMarcacion;
    }
}