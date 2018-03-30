using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class CompanyControl : UserControl
    {
        public Company Model { get; private set; }

        public CompanyControl(Company model)
        {
            Model = model;
            InitializeComponent();

            txtFullName.Text = Model?.LongName;
            txtShortName.Text = Model?.ShortName;
        }
    }
}