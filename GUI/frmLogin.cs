using BL;
using CE;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {

        public string _Usuario;
        public string _Clave;
        E_Usuario objEUsuario = new E_Usuario();
        BL_Usuario objBLUsuario = new BL_Usuario();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
        }

        private void ApplyModernStyles()
        {
            // Aplicar estilos modernos al formulario
            UIStyles.ApplyFormStyle(this);
            
            // Aplicar estilos a los controles de texto
            UIStyles.ApplyTextBoxStyle(txtUsuario);
            UIStyles.ApplyTextBoxStyle(txtClave);
            
            // Aplicar estilos a los botones
            UIStyles.ApplyPrimaryButtonStyle(btnIngresar);
            UIStyles.ApplySecondaryButtonStyle(btnCancelar);
            
            // Aplicar estilos a las etiquetas
            UIStyles.ApplyTitleLabelStyle(label1);
            UIStyles.ApplyLabelStyle(label3);
            UIStyles.ApplyLabelStyle(label4);
            UIStyles.ApplyLabelStyle(label2);
            
            // Aplicar estilos a los paneles
            UIStyles.ApplyPanelStyle(panelLogin);
            
            // Configurar efectos de hover para los TextBox
            txtUsuario.Enter += (s, e) => txtUsuario.BackColor = UIStyles.LightBlue;
            txtUsuario.Leave += (s, e) => txtUsuario.BackColor = UIStyles.White;
            
            txtClave.Enter += (s, e) => txtClave.BackColor = UIStyles.LightBlue;
            txtClave.Leave += (s, e) => txtClave.BackColor = UIStyles.White;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome", "http://www.bluecaritas.hol.es");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || (string.IsNullOrEmpty(txtClave.Text)) && txtUsuario.MaxLength <= 5 && txtClave.MaxLength <= 5)
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

                    if (perfil.Contains("Empleado"))
                    {
                        this.Hide();
                        frmMarcacion frm = new frmMarcacion();
                        MessageBox.Show("Indentificacion correcta", "Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm.Show();
                    }
                    else if (perfil.Contains("Administrador"))
                    {
                        _Usuario = txtUsuario.Text;
                        MDIMenu frmMenu = new MDIMenu();
                        MessageBox.Show("Indentificacion correcta", "Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
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
