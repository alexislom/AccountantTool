using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public class LicenseListViewDropdownCell : BaseListViewDropdownCell
    {
        public LicenseListViewDropdownCell(License model) : base(new LicenseControl(model))
        {
        }
    }
}