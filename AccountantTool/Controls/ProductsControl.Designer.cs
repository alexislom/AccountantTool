﻿using AccountantTool.Helpers;

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
            this.ProductsListView = new EditableListView();
            this.NumberOfProductColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CostFromSellerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CostForCustomerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddProductBtn = new System.Windows.Forms.Button();
            this.RemoveProductBtn = new System.Windows.Forms.Button();
            this.OkProductsBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductsListView
            // 
            this.ProductsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumberOfProductColumnHeader,
            this.DescriptionColumnHeader,
            this.CostFromSellerColumnHeader,
            this.CostForCustomerColumnHeader,
            this.CountColumnHeader});
            this.ProductsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsListView.Location = new System.Drawing.Point(3, 16);
            this.ProductsListView.Name = "ProductsListView";
            this.ProductsListView.Size = new System.Drawing.Size(826, 366);
            this.ProductsListView.TabIndex = 2;
            this.ProductsListView.UseCompatibleStateImageBehavior = false;
            this.ProductsListView.View = System.Windows.Forms.View.Details;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProductsListView);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 385);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Изделия";
            // 
            // AddProductBtn
            // 
            this.AddProductBtn.Location = new System.Drawing.Point(25, 394);
            this.AddProductBtn.Name = "AddProductBtn";
            this.AddProductBtn.Size = new System.Drawing.Size(75, 40);
            this.AddProductBtn.TabIndex = 4;
            this.AddProductBtn.Text = "Добавить изделие";
            this.AddProductBtn.UseVisualStyleBackColor = true;
            this.AddProductBtn.Click += new System.EventHandler(this.AddProductBtn_Click);
            // 
            // RemoveProductBtn
            // 
            this.RemoveProductBtn.Location = new System.Drawing.Point(162, 394);
            this.RemoveProductBtn.Name = "RemoveProductBtn";
            this.RemoveProductBtn.Size = new System.Drawing.Size(75, 40);
            this.RemoveProductBtn.TabIndex = 5;
            this.RemoveProductBtn.Text = "Удалить изделие";
            this.RemoveProductBtn.UseVisualStyleBackColor = true;
            this.RemoveProductBtn.Click += new System.EventHandler(this.RemoveProductBtn_Click);
            // 
            // OkProductsBtn
            // 
            this.OkProductsBtn.Location = new System.Drawing.Point(740, 394);
            this.OkProductsBtn.Name = "OkProductsBtn";
            this.OkProductsBtn.Size = new System.Drawing.Size(75, 40);
            this.OkProductsBtn.TabIndex = 6;
            this.OkProductsBtn.Text = "Ok";
            this.OkProductsBtn.UseVisualStyleBackColor = true;
            this.OkProductsBtn.Click += new System.EventHandler(this.OkProductsBtn_Click);
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
            this.Size = new System.Drawing.Size(838, 443);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EditableListView ProductsListView;
        private System.Windows.Forms.ColumnHeader NumberOfProductColumnHeader;
        private System.Windows.Forms.ColumnHeader DescriptionColumnHeader;
        private System.Windows.Forms.ColumnHeader CostFromSellerColumnHeader;
        private System.Windows.Forms.ColumnHeader CostForCustomerColumnHeader;
        private System.Windows.Forms.ColumnHeader CountColumnHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddProductBtn;
        private System.Windows.Forms.Button RemoveProductBtn;
        private System.Windows.Forms.Button OkProductsBtn;
    }
}
