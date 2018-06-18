using System.Collections.Generic;
using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public class ContractListViewDropdownCell : BaseListViewDropdownCell
    {
        public ContractListViewDropdownCell(List<Contract> model) : base(new ContractControl(model))
        {
        }
    }
}