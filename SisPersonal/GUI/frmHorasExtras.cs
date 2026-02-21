using System.Windows.Forms;

namespace GUI
{
    public partial class frmHorasExtras : Form
    {
        public frmHorasExtras()
        {
            InitializeComponent();
        }

        private void frmHorasExtras_Load(object sender, System.EventArgs e)
        {
            UIStyles.ApplyModernStylesToForm(this);
        }
    }
}
