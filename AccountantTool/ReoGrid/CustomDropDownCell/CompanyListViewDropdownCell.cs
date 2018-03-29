﻿using AccountantTool.Controls;
using AccountantTool.Model;
using unvell.ReoGrid.CellTypes;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public sealed class CompanyListViewDropdownCell : DropdownCell
    {
        public CompanyListViewDropdownCell(Company model)
        {
            DropdownControl = new CompanyControl(model);

            MinimumDropdownWidth = DropdownControl.Width;
            DropdownPanelHeight = DropdownControl.Height;
        }
    }
}