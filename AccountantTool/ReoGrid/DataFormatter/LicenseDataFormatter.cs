using System;
using System.Linq;
using System.Text;
using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
using Newtonsoft.Json;
using unvell.ReoGrid;

namespace AccountantTool.ReoGrid.DataFormatter
{
    public class LicenseDataFormatter : DataFormatter
    {
        public override string FormatCell(Cell cell)
        {
            if (cell.Column == Constants.LicenseColumnIndex)
            {
                var data = cell.GetData<ListWrapper<License>>();

                if (data == null)
                {
                    data = JsonConvert.DeserializeObject<ListWrapper<License>>(cell.Data.ToString());
                    cell.Data = data;
                }

                return cell.Data.ToString();


                //if (data?.Context == null)
                //    return string.Empty;

                //if (data.Context.Count == 1)
                //{
                //    return data.Context.FirstOrDefault()?.LicenseType.GetDescription();
                //}

                //var stringBuilder = new StringBuilder(data.Context.Count);
                //stringBuilder.Append(data.Context.FirstOrDefault()?.LicenseType.GetDescription());

                //foreach (var license in data.Context.Skip(1))
                //    stringBuilder.Append(", " + license.LicenseType.GetDescription());

                //return stringBuilder.ToString();
            }

            return cell.Data.ToString();
        }
    }
}