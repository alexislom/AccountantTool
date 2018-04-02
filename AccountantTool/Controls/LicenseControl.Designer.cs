using AccountantTool.Helpers;

namespace AccountantTool.Controls
{
    partial class LicenseControl
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
            this.LicenseListView = new AccountantTool.Helpers.EditableListView();
            this.NumberOfLicenseColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfIssueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfEndColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LicenseTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddLicenseBtn = new System.Windows.Forms.Button();
            this.RemoveLicenseBtn = new System.Windows.Forms.Button();
            this.OkLicenseBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LicenseListView
            // 
            this.LicenseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumberOfLicenseColumnHeader,
            this.DateOfIssueColumnHeader,
            this.DateOfEndColumnHeader,
            this.LicenseTypeColumnHeader});
            this.LicenseListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LicenseListView.FullRowSelect = true;
            this.LicenseListView.GridLines = true;
            this.LicenseListView.Location = new System.Drawing.Point(3, 16);
            this.LicenseListView.Name = "LicenseListView";
            this.LicenseListView.Size = new System.Drawing.Size(623, 287);
            this.LicenseListView.TabIndex = 1;
            this.LicenseListView.UseCompatibleStateImageBehavior = false;
            this.LicenseListView.View = System.Windows.Forms.View.Details;
            // 
            // NumberOfLicenseColumnHeader
            // 
            this.NumberOfLicenseColumnHeader.Text = "Номер лицензии";
            this.NumberOfLicenseColumnHeader.Width = 116;
            // 
            // DateOfIssueColumnHeader
            // 
            this.DateOfIssueColumnHeader.Text = "Дата выдачи";
            this.DateOfIssueColumnHeader.Width = 164;
            // 
            // DateOfEndColumnHeader
            // 
            this.DateOfEndColumnHeader.Text = "Дата окончания";
            this.DateOfEndColumnHeader.Width = 144;
            // 
            // LicenseTypeColumnHeader
            // 
            this.LicenseTypeColumnHeader.Text = "Вид лицензии";
            this.LicenseTypeColumnHeader.Width = 155;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LicenseListView);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 306);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Лицензии";
            // 
            // AddLicenseBtn
            // 
            this.AddLicenseBtn.Location = new System.Drawing.Point(27, 321);
            this.AddLicenseBtn.Name = "AddLicenseBtn";
            this.AddLicenseBtn.Size = new System.Drawing.Size(75, 40);
            this.AddLicenseBtn.TabIndex = 3;
            this.AddLicenseBtn.Text = "Добавить лицензию";
            this.AddLicenseBtn.UseVisualStyleBackColor = true;
            this.AddLicenseBtn.Click += new System.EventHandler(this.AddLicenseBtn_Click);
            // 
            // RemoveLicenseBtn
            // 
            this.RemoveLicenseBtn.Location = new System.Drawing.Point(161, 321);
            this.RemoveLicenseBtn.Name = "RemoveLicenseBtn";
            this.RemoveLicenseBtn.Size = new System.Drawing.Size(75, 40);
            this.RemoveLicenseBtn.TabIndex = 4;
            this.RemoveLicenseBtn.Text = "Удалить лицензию";
            this.RemoveLicenseBtn.UseVisualStyleBackColor = true;
            this.RemoveLicenseBtn.Click += new System.EventHandler(this.RemoveLicenseBtn_Click);
            // 
            // OkLicenseBtn
            // 
            this.OkLicenseBtn.Location = new System.Drawing.Point(534, 321);
            this.OkLicenseBtn.Name = "OkLicenseBtn";
            this.OkLicenseBtn.Size = new System.Drawing.Size(75, 40);
            this.OkLicenseBtn.TabIndex = 5;
            this.OkLicenseBtn.Text = "Ok";
            this.OkLicenseBtn.UseVisualStyleBackColor = true;
            this.OkLicenseBtn.Click += new System.EventHandler(this.OkLicenseBtn_Click);
            // 
            // LicenseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OkLicenseBtn);
            this.Controls.Add(this.RemoveLicenseBtn);
            this.Controls.Add(this.AddLicenseBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "LicenseControl";
            this.Size = new System.Drawing.Size(632, 367);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EditableListView LicenseListView;
        private System.Windows.Forms.ColumnHeader NumberOfLicenseColumnHeader;
        private System.Windows.Forms.ColumnHeader DateOfIssueColumnHeader;
        private System.Windows.Forms.ColumnHeader DateOfEndColumnHeader;
        private System.Windows.Forms.ColumnHeader LicenseTypeColumnHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddLicenseBtn;
        private System.Windows.Forms.Button RemoveLicenseBtn;
        private System.Windows.Forms.Button OkLicenseBtn;
    }
}
