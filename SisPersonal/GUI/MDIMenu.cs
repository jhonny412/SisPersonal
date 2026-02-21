using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class MDIMenu : Form
    {
        private int childFormNumber = 0;
        frmLogin usuario = new frmLogin();

        public MDIMenu()
        {
            InitializeComponent();
        }

        private void ApplyModernStyles()
        {
            // Aplicar estilos modernos al formulario principal
            UIStyles.ApplyFormStyle(this);
            
            // Aplicar estilos al MenuStrip
            UIStyles.ApplyToolStripStyle(menuStrip);
            
            // Aplicar estilos al ToolStrip
            UIStyles.ApplyToolStripStyle(toolStrip);
            
            // Configurar colores del StatusStrip
            statusStrip.BackColor = UIStyles.White;
            statusStrip.ForeColor = UIStyles.DarkGray;
            
            // Configurar el TreeView con estilos modernos
            tvrMenu.BackColor = UIStyles.White;
            tvrMenu.ForeColor = UIStyles.DarkGray;
            tvrMenu.Font = UIStyles.BodyFont;
            tvrMenu.BorderStyle = BorderStyle.None;
            tvrMenu.ShowLines = false;
            tvrMenu.ShowPlusMinus = true;
            tvrMenu.ShowRootLines = false;
            
            // Configurar el SplitContainer
            splitContainer1.BackColor = UIStyles.LightGray;
            splitContainer1.Panel1.BackColor = UIStyles.White;
            splitContainer1.Panel2.BackColor = UIStyles.LightGray;
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
            Application.Exit();
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

        private void tvrMenu_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = tvrMenu.SelectedNode;
            switch (node.Text)
            {
                case "Marcaciones":
                    frmReporteMarcaciones xform = new frmReporteMarcaciones();
                    xform.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(xform);
                    xform.Show();
                    break;
                case "Asistencias":
                    frmViewRepMarcaciones frmAsis = new frmViewRepMarcaciones();
                    frmAsis.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(frmAsis);
                    frmAsis.Show();
                    break;
                case "Tardanzas":
                    frmTardanzas frmTar = new frmTardanzas();
                    frmTar.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(frmTar);
                    frmTar.Show();
                    break;
                case "Faltas":
                    frmFaltas frmFal = new frmFaltas();
                    frmFal.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(frmFal);
                    frmFal.Show();
                    break;
                case "Horas Extras":
                    frmHorasExtras frmHoEx = new frmHorasExtras();
                    frmHoEx.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(frmHoEx);
                    frmHoEx.Show();
                    break;
                case "Lista General":
                    frmListaGeneral frmLisGe = new frmListaGeneral();
                    frmLisGe.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(frmLisGe);
                    frmLisGe.Show();
                    break;
                case "Por Trabajador":
                    frmPorTrabajador frmPorTra = new frmPorTrabajador();
                    frmPorTra.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(frmPorTra);
                    frmPorTra.Show();
                    break;
                case "Gestionar Usuarios":
                    frmGestionUsuario frmGesUsu = new frmGestionUsuario();
                    frmGesUsu.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(frmGesUsu);
                    frmGesUsu.Show();
                    break;
                case "Gestionar Empleados":
                    frmGestionEmpleados frmGesEmp = new frmGestionEmpleados();
                    frmGesEmp.MdiParent = this;
                    splitContainer1.Panel2.Controls.Add(frmGesEmp);
                    frmGesEmp.Show();
                    break;
                case "Salir":
                    if (MessageBox.Show("Esta seguro que desea Salir del Sistema", "Sistema de control de Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void MDIMenu_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
            string usu;
            usu = usuario._Usuario;
            tsEstado.Text = "USUARIO ACTUAL DEL SISTEMA: " + usu;
        }
    }
}