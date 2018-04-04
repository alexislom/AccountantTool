using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountantTool.Helpers
{
    public class EditableListView : ListView
    {
        #region Fields
        private int _x;
        private int _y;
        private string _subItemText;
        private int _subItemSelected;
        private readonly TextBox _editBox = new TextBox();
        #endregion Fields

        #region Properties
        public ListViewItem SelectedItem { get; private set; }
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

            _editBox.Size = new Size(0, 0);
            _editBox.Location = new Point(0, 0);
            Controls.AddRange(new Control[] { _editBox });
            _editBox.KeyPress += EditOver;
            _editBox.LostFocus += FocusOver;
            _editBox.BackColor = Color.LightYellow;
            _editBox.BorderStyle = BorderStyle.Fixed3D;
            _editBox.Hide();
            _editBox.Text = string.Empty;
        }

        #region Event handlers

        private void EditOver(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectedItem.SubItems[_subItemSelected].Text = _editBox.Text;
                _editBox.Hide();
            }

            if (e.KeyChar == 27)
                _editBox.Hide();
        }

        private void FocusOver(object sender, EventArgs e)
        {
            SelectedItem.SubItems[_subItemSelected].Text = _editBox.Text;
            _editBox.Hide();
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

            _subItemText = SelectedItem.SubItems[_subItemSelected].Text;

            //var r = new Rectangle(spos, SelectedItem.Bounds.Y, epos, SelectedItem.Bounds.Bottom);
            _editBox.Size = new Size(epos - spos, SelectedItem.Bounds.Bottom - SelectedItem.Bounds.Top);
            _editBox.Location = new Point(spos, SelectedItem.Bounds.Y);
            _editBox.Show();
            _editBox.Text = _subItemText;
            _editBox.SelectAll();
            _editBox.Focus();
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