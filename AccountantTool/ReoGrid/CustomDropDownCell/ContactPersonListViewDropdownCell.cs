using System.Collections.Generic;
using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public sealed class ContactPersonListViewDropdownCell : BaseListViewDropdownCell
    {
        public ContactPersonListViewDropdownCell(ICollection<ContactPerson> model) : base(new ContactPersonControl(model))
        {
        }
    }
}