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

            textNumberOfContract.Text = Model.NumberOfContract.ToString();
            textSidesOfContract.Text = Model.SidesOfContract;
            textDateOfContract.Text = Model.DateOfStart.ToString("d");
            textDateOfEnd.Text = Model.DateOfEnd.ToString("d");
            textContractStage.Text = Model.ContractStage.ToString();
        }
    }
}