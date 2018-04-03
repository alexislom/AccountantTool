using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class ContactPersonDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.ContactPersonColumnIndex)
            {
                var data = cell.GetData<ListWrapper<ContactPerson>>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<ListWrapper<ContactPerson>>(cell.Data.ToString());
                    cell.Data = data;
                }

                return cell.Data.ToString();
            }

            return cell.Data.ToString();
        }
    }
}