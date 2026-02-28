namespace GUI
{
    partial class frmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pgbLogin = new System.Windows.Forms.ProgressBar();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLeftSide = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.pnlRightSide = new System.Windows.Forms.Panel();
            this.lblSignIn = new System.Windows.Forms.Label();
            this.lblSubSignIn = new System.Windows.Forms.Label();
            this.pnlUserContainer = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUserIcon = new System.Windows.Forms.Label();
            this.pnlPassContainer = new System.Windows.Forms.Panel();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnShowPass = new System.Windows.Forms.Button();
            this.lblPassIcon = new System.Windows.Forms.Label();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.lblForgot = new System.Windows.Forms.LinkLabel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblOr = new System.Windows.Forms.Label();
            this.btnOther = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblSignUp = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlLeftSide.SuspendLayout();
            this.pnlRightSide.SuspendLayout();
            this.pnlUserContainer.SuspendLayout();
            this.pnlPassContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgbLogin
            // 
            this.pgbLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbLogin.Location = new System.Drawing.Point(0, 440);
            this.pgbLogin.Name = "pgbLogin";
            this.pgbLogin.Size = new System.Drawing.Size(800, 10);
            this.pgbLogin.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbLogin.TabIndex = 6;
            this.pgbLogin.Visible = false;
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlLeftSide);
            this.pnlMain.Controls.Add(this.pnlRightSide);
            this.pnlMain.Location = new System.Drawing.Point(25, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(750, 400);
            this.pnlMain.TabIndex = 11;
            // 
            // pnlLeftSide
            // 
            this.pnlLeftSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlLeftSide.Controls.Add(this.lblWelcome);
            this.pnlLeftSide.Controls.Add(this.lblDesc);
            this.pnlLeftSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftSide.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSide.Name = "pnlLeftSide";
            this.pnlLeftSide.Size = new System.Drawing.Size(325, 400);
            this.pnlLeftSide.TabIndex = 0;
            this.pnlLeftSide.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeftSide_Paint);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(40, 80);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(214, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "BIENVENIDO";
            // 
            // lblDesc
            // 
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDesc.ForeColor = System.Drawing.Color.White;
            this.lblDesc.Location = new System.Drawing.Point(45, 163);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(225, 60);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Sistema de Control de Personal avanzado con gestión de marcaciones, reportes y cá" +
    "lculos de salarios en tiempo real.";
            // 
            // pnlRightSide
            // 
            this.pnlRightSide.Controls.Add(this.lblSignIn);
            this.pnlRightSide.Controls.Add(this.lblSubSignIn);
            this.pnlRightSide.Controls.Add(this.pnlUserContainer);
            this.pnlRightSide.Controls.Add(this.pnlPassContainer);
            this.pnlRightSide.Controls.Add(this.chkRemember);
            this.pnlRightSide.Controls.Add(this.lblForgot);
            this.pnlRightSide.Controls.Add(this.btnIngresar);
            this.pnlRightSide.Controls.Add(this.lblOr);
            this.pnlRightSide.Controls.Add(this.btnOther);
            this.pnlRightSide.Controls.Add(this.lblFooter);
            this.pnlRightSide.Controls.Add(this.lblSignUp);
            this.pnlRightSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightSide.Location = new System.Drawing.Point(0, 0);
            this.pnlRightSide.Name = "pnlRightSide";
            this.pnlRightSide.Size = new System.Drawing.Size(750, 400);
            this.pnlRightSide.TabIndex = 1;
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSignIn.Location = new System.Drawing.Point(405, 21);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(184, 37);
            this.lblSignIn.TabIndex = 0;
            this.lblSignIn.Text = "Iniciar sesión";
            // 
            // lblSubSignIn
            // 
            this.lblSubSignIn.AutoSize = true;
            this.lblSubSignIn.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSubSignIn.ForeColor = System.Drawing.Color.Gray;
            this.lblSubSignIn.Location = new System.Drawing.Point(409, 63);
            this.lblSubSignIn.Name = "lblSubSignIn";
            this.lblSubSignIn.Size = new System.Drawing.Size(199, 13);
            this.lblSubSignIn.TabIndex = 1;
            this.lblSubSignIn.Text = "Ingrese sus credenciales para acceder";
            // 
            // pnlUserContainer
            // 
            this.pnlUserContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.pnlUserContainer.Controls.Add(this.txtUsuario);
            this.pnlUserContainer.Controls.Add(this.lblUserIcon);
            this.pnlUserContainer.Location = new System.Drawing.Point(405, 96);
            this.pnlUserContainer.Name = "pnlUserContainer";
            this.pnlUserContainer.Size = new System.Drawing.Size(320, 45);
            this.pnlUserContainer.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.Location = new System.Drawing.Point(45, 13);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(260, 18);
            this.txtUsuario.TabIndex = 0;
            // 
            // lblUserIcon
            // 
            this.lblUserIcon.AutoSize = true;
            this.lblUserIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUserIcon.Location = new System.Drawing.Point(10, 11);
            this.lblUserIcon.Name = "lblUserIcon";
            this.lblUserIcon.Size = new System.Drawing.Size(32, 21);
            this.lblUserIcon.TabIndex = 1;
            this.lblUserIcon.Text = "👤";
            // 
            // pnlPassContainer
            // 
            this.pnlPassContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.pnlPassContainer.Controls.Add(this.txtClave);
            this.pnlPassContainer.Controls.Add(this.btnShowPass);
            this.pnlPassContainer.Controls.Add(this.lblPassIcon);
            this.pnlPassContainer.Location = new System.Drawing.Point(405, 156);
            this.pnlPassContainer.Name = "pnlPassContainer";
            this.pnlPassContainer.Size = new System.Drawing.Size(320, 45);
            this.pnlPassContainer.TabIndex = 3;
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClave.Location = new System.Drawing.Point(45, 13);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '●';
            this.txtClave.Size = new System.Drawing.Size(200, 18);
            this.txtClave.TabIndex = 0;
            // 
            // btnShowPass
            // 
            this.btnShowPass.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPass.FlatAppearance.BorderSize = 0;
            this.btnShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPass.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnShowPass.Location = new System.Drawing.Point(250, 7);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Size = new System.Drawing.Size(60, 30);
            this.btnShowPass.TabIndex = 1;
            this.btnShowPass.Text = "VER";
            this.btnShowPass.UseVisualStyleBackColor = false;
            this.btnShowPass.Click += new System.EventHandler(this.btnShowPass_Click);
            // 
            // lblPassIcon
            // 
            this.lblPassIcon.AutoSize = true;
            this.lblPassIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPassIcon.Location = new System.Drawing.Point(10, 11);
            this.lblPassIcon.Name = "lblPassIcon";
            this.lblPassIcon.Size = new System.Drawing.Size(32, 21);
            this.lblPassIcon.TabIndex = 2;
            this.lblPassIcon.Text = "🔒";
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.chkRemember.Location = new System.Drawing.Point(405, 216);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(87, 17);
            this.chkRemember.TabIndex = 4;
            this.chkRemember.Text = "Recordarme";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // lblForgot
            // 
            this.lblForgot.AutoSize = true;
            this.lblForgot.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblForgot.LinkColor = System.Drawing.Color.DimGray;
            this.lblForgot.Location = new System.Drawing.Point(595, 216);
            this.lblForgot.Name = "lblForgot";
            this.lblForgot.Size = new System.Drawing.Size(126, 13);
            this.lblForgot.TabIndex = 5;
            this.lblForgot.TabStop = true;
            this.lblForgot.Text = "¿Olvidó su contraseña?";
            this.lblForgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblForgot_LinkClicked);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(405, 251);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(320, 45);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblOr.ForeColor = System.Drawing.Color.Gray;
            this.lblOr.Location = new System.Drawing.Point(555, 306);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(16, 13);
            this.lblOr.TabIndex = 7;
            this.lblOr.Text = "O";
            // 
            // btnOther
            // 
            this.btnOther.BackColor = System.Drawing.Color.White;
            this.btnOther.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOther.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOther.Location = new System.Drawing.Point(405, 326);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(320, 45);
            this.btnOther.TabIndex = 8;
            this.btnOther.Text = "Ingresar con otro";
            this.btnOther.UseVisualStyleBackColor = false;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Location = new System.Drawing.Point(100, 400);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(0, 13);
            this.lblFooter.TabIndex = 9;
            // 
            // lblSignUp
            // 
            this.lblSignUp.AutoSize = true;
            this.lblSignUp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSignUp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblSignUp.Location = new System.Drawing.Point(232, 400);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(0, 13);
            this.lblSignUp.TabIndex = 10;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pgbLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlLeftSide.ResumeLayout(false);
            this.pnlLeftSide.PerformLayout();
            this.pnlRightSide.ResumeLayout(false);
            this.pnlRightSide.PerformLayout();
            this.pnlUserContainer.ResumeLayout(false);
            this.pnlUserContainer.PerformLayout();
            this.pnlPassContainer.ResumeLayout(false);
            this.pnlPassContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ProgressBar pgbLogin;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeftSide;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Panel pnlRightSide;
        private System.Windows.Forms.Label lblSignIn;
        private System.Windows.Forms.Label lblSubSignIn;
        private System.Windows.Forms.Panel pnlUserContainer;
        private System.Windows.Forms.Label lblUserIcon;
        private System.Windows.Forms.Panel pnlPassContainer;
        private System.Windows.Forms.Button btnShowPass;
        private System.Windows.Forms.Label lblPassIcon;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.LinkLabel lblForgot;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.LinkLabel lblSignUp;
    }
}

