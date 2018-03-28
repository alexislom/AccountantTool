using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DropDownButtonLib.Controls;
using unvell.ReoGrid;
using unvell.ReoGrid.CellTypes;
using unvell.ReoGrid.Events;
using unvell.ReoGrid.Graphics;
using unvell.ReoGrid.Interaction;
using unvell.ReoGrid.Rendering;
using DrawingContext = System.Windows.Media.DrawingContext;
using Point = unvell.ReoGrid.Graphics.Point;
using Size = unvell.ReoGrid.Graphics.Size;

namespace AccountantTool.ReoGrid.CustomDropDownCell
{
    public class ContentControlWrapper : ContentControl
    {
        private readonly ContentControl _contentControl;

        public ContentControlWrapper(ContentControl contentControl)
        {
            Content = contentControl;
            _contentControl = contentControl;
        }

        internal void DoRender(DrawingContext platformGraphics, Cell cell)
        {
            //this.Width = 100;
            //this.Height = 30;

            var w = cell.Worksheet.ColumnHeaders[cell.Column].Width;
            var h = cell.Worksheet.RowHeaders[cell.Row].Height;

            _contentControl.Width = w; //100;
            _contentControl.Height = h; // 30;
            Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
            Arrange(new Rect(DesiredSize));
            var bmp = new RenderTargetBitmap(w, h, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(this);
            platformGraphics.DrawImage(bmp, new Rect(DesiredSize));
        }

        internal void OnMouseDownClick(CellMouseEventArgs e)
        {
            var s = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
            {
                RoutedEvent = Mouse.MouseDownEvent,
                Source = this,
            };
            this.OnMouseDown(s);
            s = new MouseButtonEventArgs(Mouse.PrimaryDevice, 300, MouseButton.Left)
            {
                RoutedEvent = Mouse.MouseUpEvent,
                Source = this,
            };
            this.OnMouseUp(s);

            //this.RaiseEvent(new RoutedEventArgs(DropDownButton.ClickEvent, this));
            //RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
            //{
            //    RoutedEvent = Mouse.MouseDownEvent,
            //    Source = this,
            //});
        }
    }

    public class CustomDropdownListViewCell : CellBody
    {
        private DropdownWindow _dropdownPanel;

        /// <summary>
        /// Get dropdown panel.
        /// </summary>
        protected DropdownWindow DropdownPanel => _dropdownPanel;

        /// <summary>
        /// Determines whether or not to open the drop-down panel when user clicked inside cell.
        /// </summary>
        public virtual bool PullDownOnClick { get; set; } = true;

        private Size dropdownButtonSize = new Size(20, 20);

        /// <summary>
        /// Get or set the drop-down button size.
        /// </summary>
        public virtual Size DropdownButtonSize
        {
            get => dropdownButtonSize;
            set => dropdownButtonSize = value;
        }

        private bool dropdownButtonAutoHeight = true;

        /// <summary>
        /// Determines whether or not to adjust the height of drop-down button to fit entire cell.
        /// </summary>
        public virtual bool DropdownButtonAutoHeight
        {
            get => dropdownButtonAutoHeight;
            set { dropdownButtonAutoHeight = value; OnBoundsChanged(); }
        }

        private Rectangle dropdownButtonRect = new Rectangle(0, 0, 20, 20);

        /// <summary>
        /// Get the drop-down button bounds.
        /// </summary>
        protected Rectangle DropdownButtonRect => dropdownButtonRect;

        /// <summary>
        /// Get or set the control in drop-down panel.
        /// </summary>
        public virtual ContentControlWrapper DropdownControl { get; set; }

        /// <summary>
        /// Override method to handle the event when drop-down control lost focus.
        /// </summary>
        protected virtual void OnDropdownControlLostFocus()
        {
            PullUp();
        }

        private bool isDropdown;

        /// <summary>
        /// Get or set whether the drop-down button is pressed. When this value is set to true, the drop-down panel will popped up.
        /// </summary>
        public bool IsDropdown
        {
            get => isDropdown;
            set
            {
                if (isDropdown != value)
                {
                    if (value)
                    {
                        //PushDown();
                    }
                    else
                    {
                        PullUp();
                    }
                }
            }
        }

        /// <summary>
        /// Create custom drop-down cell instance.
        /// </summary>
        public CustomDropdownListViewCell()
        {
        }

        /// <summary>
        /// Process boundary changes.
        /// </summary>
        public override void OnBoundsChanged()
        {
            dropdownButtonRect.Width = dropdownButtonSize.Width;

            if (dropdownButtonRect.Width > Bounds.Width)
            {
                dropdownButtonRect.Width = Bounds.Width;
            }
            else if (dropdownButtonRect.Width < 3)
            {
                dropdownButtonRect.Width = 3;
            }

            if (dropdownButtonAutoHeight)
            {
                dropdownButtonRect.Height = Bounds.Height - 1;
            }
            else
            {
                dropdownButtonRect.Height = Math.Min(DropdownButtonSize.Height, Bounds.Height - 1);
            }

            dropdownButtonRect.X = Bounds.Right - dropdownButtonRect.Width;

            var valign = ReoGridVerAlign.General;

            //if (this.Cell != null && this.Cell.InnerStyle != null
            //    && this.Cell.InnerStyle.HasStyle(PlainStyleFlag.VerticalAlign))
            //{
            //    valign = this.Cell.InnerStyle.VAlign;
            //}

            switch (valign)
            {
                case ReoGridVerAlign.Top:
                    dropdownButtonRect.Y = 1;
                    break;

                case ReoGridVerAlign.General:
                case ReoGridVerAlign.Bottom:
                    dropdownButtonRect.Y = Bounds.Bottom - dropdownButtonRect.Height;
                    break;

                case ReoGridVerAlign.Middle:
                    dropdownButtonRect.Y = Bounds.Top + (Bounds.Height - dropdownButtonRect.Height) / 2 + 1;
                    break;
            }
        }

        /// <summary>
        /// Paint the dropdown button inside cell.
        /// </summary>
        /// <param name="dc">Platform no-associated drawing context instance.</param>
        public override void OnPaint(CellDrawingContext dc)
        {
            // call base to draw cell background and text
            base.OnPaint(dc);

            //DropdownControl.DoRender(dc.Graphics.PlatformGraphics, Cell);

            // draw button surface
            // this.OnPaintDropdownButton(dc, this.dropdownButtonRect);
        }

        /// <summary>
        /// Draw the drop-down button surface.
        /// </summary>
        /// <param name="dc">ReoGrid cross-platform drawing context.</param>
        ///// <param name="buttonRect">Rectangle of drop-down button.</param>
        //protected virtual void OnPaintDropdownButton(CellDrawingContext dc, Rectangle buttonRect)
        //{
        //    if (this.Cell != null)
        //    {
        //        if (this.Cell.IsReadOnly)
        //        {
        //            ControlPaint.DrawComboButton(dc.Graphics.PlatformGraphics, (System.Drawing.Rectangle)(buttonRect),
        //                System.Windows.Forms.ButtonState.Inactive);
        //        }
        //        else
        //        {
        //            ControlPaint.DrawComboButton(dc.Graphics.PlatformGraphics, (System.Drawing.Rectangle)(buttonRect),
        //                this.isDropdown ? System.Windows.Forms.ButtonState.Pushed : System.Windows.Forms.ButtonState.Normal);
        //        }
        //    }
        //}

        /// <summary>
        /// Process when mouse button pressed inside cell.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool OnMouseDown(CellMouseEventArgs e)
        {
            if (PullDownOnClick || dropdownButtonRect.Contains(e.RelativePosition))
            {
                DropdownControl.OnMouseDownClick(e);
                //PushDown();
                //if (isDropdown)
                //{
                //    PullUp();
                //}
                //else
                //{
                //    //PushDown();
                //}

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Handle event when mouse moving inside this cell body.
        /// </summary>
        /// <param name="e">Argument of mouse moving event.</param>
        /// <returns>True if event has been handled; Otherwise return false.</returns>
        public override bool OnMouseMove(CellMouseEventArgs e)
        {
            if (dropdownButtonRect.Contains(e.RelativePosition))
            {
                e.CursorStyle = CursorStyle.Hand;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Handle event if cell has lost focus.
        /// </summary>
        public override void OnLostFocus()
        {
            PullUp();
        }

        /// <summary>
        /// Event rasied when dropdown-panel is opened.
        /// </summary>
        public event EventHandler DropdownOpened;

        /// <summary>
        /// Event raised when dropdown-panel is closed.
        /// </summary>
        public event EventHandler DropdownClosed;

        /// <summary>
        /// Open dropdown panel when cell enter edit mode.
        /// </summary>
        /// <returns>True if edit operation is allowed; otherwise return false to abort edit.</returns>
        public override bool OnStartEdit()
        {
            //PushDown();
            return false;
        }

        private Worksheet sheet;

        /// <summary>
        /// Push down to open the dropdown panel.
        /// </summary>
        //public virtual void PushDown()
        //{
        //    if (Cell == null && Cell.Worksheet == null) return;

        //    if (Cell.IsReadOnly && DisableWhenCellReadonly)
        //    {
        //        return;
        //    }

        //    sheet = Cell?.Worksheet;

        //    if (sheet != null && DropdownControl != null)
        //        //&& Views.CellsViewport.TryGetCellPositionToControl(sheet.ViewportController.FocusView, this.Cell.InternalPos, out Point p))
        //    {
        //        if (this._dropdownPanel == null)
        //        {
        //            this._dropdownPanel = new DropdownWindow(this);
        //            //dropdown.VisibleChanged += dropdown_VisibleChanged;

        //            //this.dropdownPanel.LostFocus -= DropdownControl_LostFocus;
        //            //this.dropdownPanel.OwnerItem = this.dropdownControl;
        //            //this.dropdownPanel.VisibleChanged += DropdownPanel_VisibleChanged;
        //            _dropdownPanel.LostFocus += DropdownPanel_VisibleChanged;
        //        }

        //        this._dropdownPanel.Width = Math.Max((int)Math.Round(Bounds.Width * sheet.ScaleFactor), MinimumDropdownWidth);
        //        this._dropdownPanel.Height = DropdownPanelHeight;

        //        //this.dropdownPanel.Show(sheet.Workbook.ControlInstance,
        //        //    new System.Drawing.Point((int)Math.Round(p.X), (int)Math.Round(p.Y + Bounds.Height * sheet.ScaleFactor)));

        //        this.DropdownControl.Focus();

        //        this.isDropdown = true;
        //    }

        //    DropdownOpened?.Invoke(this, null);
        //}

        private void DropdownPanel_VisibleChanged(object sender, EventArgs e)
        {
            OnDropdownControlLostFocus();
        }

        /// <summary>
        /// Get or set height of dropdown-panel
        /// </summary>
        public virtual int DropdownPanelHeight { get; set; } = 200;

        /// <summary>
        /// Minimum width of dropdown panel
        /// </summary>
        public virtual int MinimumDropdownWidth { get; set; } = 120;

        /// <summary>
        /// Close condidate list
        /// </summary>
        public virtual void PullUp()
        {
            if (_dropdownPanel != null)
            {
                _dropdownPanel.Hide();

                isDropdown = false;

                sheet?.RequestInvalidate();
            }

            DropdownClosed?.Invoke(this, null);
        }

        #region Dropdown Window

        /// <summary>
        /// Prepresents dropdown window for dropdown cells.
        /// </summary>
        protected class DropdownWindow : System.Windows.Controls.Primitives.Popup
        {
            private CustomDropdownListViewCell _owner;

            public DropdownWindow(CustomDropdownListViewCell owner)
            {
                _owner = owner;
            }

            public void Hide()
            {
                IsOpen = false;
            }
        }

        #endregion Dropdown Window
    }
}