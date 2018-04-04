using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public class ContactListViewDropdownCell : BaseListViewDropdownCell
    {
        public ContactListViewDropdownCell(Contract model) : base(new ContractControl(model))
        {
        }
    }
}