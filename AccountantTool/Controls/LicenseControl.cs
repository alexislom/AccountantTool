using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AccountantTool.Controls.Interfaces;
using License = AccountantTool.Model.License;

namespace AccountantTool.Controls
{
    public partial class LicenseControl : UserControl, INotifyControlDataSave
    {
        #region Properties
        public List<License> Model { get; }
        public bool IsDirty { get; set; }
        #endregion Properties

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

            LicenseListView.EditTextBox.TextChanged += (sender, args) => IsDirty = true;

            IsDirty = false;
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

            IsDirty = true;
        }

        private void RemoveLicenseBtn_Click(object sender, EventArgs e)
        {
            LicenseListView.Items.Remove(LicenseListView.SelectedItem);

            IsDirty = true;
        }

        private void OkLicenseBtn_Click(object sender, EventArgs e)
        {
            DoClose();
        }

        public void DoClose()
        {
            if (LicenseListView.Items.Count != 0)
            {
                Model.Clear();

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

            IsDirty = false;
        }
    }
}