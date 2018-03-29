using AccountantTool.Controls;
using AccountantTool.Model;
using unvell.ReoGrid.CellTypes;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public sealed class RequisitesListViewDropdownCell : DropdownCell
    {
        public RequisitesListViewDropdownCell(Requisites model)
        {
            DropdownControl = new RequisitesControl(model);

            MinimumDropdownWidth = DropdownControl.Width;
            DropdownPanelHeight = DropdownControl.Height;
        }
    }
}