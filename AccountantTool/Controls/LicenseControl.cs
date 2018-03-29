using System.Windows.Forms;
using License = AccountantTool.Model.License;

namespace AccountantTool.Controls
{
    public partial class LicenseControl : UserControl
    {
        public License Model { get; private set; }

        public LicenseControl(License model)
        {
            Model = model;
            InitializeComponent();
        }
    }
}