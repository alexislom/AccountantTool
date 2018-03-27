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
            if (cell.Column == (int) ColumnIndexes.Requisites)
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

        #region Helpers

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

        #endregion Helpers
    }
}