using BL;
using CE;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace GUI
{
    public partial class frmGestionEmpleados : Form
    {
        BL_Empleado objEmp = new BL_Empleado();
        E_Empleado objEEmp = new E_Empleado();
        string mode = "Insert";

        public frmGestionEmpleados()
        {
            InitializeComponent();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imagen (*.jpg, *.png)|*.jpg;*.png|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbxFoto.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }
        }

        private void frmGestionEmpleados_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
            listar();
            habilitarCampos(false);
            
            // Establecer dimensiones fijas
            this.Size = new Size(1037, 630);
            this.MinimumSize = new Size(1037, 630);
            this.MaximumSize = new Size(1037, 630);
        }

        private void ApplyModernStyles()
        {
            UIStyles.ApplyModernStylesToForm(this);
        }

        private void listar()
        {
            dgvEmpleados.DataSource = objEmp.GetEmpleado();
            if (dgvEmpleados.Columns.Contains("Foto"))
            {
                dgvEmpleados.Columns["Foto"].Visible = false;
            }
        }

        private void habilitarCampos(bool v)
        {
            groupBox1.Enabled = v;
            btnGrabar.Enabled = v;
        }

        private void limpiarCampos()
        {
            txtId.Clear();
            txtNombres.Clear();
            txtApepat.Clear();
            txtApemat.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            txtBasico.Clear();
            txtHE.Clear();
            chkActivo.Checked = true;
            chkInactivo.Checked = false;
            pbxFoto.Image = null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            mode = "Insert";
            limpiarCampos();
            habilitarCampos(true);
            txtNombres.Focus();
            // Generar un ID temporal para ejemplo o dejar que el SP lo maneje si es necesario
            txtId.Text = "E" + DateTime.Now.ToString("mmssfff"); 
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtDNI.Text))
                {
                    MessageBox.Show("Nombres y DNI son obligatorios.");
                    return;
                }

                objEEmp.ID_Empleado = txtId.Text;
                objEEmp.Nombres = txtNombres.Text;
                objEEmp.Ape_Paterno = txtApepat.Text;
                objEEmp.Ape_Materno = txtApemat.Text;
                objEEmp.DNI = txtDNI.Text;
                objEEmp.Direccion = txtDireccion.Text;
                objEEmp.Estado = chkActivo.Checked;
                objEEmp.SBasicoHora = string.IsNullOrEmpty(txtBasico.Text) ? 0 : Convert.ToDecimal(txtBasico.Text);
                objEEmp.SHorasExtraHora = string.IsNullOrEmpty(txtHE.Text) ? 0 : Convert.ToDecimal(txtHE.Text);

                // Convertir imagen a byte[]
                if (pbxFoto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pbxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        objEEmp.Foto = ms.ToArray();
                    }
                }
                else
                {
                    objEEmp.Foto = null;
                }

                int res = 0;
                if (mode == "Insert")
                {
                    res = objEmp.nuevoRegistro(objEEmp);
                    if (res > 0) MessageBox.Show("Empleado registrado correctamente.");
                }
                else
                {
                    res = objEmp.actualizarRegistro(objEEmp);
                    if (res > 0) MessageBox.Show("Empleado actualizado correctamente.");
                }

                if (res > 0)
                {
                    listar();
                    limpiarCampos();
                    habilitarCampos(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al grabar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                mode = "Update";
                habilitarCampos(true);
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                string id = dgvEmpleados.CurrentRow.Cells["Id_Empleado"].Value.ToString();
                if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (objEmp.eliminarRegistro(id) > 0)
                    {
                        MessageBox.Show("Registro eliminado.");
                        listar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            habilitarCampos(false);
            mode = "Insert";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Búsqueda
            objEEmp.Nombres = textBox1.Text;
            dgvEmpleados.DataSource = objEmp.buscarPersona(objEEmp);
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                txtId.Text = dgvEmpleados.CurrentRow.Cells["Id_Empleado"].Value.ToString();
                txtNombres.Text = dgvEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                txtApepat.Text = dgvEmpleados.CurrentRow.Cells["Ape_Paterno"].Value.ToString();
                txtApemat.Text = dgvEmpleados.CurrentRow.Cells["Ape_Materno"].Value.ToString();
                txtDNI.Text = dgvEmpleados.CurrentRow.Cells["DNI"].Value.ToString();
                txtDireccion.Text = dgvEmpleados.CurrentRow.Cells["Direccion"].Value.ToString();
                txtBasico.Text = dgvEmpleados.CurrentRow.Cells["SBasicoHora"].Value.ToString();
                txtHE.Text = dgvEmpleados.CurrentRow.Cells["SHorasExtraHora"].Value.ToString();
                
                bool estado = Convert.ToBoolean(dgvEmpleados.CurrentRow.Cells["Estado"].Value);
                chkActivo.Checked = estado;
                chkInactivo.Checked = !estado;

                // Cargar Foto
                if (dgvEmpleados.CurrentRow.Cells["Foto"].Value != DBNull.Value)
                {
                    byte[] img = (byte[])dgvEmpleados.CurrentRow.Cells["Foto"].Value;
                    using (MemoryStream ms = new MemoryStream(img))
                    {
                        pbxFoto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbxFoto.Image = null;
                }
            }
        }
    }
}
