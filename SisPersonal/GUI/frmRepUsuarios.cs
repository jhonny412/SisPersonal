using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmRepUsuarios : Form
    {
        public frmRepUsuarios()
        {
            InitializeComponent();
        }

        private void frmRepUsuarios_Load(object sender, EventArgs e)
        {
            
        }

        private void frmRepUsuarios_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsGeneral.vUsuarios' Puede moverla o quitarla según sea necesario.
            this.vUsuariosTableAdapter.Fill(this.dsGeneral.vUsuarios);
            // TODO: esta línea de código carga datos en la tabla 'dsPersonal.vUsuarios' Puede moverla o quitarla según sea necesario.
            this.reportViewer3.RefreshReport();
        }
    }
}
