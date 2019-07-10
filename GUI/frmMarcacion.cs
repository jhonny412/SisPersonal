using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CE;
using BL;

namespace GUI
{
    public partial class frmMarcacion : Form
    {
        public frmMarcacion()
        {
            InitializeComponent();
        }
        E_Empleado objEEmp = new E_Empleado();
        BL_Empleado objBLEmp = new BL_Empleado();
        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            objEEmp.dni = txtDni.Text;
            var totolRegistro= objBLEmp.buscarPersona(objEEmp);
            if (txtDni.TextLength < 8)
            {
                lblNombres.Text = string.Empty;
            }
            if (totolRegistro.Rows.Count>0)
            {
                lblNombres.Text = totolRegistro.Rows[0]["Nombres y Apellidos"].ToString();
                //MessageBox.Show("Por favor verifique sus datos antes de realizar la marcacion","Marcacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //txtDni.Enabled = false;
            }
        }

        private void frmMarcacion_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("T");
        }

        private void rbtIngreso_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
