using System.Collections.Generic;
using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public class LicenseListViewDropdownCell : BaseListViewDropdownCell
    {
        public LicenseListViewDropdownCell(ICollection<License> model) : base(new LicenseControl(model))
        {
        }
    }
}