namespace AccountantTool.Common
{
    public class Constants
    {
        // Worksheet properties
        public const int CountOfColumns = 7;
        public const int ColumnsWidth = 260;
        public const int CountOfRowsToAdd = 5;
        public const bool EditReadonly = true;

        // Column indexes
        public const int CompanyColumnIndex = 0;
        public const int RequisitesColumnIndex = 1;
        public const int ContactPersonColumnIndex = 2;
        public const int LicenseColumnIndex = 3;
        public const int ProductsColumnIndex = 4;
        public const int ContractColumnIndex = 5;
        public const int AdditionalInfoColumnIndex = 6;

        // Open/Save file dialog
        public const bool FileDialogRestoreDirectory = true;
        public const string FileDialogFilter = "ReoGrid format|*.rgf;";
    }
}