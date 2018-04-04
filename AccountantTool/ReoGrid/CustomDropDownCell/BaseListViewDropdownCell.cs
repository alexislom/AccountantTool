using System.Windows.Forms;
using unvell.ReoGrid.CellTypes;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public abstract class BaseListViewDropdownCell : DropdownCell
    {
        protected BaseListViewDropdownCell(Control control)
        {
            DropdownControl = control;
            MinimumDropdownWidth = DropdownControl.Width;
            DropdownPanelHeight = DropdownControl.Height;
        }
    }
}