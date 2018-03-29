using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
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

                return data?.ContractStage.GetDescription();
            }

            return cell.Data.ToString();
        }
    }
}