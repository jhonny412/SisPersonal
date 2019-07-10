using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmRepMarcacion : Form
    {
        public frmRepMarcacion()
        {
            InitializeComponent();
        }
        //Declaranado variables para los parametros de fecha
        public DateTime fecha1 { get; set; }
        public DateTime fecha2 { get; set; }

        private void frmRepMarcacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsGeneral.spMarcaciones' Puede moverla o quitarla según sea necesario.
            this.spMarcacionesTableAdapter.Fill(this.dsGeneral.spMarcaciones,fecha1,fecha2);
            this.reportViewer1.RefreshReport();
        }
    }
}