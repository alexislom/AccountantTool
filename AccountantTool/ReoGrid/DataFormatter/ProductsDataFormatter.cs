using System;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class ProductsDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            return "Products";
        }
    }
}