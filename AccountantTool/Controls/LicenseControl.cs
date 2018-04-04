using System;
using System.Collections.Generic;
using System.Windows.Forms;
using License = AccountantTool.Model.License;

namespace AccountantTool.Controls
{
    public partial class LicenseControl : UserControl
    {
        public List<License> Model { get; private set; }

        public LicenseControl(List<License> model)
        {
            Model = model;
            InitializeComponent();

            if (Model != null)
            {
                foreach (var license in Model)
                {
                    LicenseListView.Items.Add(new ListViewItem(new[]
                    {
                        license?.NumberOfLicense,
                        license?.DateOfIssue.ToString("d"),
                        license?.DateOfExpiration.ToString("d"),
                        license?.LicenseType
                    }));
                }
            }
        }

        private void AddLicenseBtn_Click(object sender, EventArgs e)
        {
            LicenseListView.Items.Add(new ListViewItem(new[]
            {
                "Number of license",
                new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day ).ToShortDateString(),
                new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day ).ToShortDateString(),
                "License type"
            }));
        }

        private void RemoveLicenseBtn_Click(object sender, EventArgs e)
        {
            LicenseListView.Items.Remove(LicenseListView.SelectedItem);
        }

        private void OkLicenseBtn_Click(object sender, EventArgs e)
        {
            if (LicenseListView.Items.Count != 0)
            {
                Model = new List<License>(LicenseListView.Items.Count);

                foreach (ListViewItem item in LicenseListView.Items)
                {
                    var subItem = item.SubItems;

                    DateTime.TryParse(subItem[1]?.Text, out var dateOfIssue);
                    DateTime.TryParse(subItem[2]?.Text, out var dateOfExpiration);

                    Model.Add(new License
                    {
                        NumberOfLicense = subItem[0]?.Text,
                        DateOfIssue = dateOfIssue,
                        DateOfExpiration = dateOfExpiration,
                        LicenseType = subItem[3]?.Text
                    });
                }
            }
        }
    }
}