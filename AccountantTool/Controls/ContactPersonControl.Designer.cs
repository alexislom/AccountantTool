namespace AccountantTool.Controls
{
    partial class ContactPersonControl
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
            this.ContactsListView = new System.Windows.Forms.ListView();
            this.PositionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmailColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactPersonsGroupBox = new System.Windows.Forms.GroupBox();
            this.ContactPersonsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactsListView
            // 
            this.ContactsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PositionColumnHeader,
            this.FullNameColumnHeader,
            this.PhoneColumnHeader,
            this.EmailColumnHeader});
            this.ContactsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContactsListView.Location = new System.Drawing.Point(3, 16);
            this.ContactsListView.Name = "ContactsListView";
            this.ContactsListView.Size = new System.Drawing.Size(575, 290);
            this.ContactsListView.TabIndex = 0;
            this.ContactsListView.UseCompatibleStateImageBehavior = false;
            this.ContactsListView.View = System.Windows.Forms.View.Details;
            // 
            // PositionColumnHeader
            // 
            this.PositionColumnHeader.Text = "Должность";
            this.PositionColumnHeader.Width = 116;
            // 
            // FullNameColumnHeader
            // 
            this.FullNameColumnHeader.Text = "ФИО";
            this.FullNameColumnHeader.Width = 164;
            // 
            // PhoneColumnHeader
            // 
            this.PhoneColumnHeader.Text = "Контактный телефон";
            this.PhoneColumnHeader.Width = 144;
            // 
            // EmailColumnHeader
            // 
            this.EmailColumnHeader.Text = "Адрес электронной почты";
            this.EmailColumnHeader.Width = 155;
            // 
            // ContactPersonsGroupBox
            // 
            this.ContactPersonsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactPersonsGroupBox.Controls.Add(this.ContactsListView);
            this.ContactPersonsGroupBox.Location = new System.Drawing.Point(3, 0);
            this.ContactPersonsGroupBox.Name = "ContactPersonsGroupBox";
            this.ContactPersonsGroupBox.Size = new System.Drawing.Size(581, 309);
            this.ContactPersonsGroupBox.TabIndex = 1;
            this.ContactPersonsGroupBox.TabStop = false;
            this.ContactPersonsGroupBox.Text = "Контактные лица";
            // 
            // ContactPersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContactPersonsGroupBox);
            this.Name = "ContactPersonControl";
            this.Size = new System.Drawing.Size(587, 356);
            this.ContactPersonsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ContactsListView;
        private System.Windows.Forms.ColumnHeader PositionColumnHeader;
        private System.Windows.Forms.ColumnHeader FullNameColumnHeader;
        private System.Windows.Forms.ColumnHeader PhoneColumnHeader;
        private System.Windows.Forms.ColumnHeader EmailColumnHeader;
        private System.Windows.Forms.GroupBox ContactPersonsGroupBox;
    }
}
