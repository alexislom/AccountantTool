using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace AccountantTool.Controls
{
    public partial class AdditionalInfoControl : UserControl
    {
        public AdditionalInfo Model { get; }

        IEnumerable<string> AllFiles { get; set; }
        //private string _lastUpdateText;

        public List<FileInfo> LocalFiles { get; set; } = new List<FileInfo>();

        public AdditionalInfoControl(AdditionalInfo model)
        {
            Model = model;
            InitializeComponent();

            txtNotes.Text = Model?.Notes;

            if (!Directory.Exists(Constants.AdditionalDocumentsDirectory))
            {
                Directory.CreateDirectory(Constants.AdditionalDocumentsDirectory);
            }

            var dir = new DirectoryInfo(Constants.AdditionalDocumentsDirectory);
            var files = dir.GetFiles();

            if (Model?.AttachedFiles != null)
            {
                var result = Model.AttachedFiles.Intersect(files, new FileInfoEqualityComparer());

                attachedFilesListView.Items.AddRange(result.Select(c => new ListViewItem(new[] { c.Name, c.FullName })).ToArray());

                foreach (var item in result)
                {
                    LocalFiles.Add(new FileInfo(item.FullName));
                }
            }
            else
            {
                Model.AttachedFiles = new List<FileInfo>();
            }

            searchTextBox.TextChanged += (sender, args) =>
            {
                attachedFilesListView.Items.Clear(); // clear list items before adding 
                // filter the items match with search key and add result to list view 

                attachedFilesListView.Items.AddRange(LocalFiles
                    .Where(i => string.IsNullOrEmpty(searchTextBox.Text.ToLowerInvariant())
                                || i.Name.ToLowerInvariant().Contains(searchTextBox.Text.ToLowerInvariant()))
                    .Select(c => new ListViewItem(new[] { c.Name, c.FullName })).ToArray());
            };

            #region Comments
            /*

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

            */
            #endregion
        }

        private void AddFileBtn_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                if (!Directory.Exists(Constants.AdditionalDocumentsDirectory))
                {
                    Directory.CreateDirectory(Constants.AdditionalDocumentsDirectory);
                }

                foreach (var ofdFileName in openFileDialog.FileNames)
                {
                    var possiblePathToFile = Path.GetFullPath(Path.Combine(Constants.AdditionalDocumentsDirectory + "/" + Path.GetFileName(ofdFileName)));

                    if (!File.Exists(possiblePathToFile))
                    {
                        File.Copy(ofdFileName, possiblePathToFile);
                    }

                    var fileInfo = new FileInfo(possiblePathToFile);

                    Model.AttachedFiles.Add(fileInfo);
                    LocalFiles.Add(fileInfo);
                    attachedFilesListView.Items.Add(new ListViewItem(new[] { fileInfo.Name, fileInfo.FullName }));
                }
            }
        }

        private void RemoveFileBtn_Click(object sender, EventArgs e)
        {
            #region For deleting
            //var selectedItem = attachedFilesListView.FocusedItem;

            //var fullPathToFile = selectedItem.SubItems[1].Text;

            //if (File.Exists(fullPathToFile))
            //{
            //    File.Delete(fullPathToFile);
            //}

            //Model.AttachedFiles.RemoveAll(x => x.FullName == fullPathToFile);
            //LocalFiles.RemoveAll(x => x.FullName == fullPathToFile);
            #endregion For deleting

            attachedFilesListView.Items.Remove(attachedFilesListView.FocusedItem);
        }

        private void OkAddInfoBtn_Click(object sender, EventArgs e)
        {
            Model.Notes = txtNotes?.Text;

            if (attachedFilesListView.Items.Count != 0)
            {
                Model.AttachedFiles = new List<FileInfo>(attachedFilesListView.Items.Count);

                foreach (ListViewItem item in attachedFilesListView.Items)
                {
                    var subItem = item.SubItems;
                    Model.AttachedFiles.Add(new FileInfo(subItem[1].Text));
                }
            }
        }


        private void CbAttachedDocuments_TextUpdate(object sender, EventArgs e)
        {
            string filter_param = cbAttachedDocuments.Text;

            var filteredItems = AllFiles.ToList().FindAll(x => x.ToLowerInvariant().Contains(filter_param.ToLowerInvariant()));

            cbAttachedDocuments.DataSource = filteredItems;

            if (string.IsNullOrWhiteSpace(filter_param))
            {
                cbAttachedDocuments.DataSource = AllFiles;
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
            if (AllFiles != null && !string.IsNullOrEmpty(cbAttachedDocuments.Text))
            {
                string filter_param = cbAttachedDocuments.Text.ToLowerInvariant();

                var filteredItems = AllFiles.ToList().FindAll(x => x.Contains(filter_param));

                cbAttachedDocuments.DataSource = filteredItems;

                // if all values removed, bind the original full list again
                if (string.IsNullOrEmpty(cbAttachedDocuments.Text))
                {
                    cbAttachedDocuments.DataSource = AllFiles;
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
    }
}