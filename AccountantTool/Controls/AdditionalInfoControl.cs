using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AccountantTool.Common;
using AccountantTool.Controls.Interfaces;
using AccountantTool.Helpers;
using AccountantTool.Model;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace AccountantTool.Controls
{
    public partial class AdditionalInfoControl : UserControl, INotifyControlDataSave
    {
        #region Properties
        public AdditionalInfo Model { get; }
        public List<FileInfo> LocalFiles { get; set; } = new List<FileInfo>();
        public bool IsEnglishLanguage => App.SelectedLanguage.Equals(App.Languages[0]);
        public bool IsDirty { get; set; }
        #endregion Properties

        public AdditionalInfoControl(AdditionalInfo model)
        {
            Model = model;
            InitializeComponent();

            txtNotes.Text = Model?.Notes;
            txtNotes.TextChanged += (sender, args) => IsDirty = true;

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

                IsDirty = true;
            };

            attachedFilesListView.MouseDoubleClick += AttachedFilesListView_MouseDoubleClick;

            IsDirty = false;
        }

        private void AttachedFilesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (attachedFilesListView.FocusedItem is null)
                return;

            var fullPathToFile = attachedFilesListView.FocusedItem.SubItems[1].Text;

            var startInfo = new ProcessStartInfo { FileName = fullPathToFile };

            var process = new Process { StartInfo = startInfo };
            process.Start();
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

                    if (!LocalFiles.Contains(fileInfo, new FileInfoEqualityComparer()))
                    {
                        LocalFiles.Add(fileInfo);
                        attachedFilesListView.Items.Add(new ListViewItem(new[] { fileInfo.Name, fileInfo.FullName }));
                    }
                }
            }

            IsDirty = true;
        }

        private void RemoveFileBtn_Click(object sender, EventArgs e)
        {
            #region For deleting from directory
            //var selectedItem = attachedFilesListView.FocusedItem;

            //var fullPathToFile = selectedItem.SubItems[1].Text;

            //if (File.Exists(fullPathToFile))
            //{
            //    File.Delete(fullPathToFile);
            //}

            //Model.AttachedFiles.RemoveAll(x => x.FullName == fullPathToFile);
            //LocalFiles.RemoveAll(x => x.FullName == fullPathToFile);
            #endregion For deleting from directory

            attachedFilesListView.Items.Remove(attachedFilesListView.FocusedItem);

            IsDirty = true;
        }

        private void PrintDocBtn_Click(object sender, EventArgs e)
        {
            if (attachedFilesListView.FocusedItem != null)
            {
                var fullPathToFile = attachedFilesListView.FocusedItem.SubItems[1].Text;
                //var fileName = attachedFilesListView.FocusedItem.SubItems[0].Text;

                try
                {
                    //https://ourcodeworld.com/articles/read/502/how-to-print-a-pdf-from-your-winforms-application-in-c-sharp
                    using (var printDialog = new PrintDialog())
                    {
                        printDialog.ShowDialog();
                        var info = new ProcessStartInfo
                        {
                            Verb = Constants.ProcessStartInfoVerb,
                            FileName = fullPathToFile,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                        };

                        var process = new Process { StartInfo = info };
                        process.Start();

                        //process.WaitForInputIdle();
                        //Thread.Sleep(3000);
                        //if (false == process.CloseMainWindow())
                        //    process.Kill();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"{(IsEnglishLanguage ? "Exception while printing:" : "Ошибка во время печати:")}" +
                                    Environment.NewLine +
                                    fullPathToFile, $"{(IsEnglishLanguage ? "Exception" : "Ошибка")}",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OkAddInfoBtn_Click(object sender, EventArgs e)
        {
            DoClose();
        }

        public void DoClose()
        {
            Model.Notes = txtNotes?.Text;

            if (attachedFilesListView.Items.Count == 0)
            {
                Model.AttachedFiles = new List<FileInfo>();
                return;
            }

            if (attachedFilesListView.Items.Count > 0)
            {
                Model.AttachedFiles = new List<FileInfo>(attachedFilesListView.Items.Count);

                foreach (ListViewItem item in attachedFilesListView.Items)
                {
                    var subItem = item.SubItems;
                    Model.AttachedFiles.Add(new FileInfo(subItem[1].Text));
                }
            }

            IsDirty = false;
        }
    }
}