using System;
using AccountantTool.Common;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class AdditionalInfoDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.AdditionalInfoColumnIndex)
            {
                var data = cell.GetData<AdditionalInfo>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<AdditionalInfo>(cell.Data.ToString());
                    cell.Data = data;
                }

                return string.Empty;
            }

            return cell.Data.ToString();
        }
    }
}