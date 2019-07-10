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
    public partial class frmLogin : Form
    {
        E_Usuario objEUsuario = new E_Usuario();
        BL_Usuario objBLUsuario = new BL_Usuario();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome", "http://www.bluecaritas.hol.es");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || (string.IsNullOrEmpty(txtClave.Text)) && txtUsuario.MaxLength<=5 && txtClave.MaxLength<=5)
            {
                error.SetError(txtUsuario, "Ingrese usuario para su identificacion");
                error.SetError(txtClave, "Ingrese Clave de acceso para su identificacion");
                txtUsuario.Focus();
            }
            else
            {
                error.SetError(txtUsuario, "");
                error.SetError(txtClave, "");
                objEUsuario.Usuario = txtUsuario.Text;
                objEUsuario.Clave = txtClave.Text;
                //Ejecutando el proceso
                var est = objBLUsuario.Login(objEUsuario);
                if (est.Rows.Count > 0)
                {
                    var perfil = est.Rows[0]["Perfil"].ToString();
                    //MessageBox.Show("Bienvenido " + txtUsuario.Text, "Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (perfil.Contains("Empleado"))
                    {
                        this.Hide();
                        frmMarcacion frm = new frmMarcacion();
                        MessageBox.Show("Indentificacion correcta", "Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm.Show();
                    }
                    else if (perfil.Contains("Administrador"))
                    {
                        MDIMenu frmMenu = new MDIMenu();
                        this.Hide();
                        MessageBox.Show("Indentificacion correcta", "Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMenu.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Los datos de identificacion son incorrectos... Verifique he intente de nuevo", "Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
