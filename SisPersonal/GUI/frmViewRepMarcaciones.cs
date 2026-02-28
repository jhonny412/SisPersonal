using System;
using System.Windows.Forms;
using Serilog;
namespace GUI
{
    public partial class frmViewRepMarcaciones : Form
    {
        public DateTime? desde = DateTime.Now.AddDays(-30);
        public DateTime? hasta = DateTime.Now;

        //Declaranado variables para los parametros de fecha
        private readonly object objBLMarcacion;

        public frmViewRepMarcaciones()
        {
            InitializeComponent();
        }

        private void frmViewRepMarcaciones_Load(object sender, System.EventArgs e)
        {
            UIStyles.ApplyModernStylesToForm(this);
            try
            {
                this.spMarcacionesTableAdapter.Fill(this.dsGeneral.spMarcaciones, desde, hasta);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al cargar el reporte de marcaciones. Rango: {Desde} - {Hasta}", desde, hasta);
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void spMarcacionXFechaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dsGeneralBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
