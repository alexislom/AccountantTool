using System;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class AdditionalInfoDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            return "AdditionalInfo";
        }
    }
}