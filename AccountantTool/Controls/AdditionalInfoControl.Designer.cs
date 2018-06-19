using AccountantTool.Helpers;

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
            this.components = new System.ComponentModel.Container();
            this.AddInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.RemoveInfoBtn = new System.Windows.Forms.Button();
            this.AddInfoBtn = new System.Windows.Forms.Button();
            this.AddInfoListView = new AccountantTool.Helpers.EditableListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.attachedFilesListView = new AccountantTool.Helpers.EditableListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.OkAddInfoBtn = new System.Windows.Forms.Button();
            this.RemoveFileBtn = new System.Windows.Forms.Button();
            this.AddFileBtn = new System.Windows.Forms.Button();
            this.PrintDocBtn = new System.Windows.Forms.Button();
            this.OpenAttachedFileBtn = new System.Windows.Forms.Button();
            this.AddInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddInfoGroupBox
            // 
            this.AddInfoGroupBox.Controls.Add(this.RemoveInfoBtn);
            this.AddInfoGroupBox.Controls.Add(this.AddInfoBtn);
            this.AddInfoGroupBox.Controls.Add(this.AddInfoListView);
            this.AddInfoGroupBox.Controls.Add(this.attachedFilesListView);
            this.AddInfoGroupBox.Controls.Add(this.SearchLabel);
            this.AddInfoGroupBox.Controls.Add(this.searchTextBox);
            this.AddInfoGroupBox.Location = new System.Drawing.Point(13, 15);
            this.AddInfoGroupBox.Name = "AddInfoGroupBox";
            this.AddInfoGroupBox.Size = new System.Drawing.Size(568, 437);
            this.AddInfoGroupBox.TabIndex = 5;
            this.AddInfoGroupBox.TabStop = false;
            this.AddInfoGroupBox.Text = "Дополнительная информация";
            // 
            // RemoveInfoBtn
            // 
            this.RemoveInfoBtn.Location = new System.Drawing.Point(325, 175);
            this.RemoveInfoBtn.Name = "RemoveInfoBtn";
            this.RemoveInfoBtn.Size = new System.Drawing.Size(116, 48);
            this.RemoveInfoBtn.TabIndex = 15;
            this.RemoveInfoBtn.Text = "Удалить информацию";
            this.RemoveInfoBtn.UseVisualStyleBackColor = true;
            this.RemoveInfoBtn.Click += new System.EventHandler(this.RemoveInfoBtn_Click);
            // 
            // AddInfoBtn
            // 
            this.AddInfoBtn.Location = new System.Drawing.Point(94, 175);
            this.AddInfoBtn.Name = "AddInfoBtn";
            this.AddInfoBtn.Size = new System.Drawing.Size(117, 48);
            this.AddInfoBtn.TabIndex = 14;
            this.AddInfoBtn.Text = "Добавить информацию";
            this.AddInfoBtn.UseVisualStyleBackColor = true;
            this.AddInfoBtn.Click += new System.EventHandler(this.AddInfoBtn_Click);
            // 
            // AddInfoListView
            // 
            this.AddInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.AddInfoListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddInfoListView.FullRowSelect = true;
            this.AddInfoListView.GridLines = true;
            this.AddInfoListView.Location = new System.Drawing.Point(22, 19);
            this.AddInfoListView.Name = "AddInfoListView";
            this.AddInfoListView.Size = new System.Drawing.Size(532, 150);
            this.AddInfoListView.TabIndex = 10;
            this.AddInfoListView.UseCompatibleStateImageBehavior = false;
            this.AddInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Номер контракта";
            this.columnHeader3.Width = 138;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Примечания";
            this.columnHeader5.Width = 250;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Иные участники";
            this.columnHeader6.Width = 127;
            // 
            // attachedFilesListView
            // 
            this.attachedFilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2});
            this.attachedFilesListView.FullRowSelect = true;
            this.attachedFilesListView.GridLines = true;
            this.attachedFilesListView.Location = new System.Drawing.Point(22, 266);
            this.attachedFilesListView.Name = "attachedFilesListView";
            this.attachedFilesListView.Size = new System.Drawing.Size(532, 165);
            this.attachedFilesListView.TabIndex = 7;
            this.attachedFilesListView.UseCompatibleStateImageBehavior = false;
            this.attachedFilesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Номер контракта";
            this.columnHeader4.Width = 104;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Прикреплённый файл";
            this.columnHeader1.Width = 162;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Путь к файлу";
            this.columnHeader2.Width = 258;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(46, 240);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(39, 13);
            this.SearchLabel.TabIndex = 9;
            this.SearchLabel.Text = "Поиск";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(148, 240);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(406, 20);
            this.searchTextBox.TabIndex = 8;
            // 
            // OkAddInfoBtn
            // 
            this.OkAddInfoBtn.Location = new System.Drawing.Point(483, 458);
            this.OkAddInfoBtn.Name = "OkAddInfoBtn";
            this.OkAddInfoBtn.Size = new System.Drawing.Size(84, 48);
            this.OkAddInfoBtn.TabIndex = 6;
            this.OkAddInfoBtn.Text = "Ok";
            this.OkAddInfoBtn.UseVisualStyleBackColor = true;
            this.OkAddInfoBtn.Click += new System.EventHandler(this.OkAddInfoBtn_Click);
            // 
            // RemoveFileBtn
            // 
            this.RemoveFileBtn.Location = new System.Drawing.Point(137, 458);
            this.RemoveFileBtn.Name = "RemoveFileBtn";
            this.RemoveFileBtn.Size = new System.Drawing.Size(75, 48);
            this.RemoveFileBtn.TabIndex = 13;
            this.RemoveFileBtn.Text = "Удалить файл";
            this.RemoveFileBtn.UseVisualStyleBackColor = true;
            this.RemoveFileBtn.Click += new System.EventHandler(this.RemoveFileBtn_Click);
            // 
            // AddFileBtn
            // 
            this.AddFileBtn.Location = new System.Drawing.Point(13, 458);
            this.AddFileBtn.Name = "AddFileBtn";
            this.AddFileBtn.Size = new System.Drawing.Size(85, 48);
            this.AddFileBtn.TabIndex = 12;
            this.AddFileBtn.Text = "Прикрепить файл";
            this.AddFileBtn.UseVisualStyleBackColor = true;
            this.AddFileBtn.Click += new System.EventHandler(this.AddFileBtn_Click);
            // 
            // PrintDocBtn
            // 
            this.PrintDocBtn.Location = new System.Drawing.Point(361, 458);
            this.PrintDocBtn.Name = "PrintDocBtn";
            this.PrintDocBtn.Size = new System.Drawing.Size(81, 48);
            this.PrintDocBtn.TabIndex = 14;
            this.PrintDocBtn.Text = "Распечатать файл";
            this.PrintDocBtn.UseVisualStyleBackColor = true;
            this.PrintDocBtn.Click += new System.EventHandler(this.PrintDocBtn_Click);
            // 
            // OpenAttachedFileBtn
            // 
            this.OpenAttachedFileBtn.Location = new System.Drawing.Point(243, 458);
            this.OpenAttachedFileBtn.Name = "OpenAttachedFileBtn";
            this.OpenAttachedFileBtn.Size = new System.Drawing.Size(81, 48);
            this.OpenAttachedFileBtn.TabIndex = 15;
            this.OpenAttachedFileBtn.Text = "Открыть файл";
            this.OpenAttachedFileBtn.UseVisualStyleBackColor = true;
            this.OpenAttachedFileBtn.Click += new System.EventHandler(this.OpenAttachedFileBtn_Click);
            // 
            // AdditionalInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OpenAttachedFileBtn);
            this.Controls.Add(this.PrintDocBtn);
            this.Controls.Add(this.RemoveFileBtn);
            this.Controls.Add(this.AddFileBtn);
            this.Controls.Add(this.OkAddInfoBtn);
            this.Controls.Add(this.AddInfoGroupBox);
            this.Name = "AdditionalInfoControl";
            this.Size = new System.Drawing.Size(605, 519);
            this.AddInfoGroupBox.ResumeLayout(false);
            this.AddInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AddInfoGroupBox;
        private System.Windows.Forms.Button OkAddInfoBtn;
        private EditableListView attachedFilesListView;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button RemoveFileBtn;
        private System.Windows.Forms.Button AddFileBtn;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button PrintDocBtn;
        private Helpers.EditableListView AddInfoListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button RemoveInfoBtn;
        private System.Windows.Forms.Button AddInfoBtn;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button OpenAttachedFileBtn;
    }
}
