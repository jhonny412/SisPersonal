using System;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.IO;
using BL;
using CE;

namespace GUI
{
    public partial class frmReporteMarcaciones : Form
    {
        BL_Marcacion objBLMarcacion = new BL_Marcacion();
        E_Marcaciones objEMarcacion = new E_Marcaciones();
        public frmReporteMarcaciones()
        {
            InitializeComponent();
        }

        private void frmReporteMarcaciones_Load(object sender, EventArgs e)
        {
            ListarMarcacion();
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
        }
        void ListarMarcacion()
        {
            dgvMarcacion.DataSource = objBLMarcacion.ListarMarcaciones();
            //Asignando colores intercalados a las filas
            dgvMarcacion.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
            //Personalizando titulos de encabezado
            dgvMarcacion.Columns[0].HeaderCell.Value = "A. Paterno";
            dgvMarcacion.Columns[1].HeaderCell.Value = "A. Materno";
            dgvMarcacion.Columns[2].HeaderCell.Value = "Nombres";
            dgvMarcacion.Columns[3].HeaderCell.Value = "Fecha";
            dgvMarcacion.Columns[4].HeaderCell.Value = "H. Ingreso";
            dgvMarcacion.Columns[5].HeaderCell.Value = "S. Refrigerio";
            dgvMarcacion.Columns[6].HeaderCell.Value = "R. Refrigerio";
            dgvMarcacion.Columns[7].HeaderCell.Value = "Salida";
            dgvMarcacion.Columns[8].HeaderCell.Value = "T. Regrigerio";
            dgvMarcacion.Columns[9].HeaderCell.Value = "H. Trabajadas";
            dgvMarcacion.Columns[10].HeaderCell.Value = "Observacion";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            frmRepMarcacion frm = new frmRepMarcacion();
            frm.fecha1 = dtpDesde.Value;
            frm.fecha2 = dtpHasta.Value;

            frm.ShowDialog();
            //if (dtpDesde.Value > dtpHasta.Value)
            //{
            //    MessageBox.Show("La fecha DESDE no puede ser mayor a la fecha HASTA", "Reporte de marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else if (dtpDesde.Value.Date > DateTime.Today || dtpHasta.Value.Date > DateTime.Today)
            //{
            //    MessageBox.Show("La fecha tiene que ser menor a la FECHA ACTUAL", "Reporte de marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    frmRepMarcacion frm = new frmRepMarcacion();
            //    frm.fecha1 = dtpDesde.Value;
            //    frm.fecha2 = dtpHasta.Value;

            //    frm.ShowDialog();
            //}
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            ListarMarcacion();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}