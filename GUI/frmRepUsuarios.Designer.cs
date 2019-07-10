namespace GUI
{
    partial class frmRepUsuarios
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
            this.vUsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsGeneral = new GUI.dsGeneral();
            this.vUsuariosTableAdapter = new GUI.dsGeneralTableAdapters.vUsuariosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vUsuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // vUsuariosBindingSource
            // 
            this.vUsuariosBindingSource.DataMember = "vUsuarios";
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsUsuarios";
            reportDataSource1.Value = this.vUsuariosBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "GUI.repUsuarios.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(710, 436);
            this.reportViewer3.TabIndex = 0;
            // 
            // dsGeneral
            // 
            this.dsGeneral.DataSetName = "dsGeneral";
            this.dsGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vUsuariosTableAdapter
            // 
            this.vUsuariosTableAdapter.ClearBeforeFill = true;
            // 
            // frmRepUsuarios
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 436);
            this.Controls.Add(this.reportViewer3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRepUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::Reporte General de Usuarios::.";
            this.Load += new System.EventHandler(this.frmRepUsuarios_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.vUsuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource UsuariosBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource vUsuariosBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private dsGeneral dsGeneral;
        private dsGeneralTableAdapters.vUsuariosTableAdapter vUsuariosTableAdapter;
    }
}