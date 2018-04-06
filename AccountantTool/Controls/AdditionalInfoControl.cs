using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AccountantTool.Common;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class AdditionalInfoControl : UserControl
    {
        public AdditionalInfo Model { get; }

        IEnumerable<string> Files { get; set; }
        private string _lastUpdateText;

        public AdditionalInfoControl(AdditionalInfo model)
        {
            Model = model;
            InitializeComponent();
            txtNotes.Text = Model?.Notes;

            if (!Directory.Exists(Constants.AdditionalDocumentsDirectory))
            {
                Directory.CreateDirectory(Constants.AdditionalDocumentsDirectory);
            }

            Files = Directory.GetFiles(Constants.AdditionalDocumentsDirectory);
            Files = Files.Select(Path.GetFileName).ToList();
            cbAttachedDocuments.DataSource = Files;
            cbAttachedDocuments.SelectedIndex = -1;

            //Cursor.Current = Cursors.Default;

            // OnTextChanged event for combo box
            cbAttachedDocuments.TextChanged += CbAttachedDocumentsOnTextChanged;

            // OnTextUpdate event for combo box
            cbAttachedDocuments.TextUpdate += CbAttachedDocuments_TextUpdate;

            cbAttachedDocuments.SelectedIndexChanged += (sender, args) =>
            {
                cbAttachedDocuments.SelectedIndex = -1;
            };
        }

        private void CbAttachedDocuments_TextUpdate(object sender, EventArgs e)
        {
            string filter_param = cbAttachedDocuments.Text;

            var filteredItems = Files.ToList().FindAll(x => x.ToLowerInvariant().Contains(filter_param.ToLowerInvariant()));

            cbAttachedDocuments.DataSource = filteredItems;

            if (string.IsNullOrWhiteSpace(filter_param))
            {
                cbAttachedDocuments.DataSource = Files;
            }
            cbAttachedDocuments.DroppedDown = true;
            Cursor.Current = Cursors.Default;

            // this will ensure that the drop down is as long as the list
            cbAttachedDocuments.IntegralHeight = true;

            // remove automatically selected first item
            cbAttachedDocuments.SelectedIndex = -1;

            cbAttachedDocuments.Text = filter_param;

            // set the position of the cursor
            cbAttachedDocuments.SelectionStart = filter_param.Length;
            cbAttachedDocuments.SelectionLength = 0;
        }

        private void CbAttachedDocumentsOnTextChanged(object sender, EventArgs eventArgs)
        {
            if (Files != null && !string.IsNullOrEmpty(cbAttachedDocuments.Text))
            {
                string filter_param = cbAttachedDocuments.Text.ToLowerInvariant();

                var filteredItems = Files.ToList().FindAll(x => x.Contains(filter_param));

                cbAttachedDocuments.DataSource = filteredItems;

                // if all values removed, bind the original full list again
                if (string.IsNullOrEmpty(cbAttachedDocuments.Text))
                {
                    cbAttachedDocuments.DataSource = Files;
                }
            }

            //if (Files != null && !string.IsNullOrEmpty(cbAttachedDocuments.Text))
            //{
            //    var txt = cbAttachedDocuments.Text.ToLowerInvariant();
            //    if (_lastUpdateText != txt)
            //    {
            //        _lastUpdateText = txt;
            //        var ds = Files.Where(t => t.ToLowerInvariant().Contains(txt));
            //        if (ds.Any())
            //        {
            //            // cbAttachedDocuments.DataSource = ds.ToList();
            //        }
            //        else
            //        {
            //            cbAttachedDocuments.DataSource = Files;
            //        }

            //        cbAttachedDocuments.DroppedDown = true;
            //        cbAttachedDocuments.IntegralHeight = true;
            //        cbAttachedDocuments.SelectedIndex = -1;

            //        // cbAttachedDocuments.Text = txt;

            //        cbAttachedDocuments.SelectionStart = txt.Length;
            //        cbAttachedDocuments.SelectionLength = 0;
            //    }
            //}
        }

        private void OkAddInfoBtn_Click(object sender, EventArgs e)
        {
            Model.Notes = txtNotes?.Text;
        }
    }
}