using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public sealed class RequisitesListViewDropdownCell : BaseListViewDropdownCell
    {
        public RequisitesListViewDropdownCell(Requisites model) : base(new RequisitesControl(model))
        {
        }
    }
}