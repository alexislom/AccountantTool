using System;
using System.Drawing;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;

namespace AccountantTool.Helpers
{
    public class EditableListView : ListView
    {
        #region Fields
        private int _x;
        private int _y;
        private string _subItemText;
        private int _subItemSelected;
        #endregion Fields

        #region Properties
        public ListViewItem SelectedItem { get; private set; }
        public TextBox EditTextBox { get; } = new TextBox();
        #endregion Properties

        public EditableListView()
        {
            FullRowSelect = true;
            Size = new Size(0, 0);
            TabIndex = 0;
            View = System.Windows.Forms.View.Details;
            MouseDown += OnMouseDown;
            DoubleClick += OnDoubleClick;
            GridLines = true;

            // Increase ListView row height-------------------------------------------
            // https://dotnet-snippets.de/snippet/zeilenhoehe-in-listview-aendern/1704
            var imageList = new ImageList
            {
                ImageSize = new Size(1, 60),
                TransparentColor = Color.Transparent
            };
            SmallImageList = imageList;
            //------------------------------------------------------------------------

            EditTextBox.Multiline = true;
            EditTextBox.Size = new Size(0, 0);
            EditTextBox.Location = new Point(0, 0);
            Controls.AddRange(new Control[] { EditTextBox });
            EditTextBox.KeyPress += EditOver;
            EditTextBox.LostFocus += FocusOver;
            EditTextBox.BackColor = Color.LightYellow;
            EditTextBox.BorderStyle = BorderStyle.Fixed3D;
            EditTextBox.Hide();
            EditTextBox.Text = string.Empty;
        }

        #region Event handlers

        private void EditOver(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                SelectedItem.SubItems[_subItemSelected].Text = EditTextBox.Text;
                //_editBox.Hide();
            }

            if (e.KeyChar == (int)Keys.Escape)
                EditTextBox.Hide();
        }

        private void FocusOver(object sender, EventArgs e)
        {
            SelectedItem.SubItems[_subItemSelected].Text = EditTextBox.Text;
            EditTextBox.Hide();
        }

        public void OnDoubleClick(object sender, EventArgs e)
        {
            // Check the subitem clicked .
            var nStart = _x;
            var spos = 0;
            var epos = Columns[0].Width;
            for (var i = 0; i < Columns.Count; i++)
            {
                if (nStart > spos && nStart < epos)
                {
                    _subItemSelected = i;
                    break;
                }

                spos = epos;
                epos += Columns[i].Width;
            }

            //double assignment of text property
            //TODO: fix it
            _subItemText = SelectedItem.SubItems[_subItemSelected].Text;

            //var r = new Rectangle(spos, SelectedItem.Bounds.Y, epos, SelectedItem.Bounds.Bottom);
            EditTextBox.Size = new Size(epos - spos, SelectedItem.Bounds.Bottom - SelectedItem.Bounds.Top);
            EditTextBox.Location = new Point(spos, SelectedItem.Bounds.Y);
            EditTextBox.Show();
            EditTextBox.Text = _subItemText;
            EditTextBox.SelectAll();
            EditTextBox.Focus();
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            SelectedItem = GetItemAt(e.X, e.Y);
            _x = e.X;
            _y = e.Y;
        }

        #endregion Event handlers
    }
}