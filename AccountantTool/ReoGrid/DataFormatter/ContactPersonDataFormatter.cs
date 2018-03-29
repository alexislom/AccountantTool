using AccountantTool.Common;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class ContactPersonDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.RequisitesColumnIndex)
            {
                var data = ParseData(cell);

                if (data == null)
                    return null;

                return data.Name ?? JsonConvert.SerializeObject(data);
            }

            return cell.Data.ToString();
        }

        private ContactPerson ParseData(Cell cell)
        {
            if (cell?.Data == null)
                return null;

            var data = cell.GetData<ContactPerson>();

            if (data != null)
                return data;

            var context = cell.GetData<string>();

            data = JsonConvert.DeserializeObject<ContactPerson>(context);
            cell.Data = data;

            return data;
        }
    }
}