using System;
using System.Windows.Forms;
using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public class ContractListViewDropdownCell : BaseListViewDropdownCell
    {
        public ContractListViewDropdownCell(Contract model) : base(new ContractControl(model))
        {
        }
    }
}