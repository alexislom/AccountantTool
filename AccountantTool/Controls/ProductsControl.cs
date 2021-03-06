﻿using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using AccountantTool.Controls.Interfaces;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ProductsControl : UserControl, INotifyControlDataSave
    {
        #region Properties
        public List<Product> Model { get; }
        public bool IsDirty { get; set; }
        #endregion Properties

        public ProductsControl(List<Product> model)
        {
            Model = model;
            InitializeComponent();

            if (Model != null)
            {
                foreach (var product in Model)
                {
                    ProductsListView.Items.Add(new ListViewItem(new[]
                    {
                        product?.NumberOfContract,
                        product?.Name,
                        product?.Description,
                        product?.CostFromSeller.ToString(CultureInfo.InvariantCulture),
                        product?.CostFromSellerCurrency,
                        product?.CostForCustomer.ToString(CultureInfo.InvariantCulture),
                        product?.CostForCustomerCurrency,
                        product?.RateCurrency,
                        product?.Count,
                        product?.GenericCost,
                        product?.GenericCostCurrency
                    }));
                }
            }

            ProductsListView.EditTextBox.TextChanged += (sender, args) => IsDirty = true;

            IsDirty = false;
        }

        private void AddProductBtn_Click(object sender, System.EventArgs e)
        {
            var form = new ProductsForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                ProductsListView.Items.Add(form.Product);
                //ProductsListView.SelectedItem = form.Product;
                IsDirty = true;
                DoClose();
            }
        }

        private void EditBtn_Click(object sender, System.EventArgs e)
        {
            if(ProductsListView.SelectedItem != null)
            {
                var form = new ProductsForm();

                form.TextBox1.Text = ProductsListView.SelectedItem.SubItems[0]?.Text;
                form.TextBox2.Text = ProductsListView.SelectedItem.SubItems[1]?.Text;
                form.RichTextBox3.Text = ProductsListView.SelectedItem.SubItems[2]?.Text;
                form.TextBox4.Text = ProductsListView.SelectedItem.SubItems[3]?.Text;
                form.TextBox5.Text = ProductsListView.SelectedItem.SubItems[4]?.Text;
                form.TextBox6.Text = ProductsListView.SelectedItem.SubItems[5]?.Text;
                form.TextBox7.Text = ProductsListView.SelectedItem.SubItems[6]?.Text;
                form.TextBox8.Text = ProductsListView.SelectedItem.SubItems[7]?.Text;
                form.TextBox9.Text = ProductsListView.SelectedItem.SubItems[8]?.Text;
                form.TextBox10.Text = ProductsListView.SelectedItem.SubItems[9]?.Text;
                form.TextBox11.Text = ProductsListView.SelectedItem.SubItems[10]?.Text;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    //Chenage selected item
                    ProductsListView.Items[ProductsListView.SelectedIndices[0]] = form.Product;
                    IsDirty = true;
                    DoClose();
                }
            }
        }

        private void RemoveProductBtn_Click(object sender, System.EventArgs e)
        {
            ProductsListView.Items.Remove(ProductsListView.SelectedItem);

            IsDirty = true;
        }

        private void OkProductsBtn_Click(object sender, System.EventArgs e)
        {
            DoClose();
        }

        public void DoClose()
        {
            if (ProductsListView.Items.Count != 0)
            {
                Model.Clear();

                foreach (ListViewItem item in ProductsListView.Items)
                {
                    var subItem = item.SubItems;

                    double.TryParse(subItem[3]?.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var costFromSeller);
                    double.TryParse(subItem[5]?.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var costForCustomer);

                    Model.Add(new Product
                    {
                        NumberOfContract = subItem[0]?.Text,
                        Name = subItem[1]?.Text,
                        Description = subItem[2]?.Text,
                        CostFromSeller = costFromSeller,
                        CostFromSellerCurrency = subItem[4]?.Text,
                        CostForCustomer = costForCustomer,
                        CostForCustomerCurrency = subItem[6]?.Text,
                        RateCurrency = subItem[7]?.Text,
                        Count = subItem[8]?.Text,
                        GenericCost = subItem[9]?.Text,
                        GenericCostCurrency = subItem[10]?.Text
                    });
                }
            }

            IsDirty = false;
        }
    }
}