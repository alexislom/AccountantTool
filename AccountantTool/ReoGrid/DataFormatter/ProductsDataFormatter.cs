using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class ProductsDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.ProductsColumnIndex)
            {
                var data = cell.GetData<ListWrapper<Product>>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<ListWrapper<Product>>(cell.Data.ToString());
                    cell.Data = data;
                }

                return cell.Data.ToString();
            }

            return cell.Data.ToString();
        }
    }
}