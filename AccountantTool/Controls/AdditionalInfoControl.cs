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

            #region AddInfo table

            if (Model?.AddInfoTable != null)
            {
                foreach (var addInfo in Model.AddInfoTable)
                {
                    AddInfoListView.Items.Add(new ListViewItem(new[]
                    {
                        addInfo.NumberOfContract,
                        addInfo.Notes,
                        addInfo.OtherParticipants
                    }));
                }
            }

            AddInfoListView.EditTextBox.TextChanged += (sender, args) => IsDirty = true;
            #endregion AddInfo table

            if (!Directory.Exists(Constants.AdditionalDocumentsDirectory))
            {
                Directory.CreateDirectory(Constants.AdditionalDocumentsDirectory);
            }

            var dir = new DirectoryInfo(Constants.AdditionalDocumentsDirectory);
            var files = dir.GetFiles();

            if (Model?.AttachedFiles != null)
            {
                var result = Model.AttachedFiles.Intersect(files, new FileInfoEqualityComparer());

                attachedFilesListView.Items.AddRange(result.Select(c => new ListViewItem(new[]
                {
                    Model?.ContractFileInfo[c.FullName] ?? "Number of contract", c.Name, c.FullName
                })).ToArray());

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
                    .Select(c => new ListViewItem(new[] { Model?.ContractFileInfo[c.FullName] ?? "Number of contract", c.Name, c.FullName })).ToArray());

                IsDirty = true;
            };

            IsDirty = false;
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
                        attachedFilesListView.Items.Add(new ListViewItem(new[] { "Number of contract", fileInfo.Name, fileInfo.FullName }));
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

        private void OpenAttachedFileBtn_Click(object sender, EventArgs e)
        {
            if (attachedFilesListView.SelectedItem is null)
                return;

            var fullPathToFile = attachedFilesListView.FocusedItem.SubItems[2].Text;

            var startInfo = new ProcessStartInfo { FileName = fullPathToFile };

            var process = new Process { StartInfo = startInfo };
            process.Start();
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

        private void AddInfoBtn_Click(object sender, EventArgs e)
        {
            AddInfoListView.Items.Add(new ListViewItem(new[]
            {
                "Number of contract",
                "Notes",
                "Other participants"
            }));

            IsDirty = true;
        }

        private void RemoveInfoBtn_Click(object sender, EventArgs e)
        {
            AddInfoListView.Items.Remove(AddInfoListView.SelectedItem);

            IsDirty = true;
        }

        private void OkAddInfoBtn_Click(object sender, EventArgs e)
        {
            DoClose();
        }

        public void DoClose()
        {
            if (AddInfoListView.Items.Count != 0)
            {
                Model.AddInfoTable = new List<AddInfoTable>(AddInfoListView.Items.Count);

                foreach (ListViewItem item in AddInfoListView.Items)
                {
                    var subItem = item.SubItems;
                    Model.AddInfoTable.Add(new AddInfoTable
                    {
                        NumberOfContract = subItem[0]?.Text,
                        Notes = subItem[1]?.Text,
                        OtherParticipants = subItem[2]?.Text
                    });
                }
            }

            if (attachedFilesListView.Items.Count == 0)
            {
                Model.AttachedFiles = new List<FileInfo>();
            }

            if (attachedFilesListView.Items.Count > 0)
            {
                var capacity = attachedFilesListView.Items.Count;
                Model.AttachedFiles = new List<FileInfo>(capacity);
                Model.ContractFileInfo = new Dictionary<string, string>(capacity);

                foreach (ListViewItem item in attachedFilesListView.Items)
                {
                    var subItem = item.SubItems;
                    Model?.ContractFileInfo.Add(subItem[2].Text, subItem[0].Text);
                    Model.AttachedFiles.Add(new FileInfo(subItem[2].Text));
                }
            }

            IsDirty = false;
        }
    }
}