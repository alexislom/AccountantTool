namespace AccountantTool.Controls
{
    partial class AdditionalInfoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAttachedDocuments = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.OkAddInfoBtn = new System.Windows.Forms.Button();
            this.attachedFilesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.RemoveFileBtn = new System.Windows.Forms.Button();
            this.AddFileBtn = new System.Windows.Forms.Button();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddInfoGroupBox
            // 
            this.AddInfoGroupBox.Controls.Add(this.label2);
            this.AddInfoGroupBox.Controls.Add(this.cbAttachedDocuments);
            this.AddInfoGroupBox.Controls.Add(this.label1);
            this.AddInfoGroupBox.Controls.Add(this.txtNotes);
            this.AddInfoGroupBox.Location = new System.Drawing.Point(13, 15);
            this.AddInfoGroupBox.Name = "AddInfoGroupBox";
            this.AddInfoGroupBox.Size = new System.Drawing.Size(410, 103);
            this.AddInfoGroupBox.TabIndex = 5;
            this.AddInfoGroupBox.TabStop = false;
            this.AddInfoGroupBox.Text = "Дополнительная информация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Документы";
            // 
            // cbAttachedDocuments
            // 
            this.cbAttachedDocuments.FormattingEnabled = true;
            this.cbAttachedDocuments.Location = new System.Drawing.Point(158, 63);
            this.cbAttachedDocuments.Name = "cbAttachedDocuments";
            this.cbAttachedDocuments.Size = new System.Drawing.Size(216, 21);
            this.cbAttachedDocuments.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Примечания";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(158, 23);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(216, 20);
            this.txtNotes.TabIndex = 0;
            // 
            // OkAddInfoBtn
            // 
            this.OkAddInfoBtn.Location = new System.Drawing.Point(339, 378);
            this.OkAddInfoBtn.Name = "OkAddInfoBtn";
            this.OkAddInfoBtn.Size = new System.Drawing.Size(84, 48);
            this.OkAddInfoBtn.TabIndex = 6;
            this.OkAddInfoBtn.Text = "Ok";
            this.OkAddInfoBtn.UseVisualStyleBackColor = true;
            this.OkAddInfoBtn.Click += new System.EventHandler(this.OkAddInfoBtn_Click);
            // 
            // attachedFilesListView
            // 
            this.attachedFilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attachedFilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.attachedFilesListView.FullRowSelect = true;
            this.attachedFilesListView.GridLines = true;
            this.attachedFilesListView.Location = new System.Drawing.Point(13, 177);
            this.attachedFilesListView.Name = "attachedFilesListView";
            this.attachedFilesListView.Size = new System.Drawing.Size(410, 193);
            this.attachedFilesListView.TabIndex = 7;
            this.attachedFilesListView.UseCompatibleStateImageBehavior = false;
            this.attachedFilesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Прикреплённые файлы";
            this.columnHeader1.Width = 198;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(171, 135);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(216, 20);
            this.searchTextBox.TabIndex = 8;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(32, 138);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(39, 13);
            this.SearchLabel.TabIndex = 9;
            this.SearchLabel.Text = "Поиск";
            // 
            // RemoveFileBtn
            // 
            this.RemoveFileBtn.Location = new System.Drawing.Point(146, 378);
            this.RemoveFileBtn.Name = "RemoveFileBtn";
            this.RemoveFileBtn.Size = new System.Drawing.Size(75, 48);
            this.RemoveFileBtn.TabIndex = 13;
            this.RemoveFileBtn.Text = "Удалить файл";
            this.RemoveFileBtn.UseVisualStyleBackColor = true;
            this.RemoveFileBtn.Click += new System.EventHandler(this.RemoveFileBtn_Click);
            // 
            // AddFileBtn
            // 
            this.AddFileBtn.Location = new System.Drawing.Point(13, 378);
            this.AddFileBtn.Name = "AddFileBtn";
            this.AddFileBtn.Size = new System.Drawing.Size(85, 48);
            this.AddFileBtn.TabIndex = 12;
            this.AddFileBtn.Text = "Прикрепить файл";
            this.AddFileBtn.UseVisualStyleBackColor = true;
            this.AddFileBtn.Click += new System.EventHandler(this.AddFileBtn_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Путь к файлу";
            this.columnHeader2.Width = 186;
            // 
            // AdditionalInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RemoveFileBtn);
            this.Controls.Add(this.AddFileBtn);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.attachedFilesListView);
            this.Controls.Add(this.OkAddInfoBtn);
            this.Controls.Add(this.AddInfoGroupBox);
            this.Name = "AdditionalInfoControl";
            this.Size = new System.Drawing.Size(437, 434);
            this.AddInfoGroupBox.ResumeLayout(false);
            this.AddInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AddInfoGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button OkAddInfoBtn;
        private System.Windows.Forms.ComboBox cbAttachedDocuments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView attachedFilesListView;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button RemoveFileBtn;
        private System.Windows.Forms.Button AddFileBtn;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
