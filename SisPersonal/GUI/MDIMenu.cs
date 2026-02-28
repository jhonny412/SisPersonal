using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class MDIMenu : Form
    {
        private int childFormNumber = 0;
        private string _nombreUsuario;
        private bool isSidebarCollapsed = false;
        private const int ExpandedWidth = 230;
        private const int CollapsedWidth = 60;

        public MDIMenu(string nombreUsuario = "")
        {
            InitializeComponent();
            _nombreUsuario = nombreUsuario;
            this.DoubleBuffered = true;
        }

        private void ApplyModernStyles()
        {
            UIStyles.ApplyFormStyle(this);
            UIStyles.ApplyToolStripStyle(menuStrip);
            UIStyles.ApplyToolStripStyle(toolStrip);
            
            pnlSidebarHeader.BackColor = UIStyles.SidebarBg;
            btnHamburger.BackColor = UIStyles.SidebarBg;
            pnlUser.BackColor = UIStyles.SidebarBg;
            
            // Status strip styling
            statusStrip.BackColor = UIStyles.SidebarBg;
            statusStrip.ForeColor = Color.White;
            
            splitContainer1.BackColor = UIStyles.LightGray;
            splitContainer1.Panel1.BackColor = UIStyles.SidebarBg;
            splitContainer1.Panel2.BackColor = UIStyles.LightGray;

            InitializeSidebar();
        }

        private void InitializeSidebar()
        {
            flpSidebarItems.Controls.Clear();
            flpSidebarItems.BackColor = UIStyles.SidebarBg;
            pnlSidebarHeader.BackColor = UIStyles.SidebarBg;

            // Define items based on the previous tree structure
            AddSidebarCategory("REPORTES", "graph.ico");
            AddSidebarButton("Marcaciones", "cedialer.ico");
            AddSidebarButton("Asistencias", "NOTE16.ICO");
            AddSidebarButton("Tardanzas", "ProgressError.ico");
            AddSidebarButton("Faltas", "CambiarUsuario.png");
            AddSidebarButton("Horas Extras", "CLOCK02.ICO");

            AddSidebarCategory("OPERACIONES", "MiningModel.ico");
            AddSidebarButton("Gestionar Usuarios", "images (3).jpg");
            AddSidebarButton("Gestionar Empleados", "images (1).jpg");

            AddSidebarCategory("SALARIOS", "Calculadora.jpg");
            AddSidebarButton("Lista General", "NOTE16.ICO");
            AddSidebarButton("Por Trabajador", "Reporte2.png");

            AddSidebarCategory("SISTEMA", "Salir.png");
            AddSidebarButton("Salir", "Salir.png");
        }

        private void AddSidebarCategory(string text, string iconKey)
        {
            Label lbl = new Label
            {
                Text = text,
                ForeColor = UIStyles.TextSecond,
                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold),
                Padding = new Padding(15, 20, 0, 5),
                AutoSize = false,
                Size = new System.Drawing.Size(ExpandedWidth, 40),
                TextAlign = System.Drawing.ContentAlignment.BottomLeft
            };
            flpSidebarItems.Controls.Add(lbl);
        }

        private void AddSidebarButton(string text, string iconKey)
        {
            Button btn = new Button
            {
                Text = "      " + text,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                ForeColor = System.Drawing.Color.White,
                Font = UIStyles.BodyFont,
                Size = new System.Drawing.Size(ExpandedWidth - 20, 40),
                Margin = new Padding(10, 2, 10, 2),
                Cursor = Cursors.Hand,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = UIStyles.SidebarHover;
            btn.FlatAppearance.MouseDownBackColor = UIStyles.SidebarSelection;

            if (imageList1.Images.ContainsKey(iconKey))
            {
                btn.Image = imageList1.Images[iconKey];
            }

            btn.Click += (s, e) => NavigateTo(text);
            btn.Tag = text; // Store text for collapse/expand
            flpSidebarItems.Controls.Add(btn);
        }

        private void btnHamburger_Click(object sender, EventArgs e)
        {
            isSidebarCollapsed = !isSidebarCollapsed;
            tmrSidebar.Start();
        }

        private void tmrSidebar_Tick(object sender, EventArgs e)
        {
            if (isSidebarCollapsed)
            {
                if (splitContainer1.SplitterDistance > CollapsedWidth)
                {
                    splitContainer1.SplitterDistance -= 20;
                    if (splitContainer1.SplitterDistance < CollapsedWidth) splitContainer1.SplitterDistance = CollapsedWidth;
                }
                else
                {
                    tmrSidebar.Stop();
                    RefreshSidebarItems();
                }
            }
            else
            {
                if (splitContainer1.SplitterDistance < ExpandedWidth)
                {
                    splitContainer1.SplitterDistance += 20;
                    if (splitContainer1.SplitterDistance > ExpandedWidth) splitContainer1.SplitterDistance = ExpandedWidth;
                }
                else
                {
                    tmrSidebar.Stop();
                    RefreshSidebarItems();
                }
            }
        }

        private void RefreshSidebarItems()
        {
            if (isSidebarCollapsed)
            {
                lblTitle.Visible = false;
                lblUser.Visible = false;
                foreach (Control ctrl in flpSidebarItems.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.Text = "";
                        btn.Size = new System.Drawing.Size(CollapsedWidth - 20, 40);
                    }
                    else if (ctrl is Label lbl)
                    {
                        lbl.Visible = false;
                    }
                }
            }
            else
            {
                lblTitle.Visible = true;
                lblUser.Visible = true;
                foreach (Control ctrl in flpSidebarItems.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.Text = "      " + (string)btn.Tag;
                        btn.Size = new System.Drawing.Size(ExpandedWidth - 20, 40);
                    }
                    else if (ctrl is Label lbl)
                    {
                        lbl.Visible = true;
                    }
                }
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Sistema de Control de Personal",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CerrarSesion();
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void NavigateTo(string target)
        {
            switch (target)
            {
                case "Marcaciones":
                    CheckAndOpen<frmReporteMarcaciones>();
                    break;
                case "Asistencias":
                    CheckAndOpen<frmViewRepMarcaciones>();
                    break;
                case "Tardanzas":
                    CheckAndOpen<frmTardanzas>();
                    break;
                case "Faltas":
                    CheckAndOpen<frmFaltas>();
                    break;
                case "Horas Extras":
                    CheckAndOpen<frmHorasExtras>();
                    break;
                case "Lista General":
                    CheckAndOpen<frmListaGeneral>();
                    break;
                case "Por Trabajador":
                    CheckAndOpen<frmPorTrabajador>();
                    break;
                case "Gestionar Usuarios":
                    CheckAndOpen<frmGestionUsuario>();
                    break;
                case "Gestionar Empleados":
                    CheckAndOpen<frmGestionEmpleados>();
                    break;
                case "Salir":
                    if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Sistema de Control de Personal",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CerrarSesion();
                    }
                    break;
            }
        }

        private void CheckAndOpen<T>() where T : Form, new()
        {
            // Buscar si ya existe una instancia de este tipo de formulario en el panel
            foreach (Control ctrl in splitContainer1.Panel2.Controls)
            {
                if (ctrl is T)
                {
                    Form existingForm = (Form)ctrl;
                    MessageBox.Show("El formulario '" + existingForm.Text + "' ya se encuentra activo.", 
                                    "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    existingForm.BringToFront();
                    existingForm.Focus();
                    return;
                }
            }

            // Si no existe, lo creamos y abrimos
            T newForm = new T();
            OpenChildForm(newForm);
        }

        private void OpenChildForm(Form childForm)
        {
            // Configuramos el formulario para que se comporte como una ventana dentro del panel
            childForm.MdiParent = this;
            splitContainer1.Panel2.Controls.Add(childForm);
            
            // REQUERIMIENTO: No debe maximizarse
            childForm.WindowState = FormWindowState.Normal;
            childForm.Dock = DockStyle.None; // Quitamos el Fill para que no ocupe todo el espacio
            
            // REQUERIMIENTO: Mostrar sobre los anteriores
            childForm.BringToFront();
            
            // Estilo de ventana para que se vea "sobre" el fondo
            childForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            childForm.StartPosition = FormStartPosition.CenterParent;
            
            // Centrar manualmente en el panel si es posible
            int x = (splitContainer1.Panel2.Width - childForm.Width) / 2;
            int y = (splitContainer1.Panel2.Height - childForm.Height) / 2;
            childForm.Location = new System.Drawing.Point(Math.Max(0, x), Math.Max(0, y));

            childForm.Show();
        }

        private void MDIMenu_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
            tsEstado.Text = "USUARIO: " + _nombreUsuario;
            lblUser.Text = "👤 " + _nombreUsuario;
            
            // Set initial state
            RefreshSidebarItems();
        }

        /// <summary>
        /// Cierra la sesión: oculta el menú y vuelve a mostrar el formulario de login.
        /// NO cierra la aplicación.
        /// </summary>
        private void CerrarSesion()
        {
            // Cerrar todos los formularios MDI hijos
            foreach (Form child in this.MdiChildren)
                child.Close();

            // Cerrar formularios no-MDI alojados en el panel
            var panelForms = new System.Collections.Generic.List<Control>();
            foreach (Control ctrl in splitContainer1.Panel2.Controls)
                panelForms.Add(ctrl);
            foreach (Control ctrl in panelForms)
            {
                if (ctrl is Form f) f.Close();
            }
            splitContainer1.Panel2.Controls.Clear();

            // Buscar y mostrar el login
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmLogin login)
                {
                    login.ReiniciarFormulario();
                    login.Show();
                    login.BringToFront();
                    break;
                }
            }

            this.Hide();
        }

        private void MDIMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Interceptar el botón X para que no cierre la app: actuar como cierre de sesión
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Sistema de Control de Personal",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CerrarSesion();
                }
            }
        }
    }
}