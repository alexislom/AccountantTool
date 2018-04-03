using AccountantTool.Common;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class CompanyDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.CompanyColumnIndex)
            {
                var data = cell.GetData<Company>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<Company>(cell.Data.ToString());
                    cell.Data = data;
                }

                return data.ShortName;
            }

            return cell.Data.ToString();
        }
    }
}