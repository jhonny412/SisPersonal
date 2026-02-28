using BL;
using CE;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using Serilog;

namespace GUI
{
    public partial class frmLogin : Form
    {

        public string _Usuario;
        public string _Clave;
        E_Usuario objEUsuario = new E_Usuario();
        BL_Usuario objBLUsuario = new BL_Usuario();
        private Point originalPanelLocation;
        private bool isPasswordHidden = true;

        public frmLogin()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            ApplyModernStyles();
            originalPanelLocation = pnlMain.Location;
            LoadRememberedUser();
            StartFadeIn();
        }

        private async void StartFadeIn()
        {
            while (this.Opacity < 1)
            {
                this.Opacity += 0.05;
                await Task.Delay(10);
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = txtUsuario;
        }

        private void ApplyModernStyles()
        {
            // Bordes redondeados simulados por diseño de paneles
            this.BackColor = UIStyles.LoginGradientStart;
            pnlMain.BackColor = Color.White;
            
            // Estilos de contenedores de input
            pnlUserContainer.BackColor = UIStyles.LoginInputBg;
            pnlPassContainer.BackColor = UIStyles.LoginInputBg;
            txtUsuario.BackColor = UIStyles.LoginInputBg;
            txtClave.BackColor = UIStyles.LoginInputBg;

            // Botón principal
            btnIngresar.BackColor = UIStyles.BrandGold;
            btnIngresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 196, 100);
            
            // Botón "Ingresar con otro"
            btnOther.ForeColor = UIStyles.BrandTeal;
            btnOther.FlatAppearance.BorderColor = UIStyles.BrandTeal;
            btnOther.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 250, 250);

            // Link de olvidar contraseña
            lblForgot.LinkColor = UIStyles.BrandTeal;
            lblForgot.ActiveLinkColor = UIStyles.BrandGold;

            // Progress Bar
            pgbLogin.Value = 0;
            pgbLogin.Visible = false;
            pgbLogin.ForeColor = UIStyles.BrandGold;
        }

        private void pnlLeftSide_Paint(object sender, PaintEventArgs e)
        {
            UIStyles.PaintGradient(e.Graphics, pnlLeftSide.ClientRectangle, 
                UIStyles.LoginGradientStart, UIStyles.LoginGradientEnd, 90f);

            // Dibujar círculos decorativos (estilo moderno)
            using (var brush = new SolidBrush(Color.FromArgb(30, Color.White)))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(brush, new Rectangle(-100, 200, 250, 250));
            }
            using (var brush = new SolidBrush(Color.FromArgb(20, UIStyles.BrandGold)))
            {
                e.Graphics.FillEllipse(brush, new Rectangle(180, -30, 200, 200));
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            isPasswordHidden = !isPasswordHidden;
            txtClave.PasswordChar = isPasswordHidden ? '●' : '\0';
            btnShowPass.ForeColor = UIStyles.BrandTeal;
            btnShowPass.Text = isPasswordHidden ? "VER" : "OCULTAR";
        }

        private void lblForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Por favor, contacte al administrador del sistema para restablecer su contraseña.\n\nSoporte: soporte@bluecaritas.com", 
                "Recuperar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadRememberedUser()
        {
            // Logica simple de recordarme (podría usarse Properties.Settings)
            try {
                // txtUsuario.Text = Properties.Settings.Default.RememberedUser;
                // chkRemember.Checked = !string.IsNullOrEmpty(txtUsuario.Text);
            } catch { }
        }

        private void SaveRememberedUser()
        {
            if (chkRemember.Checked) {
                // Properties.Settings.Default.RememberedUser = txtUsuario.Text;
            } else {
                // Properties.Settings.Default.RememberedUser = "";
            }
            // Properties.Settings.Default.Save();
        }


        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtClave.Text))
            {
                error.SetError(txtUsuario, "Ingrese usuario");
                error.SetError(txtClave, "Ingrese clave");
                await ShakePanel();
                txtUsuario.Focus();
                return;
            }

            error.SetError(txtUsuario, "");
            error.SetError(txtClave, "");

            // Validación de seguridad básica
            if (!BL.SecurityHelper.ValidarComplejidadBasica(txtClave.Text))
            {
                await ShakePanel();
                MessageBox.Show("Seguridad insuficiente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Preparar UI para proceso
            pgbLogin.Visible = true;
            pgbLogin.Value = 0;
            pgbLogin.Style = ProgressBarStyle.Continuous;
            pgbLogin.ForeColor = UIStyles.BrandCyan;

            lblSubSignIn.Text = "Iniciando sesión...";
            
            btnIngresar.Enabled = false;
            txtUsuario.Enabled = false;
            txtClave.Enabled = false;

            try
            {
                objEUsuario.Usuario = txtUsuario.Text;
                objEUsuario.Clave = txtClave.Text;

                // Simulación de carga fluida (Animación de entrada)
                for (int i = 0; i <= 45; i++)
                {
                    pgbLogin.Value = i;
                    await Task.Delay(10);
                }

                lblSubSignIn.Text = "Validando credenciales...";
                pgbLogin.Style = ProgressBarStyle.Marquee;

                // Operación asíncrona real
                var est = await Task.Run(() => objBLUsuario.Login(objEUsuario));

                pgbLogin.Style = ProgressBarStyle.Continuous;
                lblSubSignIn.Text = "Verificando perfil...";

                // Animación de salida fluida
                for (int i = 46; i <= 100; i++)
                {
                    pgbLogin.Value = i;
                    await Task.Delay(5);
                }

                await Task.Delay(200);

                if (est.Rows.Count > 0)
                {
                    var perfil = est.Rows[0]["Perfil"].ToString();
                    lblSubSignIn.Text = "¡Bienvenido!";
                    SaveRememberedUser();
                    Log.Information("Acceso concedido: {Usuario} ({Perfil})", txtUsuario.Text, perfil);

                    // Fade out antes de cambiar de ventana
                    while (this.Opacity > 0)
                    {
                        this.Opacity -= 0.1;
                        await Task.Delay(10);
                    }

                    if (perfil.Contains("Empleado"))
                    {
                        frmMarcacion frm = new frmMarcacion();
                        frm.FormClosed += (s, args) => Application.Exit();
                        frm.Show();
                    }
                    else
                    {
                        var nombreUsuario = txtUsuario.Text;
                        MDIMenu frmMenu = new MDIMenu(nombreUsuario);
                        // Al cerrar el menú NO salimos de la app — el menú gestiona su propio ciclo
                        frmMenu.Show();
                    }
                    this.Hide();
                }
                else
                {
                    lblSubSignIn.Text = "Ingrese sus credenciales para acceder";
                    Log.Warning("Intento de login fallido: {Usuario}", txtUsuario.Text);
                    MessageBox.Show("Credenciales inválidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    pgbLogin.Visible = false;
                    txtClave.Clear();
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Fallo técnico en login");
                MessageBox.Show("Error de conexión con el servidor", "Error Técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pgbLogin.Visible = false;
            }
            finally
            {
                btnIngresar.Enabled = true;
                txtUsuario.Enabled = true;
                txtClave.Enabled = true;
            }
        }

        private async Task ShakePanel()
        {
            var original = originalPanelLocation;
            int shakeIntensity = 8;
            for (int i = 0; i < 4; i++)
            {
                pnlMain.Location = new Point(original.X + shakeIntensity, original.Y);
                await Task.Delay(40);
                pnlMain.Location = new Point(original.X - shakeIntensity, original.Y);
                await Task.Delay(40);
            }
            pnlMain.Location = original;
        }

        /// <summary>
        /// Reinicia el formulario para una nueva sesión de login.
        /// Llamado por MDIMenu al cerrar sesión.
        /// </summary>
        public void ReiniciarFormulario()
        {
            txtUsuario.Clear();
            txtClave.Clear();
            chkRemember.Checked = false;
            lblSubSignIn.Text = "Ingrese sus credenciales para acceder";
            pgbLogin.Visible = false;
            pgbLogin.Value = 0;
            error.Clear();
            this.Opacity = 1;
            // Restaurar controles
            btnIngresar.Enabled = true;
            txtUsuario.Enabled = true;
            txtClave.Enabled = true;
            LoadRememberedUser();
        }

        /// <summary>
        /// Al cerrar el formulario de login (con X o botón Cancelar),
        /// se cierra toda la aplicación.
        /// </summary>
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "¿Desea salir del sistema?",
                    "Confirmación de salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
        }
    }
}
