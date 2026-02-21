using BL;
using CE;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmGestionUsuario : Form
    {
        BL_Usuario objBLUsua = new BL_Usuario();
        E_Usuario objCEUsua = new E_Usuario();
        public frmGestionUsuario()
        {
            InitializeComponent();
        }

        private void frmGestionUsuario_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
            llenarUsuarios();
            ctrlCRUD(true, false);
            habilitarTexto(true, false);
        }

        private void ApplyModernStyles()
        {
            UIStyles.ApplyModernStylesToForm(this);
        }

        private void habilitarTexto(Boolean ARG1, Boolean ARG2)
        {
            txtUsuario.ReadOnly = ARG1;
            txtClave.ReadOnly = ARG1;
            cboEstado.Enabled = ARG2;
            cboPerfil.Enabled = ARG2;
        }

        public void llenarUsuarios()
        {
            dgvUsuarios.DataSource = objBLUsua.listarUsuarios();
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Silver;
            dgvUsuarios.Columns[0].HeaderText = "ID";
            dgvUsuarios.Columns[1].HeaderText = "Usuario";
            dgvUsuarios.Columns[2].HeaderText = "Contraseña";
            dgvUsuarios.Columns[3].HeaderText = "Estado";
            dgvUsuarios.Columns[4].HeaderText = "Perfil";
        }

        public void llenarTodosUsuarios()
        {
            dgvUsuarios.DataSource = objBLUsua.listarTodosUsuarios();
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Silver;
            dgvUsuarios.Columns[0].HeaderText = "ID";
            dgvUsuarios.Columns[1].HeaderText = "Usuario";
            dgvUsuarios.Columns[2].HeaderText = "Contraseña";
            dgvUsuarios.Columns[3].HeaderText = "Estado";
            dgvUsuarios.Columns[4].HeaderText = "Perfil";
        }
        private void dgvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtUsuario.Text = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtClave.Text = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
            string estado = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
            if (estado == "True")
            {
                cboEstado.Text = "Activo";
            }
            else
            {
                cboEstado.Text = "Inactivo";
            }
            //cboEstado.Text = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
            cboPerfil.Text = dgvUsuarios.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            cboEstado.Text = string.Empty;
            cboPerfil.Text = string.Empty;
            txtUsuario.Focus();
            txtCodigo.Text = objBLUsua.generarCodigo().ToString();
            btnGrabar.Tag = "Insertar";
            ctrlCRUD(false, true);
            habilitarTexto(false, true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(btnGrabar.Tag) == "Insertar")
            {
                objCEUsua.IdUsuario = Convert.ToInt32(txtCodigo.Text);
                objCEUsua.Usuario = txtUsuario.Text;
                objCEUsua.Clave = txtClave.Text;
                if (cboEstado.SelectedIndex == 0)
                {
                    objCEUsua.Estado = 1;
                }
                else
                {
                    objCEUsua.Estado = 0;
                }
                //Validando Perfil
                if (cboPerfil.SelectedIndex == 0)
                {
                    objCEUsua.Perfil = "Administrador";
                }
                else
                {
                    objCEUsua.Perfil = "Empleado";
                }

                objBLUsua.nuevoRegistro(objCEUsua, "INSERTAR");
                MessageBox.Show("Registro grabado...", "Gestion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llenarUsuarios();
                chkTodos.Checked = false;
                habilitarTexto(true, false);
            }
            else
            {
                objCEUsua.IdUsuario = Convert.ToInt32(txtCodigo.Text);
                objCEUsua.Usuario = txtUsuario.Text;
                objCEUsua.Clave = txtClave.Text;
                if (cboEstado.SelectedIndex == 0)
                {
                    objCEUsua.Estado = 1;
                }
                else
                {
                    objCEUsua.Estado = 0;
                }
                //Validando Perfil
                if (cboPerfil.SelectedIndex == 0)
                {
                    objCEUsua.Perfil = "Administrador";
                }
                else
                {
                    objCEUsua.Perfil = "Empleado";
                }

                objBLUsua.nuevoRegistro(objCEUsua, "ACTUALIZAR");
                MessageBox.Show("Registro actualizado correctamente...", "Gestion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llenarUsuarios();
                chkTodos.Checked = false;
                habilitarTexto(true, false);
            }
            btnGrabar.Tag = "Insertar";
            ctrlCRUD(true, false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGrabar.Tag = "Actualizar";
            ctrlCRUD(false, true);
            habilitarTexto(false, true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objCEUsua.IdUsuario = Convert.ToInt32(txtCodigo.Text);
            objCEUsua.Usuario = txtUsuario.Text;
            objCEUsua.Clave = txtClave.Text;
            if (cboEstado.SelectedIndex == 0)
            {
                objCEUsua.Estado = 1;
            }
            else
            {
                objCEUsua.Estado = 0;
            }
            //Validando Perfil
            if (cboPerfil.SelectedIndex == 0)
            {
                objCEUsua.Perfil = "Administrador";
            }
            else
            {
                objCEUsua.Perfil = "Empleado";
            }
            if (MessageBox.Show("Esta seguro que desea eliminar el Usuario?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objBLUsua.eliminarRegistro(objCEUsua, "ELIMINAR");
                MessageBox.Show("Registro eliminado correctamente...", "Gestion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llenarUsuarios();
            }
            else
            {
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                llenarTodosUsuarios();
            }
            else
            {
                llenarUsuarios();
            }
        }
        public void ctrlCRUD(Boolean ARG1, Boolean ARG2)
        {
            btnNuevo.Enabled = ARG1;
            btnEditar.Enabled = ARG1;
            btnGrabar.Enabled = ARG2;
            btnEliminar.Enabled = ARG1;
            btnCancelar.Enabled = ARG2;
            btnBuscar.Enabled = ARG1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlCRUD(true, false);
            llenarUsuarios();
            habilitarTexto(true, false);
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("ESTA SEGURO QUE DESEA SALIR DEL FORMULARIO?", "CUIDADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
