using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public abstract class DataFormatter
    {
        public abstract string FormatCell(Cell cell);
    }
}