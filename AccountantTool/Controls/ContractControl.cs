using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using AccountantTool.Controls.Interfaces;
using AccountantTool.Model;
using DateTime = System.DateTime;

namespace AccountantTool.Controls
{
    public partial class ContractControl : UserControl, INotifyControlDataSave
    {
        #region Properties
        public List<Contract> Model { get; }
        public bool IsDirty { get; set; }
        #endregion Properties

        public ContractControl(List<Contract> model)
        {
            Model = model;
            InitializeComponent();

            if (Model != null)
            {
                foreach (var contract in Model)
                {
                    ContractsListView.Items.Add(new ListViewItem(new[]
                    {
                        contract?.NumberOfContract,
                        contract?.DateOfStart.ToString("d"),
                        contract?.SidesOfContract,
                        contract?.DateOfEnd.ToString("d"),
                        contract?.ConditionsOfContract,
                        contract?.ContractStage
                    }));
                }
            }

            ContractsListView.EditTextBox.TextChanged += (sender, args) => IsDirty = true;

            IsDirty = false;
        }

        private void AddContractBtn_Click(object sender, EventArgs e)
        {
            ContractsListView.Items.Add(new ListViewItem(new[]
            {
                "Number of contract" + new Random().Next(1, 1000000),
                new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day ).ToShortDateString(),
                "Sides of contract",
                new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day ).ToShortDateString(),
                "Conditions of contract",
                "Stage of contract",
            }));

            IsDirty = true;
        }

        private void RemoveContractBtn_Click(object sender, EventArgs e)
        {
            ContractsListView.Items.Remove(ContractsListView.SelectedItem);

            IsDirty = true;
        }

        private void OkContractBtn_Click(object sender, EventArgs e)
        {
            DoClose();
        }

        public void DoClose()
        {
            if (ContractsListView.Items.Count != 0)
            {
                Model.Clear();

                foreach (ListViewItem item in ContractsListView.Items)
                {
                    var subItem = item.SubItems;

                    DateTime.TryParse(subItem[1]?.Text, CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out var dateOfStart);
                    DateTime.TryParse(subItem[3]?.Text, CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out var dateOfEnd);

                    Model.Add(new Contract
                    {
                        NumberOfContract = subItem[0]?.Text,
                        DateOfStart = dateOfStart,
                        SidesOfContract = subItem[2]?.Text,
                        DateOfEnd = dateOfEnd,
                        ConditionsOfContract = subItem[4]?.Text,
                        ContractStage = subItem[5]?.Text
                    });
                }
            }

            IsDirty = false;
        }
    }
}