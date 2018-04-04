using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public class AdditionalInfoListViewDropdownCell : BaseListViewDropdownCell
    {
        public AdditionalInfoListViewDropdownCell(AdditionalInfo model) : base(new AdditionalInfoControl(model))
        {
        }
    }
}