using System.Collections.Generic;
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
                        product?.Name,
                        product?.Description,
                        product?.CostFromSeller.ToString(CultureInfo.InvariantCulture),
                        product?.CostFromSellerCurrency,
                        product?.CostForCustomer.ToString(CultureInfo.InvariantCulture),
                        product?.CostForCustomerCurrency,
                        product?.Count
                    }));
                }
            }

            ProductsListView.EditTextBox.TextChanged += (sender, args) => IsDirty = true;

            IsDirty = false;
        }

        private void AddProductBtn_Click(object sender, System.EventArgs e)
        {
            ProductsListView.Items.Add(new ListViewItem(new[]
            {
                "Name",
                "Description",
                "Cost from seller",
                "Br",
                "Cost for customer",
                "Br",
                "Count"
            }));

            IsDirty = true;
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

                    double.TryParse(subItem[2]?.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var costFromSeller);
                    double.TryParse(subItem[4]?.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var costForCustomer);

                    Model.Add(new Product
                    {
                        Name = subItem[0]?.Text,
                        Description = subItem[1]?.Text,
                        CostFromSeller = costFromSeller,
                        CostFromSellerCurrency = subItem[3]?.Text,
                        CostForCustomer = costForCustomer,
                        CostForCustomerCurrency = subItem[5]?.Text,
                        Count = subItem[6]?.Text
                    });
                }
            }

            IsDirty = false;
        }
    }
}