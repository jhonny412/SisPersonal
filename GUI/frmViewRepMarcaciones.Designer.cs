namespace GUI
{
    partial class frmViewRepMarcaciones
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spMarcacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsGeneral = new GUI.dsGeneral();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spMarcacionesTableAdapter = new GUI.dsGeneralTableAdapters.spMarcacionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spMarcacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // spMarcacionesBindingSource
            // 
            this.spMarcacionesBindingSource.DataMember = "spMarcaciones";
            this.spMarcacionesBindingSource.DataSource = this.dsGeneral;
            // 
            // dsGeneral
            // 
            this.dsGeneral.DataSetName = "dsGeneral";
            this.dsGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsMarcacion";
            reportDataSource1.Value = this.spMarcacionesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.ReportMarcaciones.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1165, 719);
            this.reportViewer1.TabIndex = 0;
            // 
            // spMarcacionesTableAdapter
            // 
            this.spMarcacionesTableAdapter.ClearBeforeFill = true;
            // 
            // frmViewRepMarcaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1165, 719);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmViewRepMarcaciones";
            this.Text = "Reporte de Marcaciones";
            this.Load += new System.EventHandler(this.frmViewRepMarcaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spMarcacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource spMarcacionesBindingSource;
        private dsGeneral dsGeneral;
        private dsGeneralTableAdapters.spMarcacionesTableAdapter spMarcacionesTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}