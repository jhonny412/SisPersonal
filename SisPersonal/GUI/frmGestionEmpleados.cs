using BL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmGestionEmpleados : Form
    {
        BL_Empleado objEmp = new BL_Empleado();
        public frmGestionEmpleados()
        {
            InitializeComponent();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imagen (*.jpg)|*.jpg|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string imagen = ofd.FileName;

                    pbxFoto.Image = Image.FromFile(imagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void frmGestionEmpleados_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
            groupBox1.Enabled = false;
            dgvEmpleados.DataSource = objEmp.GetEmpleado();
            this.Width = 848;
            this.Height = 710;
        }

        private void ApplyModernStyles()
        {
            UIStyles.ApplyModernStylesToForm(this);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
