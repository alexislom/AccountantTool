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
            this.LicenseListView = new System.Windows.Forms.ListView();
            this.NumberOfLicenseColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfIssueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfEndColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LicenseTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.LicenseListView.Location = new System.Drawing.Point(0, 0);
            this.LicenseListView.Name = "LicenseListView";
            this.LicenseListView.Size = new System.Drawing.Size(632, 364);
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
            // LicenseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LicenseListView);
            this.Name = "LicenseControl";
            this.Size = new System.Drawing.Size(632, 364);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LicenseListView;
        private System.Windows.Forms.ColumnHeader NumberOfLicenseColumnHeader;
        private System.Windows.Forms.ColumnHeader DateOfIssueColumnHeader;
        private System.Windows.Forms.ColumnHeader DateOfEndColumnHeader;
        private System.Windows.Forms.ColumnHeader LicenseTypeColumnHeader;
    }
}
