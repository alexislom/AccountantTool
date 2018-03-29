using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ProductsControl : UserControl
    {
        public List<Product> Model { get; private set; }

        public ProductsControl(List<Product> model)
        {
            Model = model.ToList();
            InitializeComponent();

            foreach (var product in Model)
            {
                ProductsListView.Items.Add(new ListViewItem(new[]
                {
                    product.Name,
                    product.Description,
                    product.CostFromSeller.ToString("C"),
                    product.CostForCustomer.ToString("C"),
                    product.Count.ToString()
                }));
            }
        }
    }
}