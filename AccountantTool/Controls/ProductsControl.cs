using System.Collections.Generic;
using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ProductsControl : UserControl
    {
        public List<Product> Model { get; private set; }

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
                        product?.CostFromSeller.ToString("C"),
                        product?.CostForCustomer.ToString("C"),
                        product?.Count
                    }));
                }
            }
        }

        private void AddProductBtn_Click(object sender, System.EventArgs e)
        {
            ProductsListView.Items.Add(new ListViewItem(new[]
            {
                "Name",
                "Description",
                "Cost from seller",
                "Cost for customer",
                "Count"
            }));
        }

        private void RemoveProductBtn_Click(object sender, System.EventArgs e)
        {
            ProductsListView.Items.Remove(ProductsListView.SelectedItem);
        }

        private void OkProductsBtn_Click(object sender, System.EventArgs e)
        {
            if (ProductsListView.Items.Count != 0)
            {
                Model = new List<Product>(ProductsListView.Items.Count);

                foreach (ListViewItem item in ProductsListView.Items)
                {
                    var subItem = item.SubItems;

                    double.TryParse(subItem[2]?.Text, out var costFromSeller);
                    double.TryParse(subItem[3]?.Text, out var costForCustomer);

                    Model.Add(new Product
                    {
                        Name = subItem[0]?.Text,
                        Description = subItem[1]?.Text,
                        CostFromSeller = costFromSeller,
                        CostForCustomer = costForCustomer,
                        Count = subItem[4]?.Text
                    });
                }
            }
        }
    }
}