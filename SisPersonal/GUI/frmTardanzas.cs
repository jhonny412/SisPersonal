using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTardanzas : Form
    {
        public frmTardanzas()
        {
            InitializeComponent();
        }

        private void frmTardanzas_Load(object sender, EventArgs e)
        {
            UIStyles.ApplyModernStylesToForm(this);
        }
    }
}
