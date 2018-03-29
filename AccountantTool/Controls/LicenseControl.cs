using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using License = AccountantTool.Model.License;

namespace AccountantTool.Controls
{
    public partial class LicenseControl : UserControl
    {
        public List<License> Model { get; private set; }

        public LicenseControl(List<License> model)
        {
            Model = model.ToList();
            InitializeComponent();

            foreach (var license in Model)
            {
                LicenseListView.Items.Add(new ListViewItem(new[]
                {
                    license.NumberOfLicense.ToString(),
                    license.DateOfIssue.ToString("d"),
                    license.DateOfExpiration.ToString("d"),
                    license.LicenseType.ToString()
                }));
            }
        }
    }
}