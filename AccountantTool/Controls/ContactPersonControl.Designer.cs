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
            this.listView1 = new System.Windows.Forms.ListView();
            this.PositionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmailColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PositionColumnHeader,
            this.FullNameColumnHeader,
            this.PhoneColumnHeader,
            this.EmailColumnHeader});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(587, 356);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // ContactPersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "ContactPersonControl";
            this.Size = new System.Drawing.Size(587, 356);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader PositionColumnHeader;
        private System.Windows.Forms.ColumnHeader FullNameColumnHeader;
        private System.Windows.Forms.ColumnHeader PhoneColumnHeader;
        private System.Windows.Forms.ColumnHeader EmailColumnHeader;
    }
}
