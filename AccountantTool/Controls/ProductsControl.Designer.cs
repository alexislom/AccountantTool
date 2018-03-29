namespace AccountantTool.Controls
{
    partial class ProductsControl
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
            this.NumberOfProductColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CostFromSellerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CostForCustomerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumberOfProductColumnHeader,
            this.DescriptionColumnHeader,
            this.CostFromSellerColumnHeader,
            this.CostForCustomerColumnHeader,
            this.CountColumnHeader});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(838, 423);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // NumberOfProductColumnHeader
            // 
            this.NumberOfProductColumnHeader.Text = "Наименование изделия";
            this.NumberOfProductColumnHeader.Width = 145;
            // 
            // DescriptionColumnHeader
            // 
            this.DescriptionColumnHeader.Text = "Характеристика изделия";
            this.DescriptionColumnHeader.Width = 152;
            // 
            // CostFromSellerColumnHeader
            // 
            this.CostFromSellerColumnHeader.Text = "Стоимость у продавца ";
            this.CostFromSellerColumnHeader.Width = 147;
            // 
            // CostForCustomerColumnHeader
            // 
            this.CostForCustomerColumnHeader.Text = "Стоимость при поставке покупателю";
            this.CostForCustomerColumnHeader.Width = 206;
            // 
            // CountColumnHeader
            // 
            this.CountColumnHeader.Text = "Количество поставляемых изделий";
            this.CountColumnHeader.Width = 166;
            // 
            // ProductsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "ProductsControl";
            this.Size = new System.Drawing.Size(838, 423);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader NumberOfProductColumnHeader;
        private System.Windows.Forms.ColumnHeader DescriptionColumnHeader;
        private System.Windows.Forms.ColumnHeader CostFromSellerColumnHeader;
        private System.Windows.Forms.ColumnHeader CostForCustomerColumnHeader;
        private System.Windows.Forms.ColumnHeader CountColumnHeader;
    }
}
