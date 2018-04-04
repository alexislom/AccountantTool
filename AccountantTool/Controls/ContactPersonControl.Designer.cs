using AccountantTool.Helpers;

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
            this.ContactsListView = new EditableListView();
            this.PositionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmailColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactPersonsGroupBox = new System.Windows.Forms.GroupBox();
            this.AddContactPersonBtn = new System.Windows.Forms.Button();
            this.RemoveContactPersonBtn = new System.Windows.Forms.Button();
            this.OkContactPersonsBtn = new System.Windows.Forms.Button();
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
            this.ContactsListView.Size = new System.Drawing.Size(575, 305);
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
            this.ContactPersonsGroupBox.Size = new System.Drawing.Size(581, 324);
            this.ContactPersonsGroupBox.TabIndex = 1;
            this.ContactPersonsGroupBox.TabStop = false;
            this.ContactPersonsGroupBox.Text = "Контактные лица";
            // 
            // AddContactPersonBtn
            // 
            this.AddContactPersonBtn.Location = new System.Drawing.Point(34, 327);
            this.AddContactPersonBtn.Name = "AddContactPersonBtn";
            this.AddContactPersonBtn.Size = new System.Drawing.Size(75, 34);
            this.AddContactPersonBtn.TabIndex = 2;
            this.AddContactPersonBtn.Text = "Добавить контакт";
            this.AddContactPersonBtn.UseVisualStyleBackColor = true;
            this.AddContactPersonBtn.Click += new System.EventHandler(this.AddContactPersonBtn_Click);
            // 
            // RemoveContactPersonBtn
            // 
            this.RemoveContactPersonBtn.Location = new System.Drawing.Point(152, 327);
            this.RemoveContactPersonBtn.Name = "RemoveContactPersonBtn";
            this.RemoveContactPersonBtn.Size = new System.Drawing.Size(75, 34);
            this.RemoveContactPersonBtn.TabIndex = 3;
            this.RemoveContactPersonBtn.Text = "Удалить контакт";
            this.RemoveContactPersonBtn.UseVisualStyleBackColor = true;
            this.RemoveContactPersonBtn.Click += new System.EventHandler(this.RemoveContactPersonBtn_Click);
            // 
            // OkContactPersonsBtn
            // 
            this.OkContactPersonsBtn.Location = new System.Drawing.Point(493, 327);
            this.OkContactPersonsBtn.Name = "OkContactPersonsBtn";
            this.OkContactPersonsBtn.Size = new System.Drawing.Size(75, 34);
            this.OkContactPersonsBtn.TabIndex = 4;
            this.OkContactPersonsBtn.Text = "Ok";
            this.OkContactPersonsBtn.UseVisualStyleBackColor = true;
            this.OkContactPersonsBtn.Click += new System.EventHandler(this.OkContactPersonsBtn_Click);
            // 
            // ContactPersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OkContactPersonsBtn);
            this.Controls.Add(this.RemoveContactPersonBtn);
            this.Controls.Add(this.AddContactPersonBtn);
            this.Controls.Add(this.ContactPersonsGroupBox);
            this.Name = "ContactPersonControl";
            this.Size = new System.Drawing.Size(587, 371);
            this.ContactPersonsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EditableListView ContactsListView;
        private System.Windows.Forms.ColumnHeader PositionColumnHeader;
        private System.Windows.Forms.ColumnHeader FullNameColumnHeader;
        private System.Windows.Forms.ColumnHeader PhoneColumnHeader;
        private System.Windows.Forms.ColumnHeader EmailColumnHeader;
        private System.Windows.Forms.GroupBox ContactPersonsGroupBox;
        private System.Windows.Forms.Button AddContactPersonBtn;
        private System.Windows.Forms.Button RemoveContactPersonBtn;
        private System.Windows.Forms.Button OkContactPersonsBtn;
    }
}
