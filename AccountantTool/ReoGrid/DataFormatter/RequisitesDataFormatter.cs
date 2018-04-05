using AccountantTool.Common;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class RequisitesDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.RequisitesColumnIndex)
            {
                var data = cell.GetData<Requisites>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<Requisites>(cell.Data.ToString());
                    cell.Data = data;
                }

                if (!string.IsNullOrEmpty(data.Site))
                    return data.Site;

                return string.IsNullOrEmpty(data.Email) ? string.Empty : data.Email;
            }

            return cell.Data.ToString();
        }
    }
}