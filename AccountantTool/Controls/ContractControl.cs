using System;
using System.Globalization;
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
            //textDateOfContract.Text = Model?.DateOfStart.ToString(CultureInfo.InvariantCulture);
            //textDateOfEnd.Text = Model?.DateOfEnd.ToString(CultureInfo.InvariantCulture);
            dateOfConctract.Value = Model.DateOfStart < dateOfConctract.Value ? dateOfConctract.MinDate : Model.DateOfStart;
            dateOfEnd.Value = Model.DateOfEnd < dateOfEnd.Value ? dateOfEnd.MinDate : Model.DateOfEnd;
            textContractStage.Text = Model?.ContractStage;
        }

        private void OkContractBtn_Click(object sender, System.EventArgs e)
        {
            Model.NumberOfContract = textNumberOfContract?.Text;

            //DateTime.TryParse(textDateOfContract?.Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOfStart);
            //DateTime.TryParse(textDateOfEnd?.Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOfEnd);

            Model.DateOfStart = dateOfConctract.Value; //dateOfStart;
            Model.SidesOfContract = textSidesOfContract?.Text;
            Model.DateOfEnd = dateOfEnd.Value; //dateOfEnd;
            Model.ContractStage = textContractStage?.Text;
        }
    }
}