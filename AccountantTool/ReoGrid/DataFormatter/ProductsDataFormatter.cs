using System.Linq;
using System.Text;
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

                //if (data?.Context == null)
                //    return string.Empty;

                //if (data.Context.Count == 1)
                //{
                //    return data.Context.FirstOrDefault()?.Name;
                //}

                //var stringBuilder = new StringBuilder(data.Context.Count);
                //stringBuilder.Append(data.Context.FirstOrDefault()?.Name);

                //foreach (var product in data.Context.Skip(1))
                //    stringBuilder.Append(", " + product.Name);

                //return stringBuilder.ToString();
            }

            return cell.Data.ToString();
        }
    }
}