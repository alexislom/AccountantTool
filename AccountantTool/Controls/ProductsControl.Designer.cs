using AccountantTool.Helpers;

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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddProductBtn = new System.Windows.Forms.Button();
            this.RemoveProductBtn = new System.Windows.Forms.Button();
            this.OkProductsBtn = new System.Windows.Forms.Button();
            this.ProductsListView = new AccountantTool.Helpers.EditableListView();
            this.NumberOfContractColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameOfProductColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CostFromSellerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FromSellerCurrency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CostForCustomerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ForCustomerCurrency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RateOfCurrencyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GeneralCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GeneralCountCurrencyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProductsListView);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1237, 300);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Изделия";
            // 
            // AddProductBtn
            // 
            this.AddProductBtn.Location = new System.Drawing.Point(25, 309);
            this.AddProductBtn.Name = "AddProductBtn";
            this.AddProductBtn.Size = new System.Drawing.Size(75, 40);
            this.AddProductBtn.TabIndex = 4;
            this.AddProductBtn.Text = "Добавить изделие";
            this.AddProductBtn.UseVisualStyleBackColor = true;
            this.AddProductBtn.Click += new System.EventHandler(this.AddProductBtn_Click);
            // 
            // RemoveProductBtn
            // 
            this.RemoveProductBtn.Location = new System.Drawing.Point(208, 309);
            this.RemoveProductBtn.Name = "RemoveProductBtn";
            this.RemoveProductBtn.Size = new System.Drawing.Size(75, 40);
            this.RemoveProductBtn.TabIndex = 5;
            this.RemoveProductBtn.Text = "Удалить изделие";
            this.RemoveProductBtn.UseVisualStyleBackColor = true;
            this.RemoveProductBtn.Click += new System.EventHandler(this.RemoveProductBtn_Click);
            // 
            // OkProductsBtn
            // 
            this.OkProductsBtn.Location = new System.Drawing.Point(851, 309);
            this.OkProductsBtn.Name = "OkProductsBtn";
            this.OkProductsBtn.Size = new System.Drawing.Size(75, 40);
            this.OkProductsBtn.TabIndex = 6;
            this.OkProductsBtn.Text = "Ok";
            this.OkProductsBtn.UseVisualStyleBackColor = true;
            this.OkProductsBtn.Click += new System.EventHandler(this.OkProductsBtn_Click);
            // 
            // ProductsListView
            // 
            this.ProductsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumberOfContractColumnHeader,
            this.NameOfProductColumnHeader,
            this.DescriptionColumnHeader,
            this.CostFromSellerColumnHeader,
            this.FromSellerCurrency,
            this.CostForCustomerColumnHeader,
            this.ForCustomerCurrency,
            this.RateOfCurrencyColumnHeader,
            this.CountColumnHeader,
            this.GeneralCountColumnHeader,
            this.GeneralCountCurrencyColumnHeader});
            this.ProductsListView.FullRowSelect = true;
            this.ProductsListView.GridLines = true;
            this.ProductsListView.Location = new System.Drawing.Point(6, 19);
            this.ProductsListView.Name = "ProductsListView";
            this.ProductsListView.Size = new System.Drawing.Size(1225, 275);
            this.ProductsListView.TabIndex = 2;
            this.ProductsListView.UseCompatibleStateImageBehavior = false;
            this.ProductsListView.View = System.Windows.Forms.View.Details;
            // 
            // NumberOfContractColumnHeader
            // 
            this.NumberOfContractColumnHeader.Text = "Номер контракта";
            this.NumberOfContractColumnHeader.Width = 106;
            // 
            // NameOfProductColumnHeader
            // 
            this.NameOfProductColumnHeader.Text = "Наименование изделия";
            this.NameOfProductColumnHeader.Width = 137;
            // 
            // DescriptionColumnHeader
            // 
            this.DescriptionColumnHeader.Text = "Характеристика изделия, комплектация";
            this.DescriptionColumnHeader.Width = 227;
            // 
            // CostFromSellerColumnHeader
            // 
            this.CostFromSellerColumnHeader.Text = "Стоимость производителя (за единицу)";
            this.CostFromSellerColumnHeader.Width = 221;
            // 
            // FromSellerCurrency
            // 
            this.FromSellerCurrency.Text = "Валюта";
            this.FromSellerCurrency.Width = 65;
            // 
            // CostForCustomerColumnHeader
            // 
            this.CostForCustomerColumnHeader.Text = "Стоимость продавца (за единицу)";
            this.CostForCustomerColumnHeader.Width = 187;
            // 
            // ForCustomerCurrency
            // 
            this.ForCustomerCurrency.Text = "Валюта";
            this.ForCustomerCurrency.Width = 82;
            // 
            // CountColumnHeader
            // 
            this.CountColumnHeader.Text = "Количество изделий";
            this.CountColumnHeader.Width = 121;
            // 
            // RateOfCurrencyColumnHeader
            // 
            this.RateOfCurrencyColumnHeader.Text = "Курс валюты";
            this.RateOfCurrencyColumnHeader.Width = 85;
            // 
            // GeneralCountColumnHeader
            // 
            this.GeneralCountColumnHeader.Text = "Общая стоимость";
            this.GeneralCountColumnHeader.Width = 119;
            // 
            // GeneralCountCurrencyColumnHeader
            // 
            this.GeneralCountCurrencyColumnHeader.Text = "Валюта";
            // 
            // ProductsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OkProductsBtn);
            this.Controls.Add(this.RemoveProductBtn);
            this.Controls.Add(this.AddProductBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductsControl";
            this.Size = new System.Drawing.Size(1243, 351);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EditableListView ProductsListView;
        private System.Windows.Forms.ColumnHeader NameOfProductColumnHeader;
        private System.Windows.Forms.ColumnHeader DescriptionColumnHeader;
        private System.Windows.Forms.ColumnHeader CostFromSellerColumnHeader;
        private System.Windows.Forms.ColumnHeader CostForCustomerColumnHeader;
        private System.Windows.Forms.ColumnHeader CountColumnHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddProductBtn;
        private System.Windows.Forms.Button RemoveProductBtn;
        private System.Windows.Forms.Button OkProductsBtn;
        private System.Windows.Forms.ColumnHeader FromSellerCurrency;
        private System.Windows.Forms.ColumnHeader ForCustomerCurrency;
        private System.Windows.Forms.ColumnHeader NumberOfContractColumnHeader;
        private System.Windows.Forms.ColumnHeader RateOfCurrencyColumnHeader;
        private System.Windows.Forms.ColumnHeader GeneralCountColumnHeader;
        private System.Windows.Forms.ColumnHeader GeneralCountCurrencyColumnHeader;
    }
}
