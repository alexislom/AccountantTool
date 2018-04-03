using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class LicenseDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.LicenseColumnIndex)
            {
                var data = cell.GetData<ListWrapper<License>>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<ListWrapper<License>>(cell.Data.ToString());
                    cell.Data = data;
                }

                return cell.Data.ToString();
            }

            return cell.Data.ToString();
        }
    }
}