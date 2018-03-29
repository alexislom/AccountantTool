using System;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class ContractDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            return "Contract";
        }
    }
}