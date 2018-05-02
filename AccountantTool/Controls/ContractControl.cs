using System;
using System.Globalization;
using System.Windows.Forms;
using AccountantTool.Controls.Interfaces;
using AccountantTool.Model;
using DateTime = System.DateTime;

namespace AccountantTool.Controls
{
    public partial class ContractControl : UserControl, INotifyControlDataSave
    {
        #region Fields & properties
        public Contract Model { get; }
        private readonly DateTime _minDateTime = new DateTime(2000, 01, 01);
        public bool IsDirty { get; set; }
        #endregion Fields & properties

        public ContractControl(Contract model)
        {
            Model = model;
            InitializeComponent();

            textNumberOfContract.Text = Model?.NumberOfContract;
            textSidesOfContract.Text = Model?.SidesOfContract;
            maskedTextDateOfStart.Text = Model?.DateOfStart < _minDateTime ? DateTime.Now.ToString("d") : Model?.DateOfStart.ToString("d");
            maskedTextDateOfEnd.Text = Model?.DateOfEnd < _minDateTime ? DateTime.Now.ToString("d") : Model?.DateOfEnd.ToString("d");
            textContractStage.Text = Model?.ContractStage;

            EventSubscriptions();

            IsDirty = false;
        }

        private void EventSubscriptions()
        {
            textNumberOfContract.TextChanged += (sender, args) => IsDirty = true;
            textSidesOfContract.TextChanged += (sender, args) => IsDirty = true;
            maskedTextDateOfStart.TextChanged += (sender, args) => IsDirty = true;
            maskedTextDateOfEnd.TextChanged += (sender, args) => IsDirty = true;
            textContractStage.TextChanged += (sender, args) => IsDirty = true;
        }

        private void OkContractBtn_Click(object sender, EventArgs e)
        {
            DoClose();
        }

        public void DoClose()
        {
            Model.NumberOfContract = textNumberOfContract?.Text;

            DateTime.TryParse(maskedTextDateOfStart?.Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOfStart);
            DateTime.TryParse(maskedTextDateOfEnd?.Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOfEnd);

            Model.DateOfStart = dateOfStart;
            Model.SidesOfContract = textSidesOfContract?.Text;
            Model.DateOfEnd = dateOfEnd;
            Model.ContractStage = textContractStage?.Text;

            IsDirty = false;
        }
    }
}