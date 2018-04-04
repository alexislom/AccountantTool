using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class EmptyDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell) => null;
    }
}