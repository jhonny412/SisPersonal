using System.Windows.Forms;

namespace GUI
{
    public partial class frmFaltas : Form
    {
        public frmFaltas()
        {
            InitializeComponent();
        }

        private void frmFaltas_Load(object sender, System.EventArgs e)
        {
            UIStyles.ApplyModernStylesToForm(this);
        }
    }
}
