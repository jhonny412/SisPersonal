using System.Windows.Forms;

namespace GUI
{
    public partial class frmListaGeneral : Form
    {
        public frmListaGeneral()
        {
            InitializeComponent();
        }

        private void frmListaGeneral_Load(object sender, System.EventArgs e)
        {
            UIStyles.ApplyModernStylesToForm(this);
        }
    }
}
