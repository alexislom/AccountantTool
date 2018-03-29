using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ProductsControl : UserControl
    {
        public List<Product> Model { get; private set; }

        public ProductsControl(ICollection<Product> model)
        {
            Model = model.ToList();
            InitializeComponent();
        }
    }
}