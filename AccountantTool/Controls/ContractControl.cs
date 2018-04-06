using System;
using System.Globalization;
using System.Windows.Forms;
using AccountantTool.Model;
using DateTime = System.DateTime;

namespace AccountantTool.Controls
{
    public partial class ContractControl : UserControl
    {
        public Contract Model { get; }
        private readonly DateTime _minDateTime = new DateTime(2000, 01, 01);

        public ContractControl(Contract model)
        {
            Model = model;
            InitializeComponent();

            textNumberOfContract.Text = Model?.NumberOfContract;
            textSidesOfContract.Text = Model?.SidesOfContract;

            maskedTextDateOfStart.Text = Model?.DateOfStart < _minDateTime ? DateTime.Now.ToString("d") : Model?.DateOfStart.ToString("d");
            maskedTextDateOfEnd.Text = Model?.DateOfEnd < _minDateTime ? DateTime.Now.ToString("d") : Model?.DateOfEnd.ToString("d");

            textContractStage.Text = Model?.ContractStage;
        }

        private void OkContractBtn_Click(object sender, EventArgs e)
        {
            Model.NumberOfContract = textNumberOfContract?.Text;

            DateTime.TryParse(maskedTextDateOfStart?.Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOfStart);
            DateTime.TryParse(maskedTextDateOfEnd?.Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOfEnd);

            Model.DateOfStart = dateOfStart;
            Model.SidesOfContract = textSidesOfContract?.Text;
            Model.DateOfEnd = dateOfEnd;
            Model.ContractStage = textContractStage?.Text;
        }
    }
}