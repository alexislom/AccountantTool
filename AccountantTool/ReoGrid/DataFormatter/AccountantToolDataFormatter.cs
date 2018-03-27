using unvell.ReoGrid;
using unvell.ReoGrid.DataFormat;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class AccountantToolDataFormatter : IDataFormatter
    {
        public string FormatCell(Cell cell)
        {
            var formatter = GetFormatter(cell);
            return formatter.FormatCell(cell);
        }

        public bool PerformTestFormat() => true;

        #region Helpers

        public DataFormatter GetFormatter(Cell cell)
        {
            switch (cell.Column)
            {
                case 0:
                    return new CompanyDataFormatter();
                case 1:
                    return new RequisitesDataFormatter();
                default:
                    return new EmptyDataFormatter();
            }
        }

        #endregion Helpers
    }
}