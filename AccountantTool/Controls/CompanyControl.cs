using System.Windows.Forms;
using AccountantTool.Controls.Interfaces;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class CompanyControl : UserControl, INotifyControlDataSave
    {
        #region Properties
        public Company Model { get; }
        public bool IsDirty { get; set; }
        #endregion Properties

        public CompanyControl(Company model)
        {
            Model = model;
            InitializeComponent();

            txtFullName.Text = Model?.LongName;
            txtShortName.Text = Model?.ShortName;

            EventSubscriptions();

            IsDirty = false;
        }

        private void EventSubscriptions()
        {
            txtFullName.TextChanged += (sender, args) => IsDirty = true;
            txtShortName.TextChanged += (sender, args) => IsDirty = true;
        }

        private void OkCompanyBtn_Click(object sender, System.EventArgs e)
        {
            DoClose();
        }

        public void DoClose()
        {
            Model.LongName = txtFullName?.Text;
            Model.ShortName = txtShortName?.Text;

            IsDirty = false;
        }
    }
}