using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class CompanyControl : UserControl
    {
        public Company AccountantRecordCompany { get; private set; }

        public CompanyControl(Company accountantRecordCompany)
        {
            AccountantRecordCompany = accountantRecordCompany;
            InitializeComponent();
            this.txtFullName.Text = AccountantRecordCompany.LongName;
            this.txtShortName.Text = AccountantRecordCompany.ShortName;
        }
    }
}