using System.Collections.Generic;
using AccountantTool.Controls;
using AccountantTool.Model;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public class ProductsListViewDropdownCell : BaseListViewDropdownCell
    {
        public ProductsListViewDropdownCell(ICollection<Product> model) : base(new ProductsControl(model))
        {
        }
    }
}