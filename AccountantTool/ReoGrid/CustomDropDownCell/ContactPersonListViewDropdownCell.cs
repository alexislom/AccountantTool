using System.Collections.Generic;
using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public sealed class ContactPersonListViewDropdownCell : BaseListViewDropdownCell
    {
        public ContactPersonListViewDropdownCell(List<ContactPerson> model) : base(new ContactPersonControl(model))
        {
        }
    }
}