using AccountantTool.Controls;
using AccountantTool.Model;
using unvell.ReoGrid.CellTypes;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public sealed class CompanyListViewDropdownCell : DropdownCell
    {
        public CompanyListViewDropdownCell(Company accountantRecordCompany)
        {
            DropdownControl = new CompanyControl(accountantRecordCompany);

            MinimumDropdownWidth = DropdownControl.Width;
            DropdownPanelHeight = DropdownControl.Height;
        }
    }
}