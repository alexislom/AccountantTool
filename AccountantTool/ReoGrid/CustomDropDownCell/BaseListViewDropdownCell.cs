using System;
using System.Diagnostics;
using System.Windows.Forms;
using AccountantTool.Controls.Interfaces;
using unvell.ReoGrid.CellTypes;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public abstract class BaseListViewDropdownCell : DropdownCell
    {
        protected BaseListViewDropdownCell(Control control)
        {
            DropdownControl = control;
            DropdownClosed += OnDropdownClosed;

            MinimumDropdownWidth = DropdownControl.Width;
            DropdownPanelHeight = DropdownControl.Height;
        }

        #region Dropdown event handle

        private void OnDropdownClosed(object sender, EventArgs e)
        {
            if (DropdownControl is INotifyControlDataSave control && control.IsDirty)
            {
                control.DoClose();
                Debug.WriteLine("Close dropdown cell of type: " + DropdownControl.GetType(), "Dropdown cell event handle");
            }
        }

        protected override void OnDropdownControlLostFocus()
        {
            if (!DropdownControl.Visible)
            {
                base.OnDropdownControlLostFocus();
            }
        }

        public override void OnLostFocus()
        {
            if (!DropdownControl.Visible)
            {
                base.OnLostFocus();
            }
        }

        #endregion Dropdown event handle
    }
}