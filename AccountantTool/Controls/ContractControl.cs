using System;
using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ContractControl : UserControl
    {
        public Contract Model { get; private set; }

        public ContractControl(Contract model)
        {
            Model = model;
            InitializeComponent();

            textNumberOfContract.Text = Model?.NumberOfContract;
            textSidesOfContract.Text = Model?.SidesOfContract;
            textDateOfContract.Text = Model?.DateOfStart.ToString("d");
            textDateOfEnd.Text = Model?.DateOfEnd.ToString("d");
            textContractStage.Text = Model?.ContractStage;
        }

        private void OkContractBtn_Click(object sender, System.EventArgs e)
        {
            Model.NumberOfContract = textNumberOfContract?.Text;

            DateTime.TryParse(textNumberOfContract?.Text, out var dateOfStart);
            DateTime.TryParse(textDateOfEnd?.Text, out var dateOfEnd);

            Model.DateOfStart = dateOfStart;
            Model.SidesOfContract = textSidesOfContract?.Text;
            Model.DateOfEnd = dateOfEnd;
            Model.ContractStage = textContractStage?.Text;
        }
    }
}