using System.Windows.Forms;

namespace GUI
{
    public partial class frmPorTrabajador : Form
    {
        public frmPorTrabajador()
        {
            InitializeComponent();
        }

        private void frmPorTrabajador_Load(object sender, System.EventArgs e)
        {
            UIStyles.ApplyModernStylesToForm(this);
        }
    }
}
