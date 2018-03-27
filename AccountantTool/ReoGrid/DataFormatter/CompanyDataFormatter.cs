using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class CompanyDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column != 0)
                return null;

            var data = cell.Data as Company;

            if (data == null)
            {
                data = JsonConvert.DeserializeObject<Company>(data.ToString());
            }

            return data.ShortName;
        }
    }
}