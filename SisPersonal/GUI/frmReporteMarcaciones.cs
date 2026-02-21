//using System.IO;
using BL;
using CAD;
using CE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmReporteMarcaciones : Form
    {
        BL_Marcacion objBLMarcacion = new BL_Marcacion();
        E_Marcaciones objEMarcacion = new E_Marcaciones();
        Int16 esGenerico = 0;

        string id;
        DateTime desde;
        DateTime hasta;
        public frmReporteMarcaciones()
        {
            InitializeComponent();
        }

        private void frmReporteMarcaciones_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
            ListarMarcacion();
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            //Llena el combo con empleados
            LlenarComboEmpleados();
        }

        private void ApplyModernStyles()
        {
            UIStyles.ApplyModernStylesToForm(this);
        }

        private void LlenarComboEmpleados()
        {
            // Agregar el elemento "Seleccione" al inicio de la lista
            DataTable dtEmpleados = objBLMarcacion.ListarEmpleados();
            // Agregar una nueva fila al principio
            DataRow dr = dtEmpleados.NewRow();
            dr["ID_Empleado"] = 0;
            dr["Nombres"] = "";
            dtEmpleados.Rows.InsertAt(dr, 0);

            cboTrabajador.DataSource = dtEmpleados;
            cboTrabajador.ValueMember = "ID_Empleado";
            cboTrabajador.DisplayMember = "Nombres";
        }

        void ListarMarcacion()
        {
            var registro = objBLMarcacion.ListarMarcaciones();
            if (registro.Rows.Count == 0)
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS DE MARCACIONES", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvMarcacion.DataSource = objBLMarcacion.ListarMarcaciones();
            PlantillaGrilla();
        }

        private void PlantillaGrilla()
        {
            //Asignando colores intercalados a las filas
            dgvMarcacion.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
            //Personalizando titulos de encabezado
            if (esGenerico == 0)
            {
                dgvMarcacion.Columns[0].HeaderCell.Value = "A. PATERNO";
                dgvMarcacion.Columns[1].HeaderCell.Value = "A. MATERNO";
                dgvMarcacion.Columns[2].HeaderCell.Value = "NOMBRES";
                dgvMarcacion.Columns[3].HeaderCell.Value = "FECHA";
                dgvMarcacion.Columns[4].HeaderCell.Value = "H. INGRESO";
                dgvMarcacion.Columns[5].HeaderCell.Value = "S. REFRIGERIO";
                dgvMarcacion.Columns[6].HeaderCell.Value = "R. REFRIGERIO";
                dgvMarcacion.Columns[7].HeaderCell.Value = "SALIDA";
                dgvMarcacion.Columns[8].HeaderCell.Value = "T. REFRIGERIO";
                dgvMarcacion.Columns[9].HeaderCell.Value = "H. TRABAJADAS";
                dgvMarcacion.Columns[10].HeaderCell.Value = "OBSERVACIONES";
            }
            else
            {
                dgvMarcacion.Refresh();
                dgvMarcacion.Columns[0].HeaderCell.Value = "NOMBRES";
                dgvMarcacion.Columns[1].HeaderCell.Value = "FECHA";
                dgvMarcacion.Columns[2].HeaderCell.Value = "H. INGRESO";
                dgvMarcacion.Columns[3].HeaderCell.Value = "S. REFRIGERIO";
                dgvMarcacion.Columns[4].HeaderCell.Value = "R. REFRIGERIO";
                dgvMarcacion.Columns[5].HeaderCell.Value = "SALIDA";
                dgvMarcacion.Columns[6].HeaderCell.Value = "T. REFRIGERIO";
                dgvMarcacion.Columns[7].HeaderCell.Value = "H. TRABAJADAS";
                dgvMarcacion.Columns[8].HeaderCell.Value = "OBSERVACIONES";
                esGenerico = 0;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            frmViewRepMarcaciones frm = new frmViewRepMarcaciones();
            //frm.ID = id;
            frm.desde = dtpDesde.Value;
            frm.hasta = dtpHasta.Value;
            frm.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            ListarMarcacion();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            esGenerico = 1;
            if (chkTodos.Checked)
            {
                    id = "";
            }
            else
            {
                if (cboTrabajador.SelectedIndex == -1)
                {
                    MessageBox.Show("DEBE SELECCIONAR UN TRABAJADOR PARA LISTAR SUS MARCACIONES", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    id = cboTrabajador.SelectedValue.ToString().Trim();
                }
            }

            desde = dtpDesde.Value;
            hasta = dtpHasta.Value;
            var resultado = objBLMarcacion.MarcacionXFecha(id, desde, hasta);

            if (resultado.Rows.Count == 0)
            {
                MessageBox.Show("NO SE ENCONTRARON RESULTADOS EN LA BUSQUEDA", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvMarcacion.DataSource = null;
                return;
            }
            PlantillaGrilla();
            dgvMarcacion.DataSource = resultado;
            
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                id = "";
                cboTrabajador.Text = "Seleccione";
                cboTrabajador.Enabled = false;
            }
            else
            {
                LlenarComboEmpleados();
                cboTrabajador.Enabled = true;
            }
        }

        private void cboTrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}