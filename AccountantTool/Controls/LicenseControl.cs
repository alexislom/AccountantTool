using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using License = AccountantTool.Model.License;

namespace AccountantTool.Controls
{
    public partial class LicenseControl : UserControl
    {
        public List<License> Model { get; private set; }

        public LicenseControl(ICollection<License> model)
        {
            Model = model.ToList();
            InitializeComponent();
        }
    }
}