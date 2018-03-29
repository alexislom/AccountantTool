using System;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class LicenseDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            return "License";
        }
    }
}