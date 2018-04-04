using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public sealed class CompanyListViewDropdownCell : BaseListViewDropdownCell
    {
        public CompanyListViewDropdownCell(Company model) : base(new CompanyControl(model))
        {
        }
    }
}