using System.Linq;
using System.Text;
using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
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

                if (data?.Context == null)
                    return string.Empty;

                if (data.Context.Count == 1)
                {
                    return data.Context.FirstOrDefault()?.FullName;
                }

                var stringBuilder = new StringBuilder(data.Context.Count);
                stringBuilder.Append(data.Context.FirstOrDefault()?.Position);

                foreach (var person in data.Context.Skip(1))
                    stringBuilder.Append(", " + person.Position);

                return stringBuilder.ToString();
            }

            return cell.Data.ToString();
        }
    }
}