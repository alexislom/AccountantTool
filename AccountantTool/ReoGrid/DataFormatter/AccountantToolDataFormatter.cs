using AccountantTool.Common;
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
                case Constants.CompanyColumnIndex:
                    return new CompanyDataFormatter();
                case Constants.RequisitesColumnIndex:
                    return new RequisitesDataFormatter();
                case Constants.ContactPersonColumnIndex:
                    return new ContactPersonDataFormatter();
                case Constants.LicenseColumnIndex:
                    return new LicenseDataFormatter();
                case Constants.ProductsColumnIndex:
                    return new ProductsDataFormatter();
                case Constants.ContractColumnIndex:
                    return new ContractDataFormatter();
                case Constants.AdditionalInfoColumnIndex:
                    return new AdditionalInfoDataFormatter();
                default:
                    return new EmptyDataFormatter();
            }
        }

        #endregion Helpers
    }
}