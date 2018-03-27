using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;
using unvell.ReoGrid.DataFormat;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public abstract class DataFormatter
    {
        public abstract string FormatCell(Cell cell);
    }

    public class EmptyDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            return null;
        }
    }

    public class CompanyFormatter : DataFormatter
    {
        public CompanyFormatter()
        {
            
        }

        public override string FormatCell(Cell cell)
        {
            if (cell.Column != 0)
            {
                return null;
            }

            var data = cell.Data as Company;
            if (data == null)
            {
                data = JsonConvert.DeserializeObject<Company>(data.ToString());
            }

            return data.ShortName;
        }
    }
}
