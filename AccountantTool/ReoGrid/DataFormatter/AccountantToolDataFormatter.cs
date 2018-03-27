using AccountantTool.Common;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;
using unvell.ReoGrid.DataFormat;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class AccountantToolDataFormatter : IDataFormatter
    {
        public DataFormatter GetFormatter(Cell cell)
        {
            switch (cell.Column)
            {
                case 0:
                    return new CompanyFormatter();
                default:
                    return new EmptyDataFormatter();
            }
        }

        public string FormatCell(Cell cell)
        {
            var formatter = GetFormatter(cell);
            return formatter.FormatCell(cell);

            if (cell.Column == ColumnIndexes.REQUISITES)
            {
                var data = ParseRequisites(cell);

                if (data == null)
                {
                    return null;
                }

                return data.Site ?? JsonConvert.SerializeObject(data);
            }

            return cell.Data.ToString();
        }

        public bool PerformTestFormat() => true;

        public static Requisites ParseRequisites(Cell cell)
        {
            if (cell?.Data == null)
                return null;

            var data = cell.GetData<Requisites>();

            if (data != null)
                return data;

            var context = cell.GetData<string>();

            data = JsonConvert.DeserializeObject<Requisites>(context);
            cell.Data = data;

            return data;
        }
    }
}