using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class ContractDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.ContractColumnIndex)
            {
                var data = cell.GetData<ListWrapper<Contract>>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<ListWrapper<Contract>>(cell.Data.ToString());
                    cell.Data = data;
                }

                return string.Empty;
            }

            return cell.Data.ToString();
        }
    }
}