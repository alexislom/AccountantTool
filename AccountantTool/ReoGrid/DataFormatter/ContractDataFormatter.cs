using AccountantTool.Common;
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
                var data = cell.GetData<Contract>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<Contract>(cell.Data.ToString());
                    cell.Data = data;
                }

                return data.ContractStage;
            }

            return cell.Data.ToString();
        }
    }
}