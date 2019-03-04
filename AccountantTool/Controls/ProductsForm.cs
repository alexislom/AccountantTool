using System;
using System.Windows.Forms;

namespace AccountantTool.Controls
{
    public partial class ProductsForm : Form
    {
        public ListViewItem Product { get; private set; }

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            Product = new ListViewItem(new[]
            {
                !string.IsNullOrEmpty(textBox1.Text) ? textBox1.Text : "Number of contract",
                !string.IsNullOrEmpty(textBox2.Text) ? textBox2.Text : "Name",
                !string.IsNullOrEmpty(textBox3.Text) ? textBox3.Text : "Description",
                !string.IsNullOrEmpty(textBox4.Text) ? textBox4.Text : "Cost from seller",
                !string.IsNullOrEmpty(textBox5.Text) ? textBox5.Text : "Br",
                !string.IsNullOrEmpty(textBox6.Text) ? textBox6.Text : "Cost for customer",
                !string.IsNullOrEmpty(textBox7.Text) ? textBox7.Text : "Br",
                !string.IsNullOrEmpty(textBox8.Text) ? textBox8.Text : "Rate currency",
                !string.IsNullOrEmpty(textBox9.Text) ? textBox9.Text : "Count",
                !string.IsNullOrEmpty(textBox10.Text) ? textBox10.Text : "Generic cost",
                !string.IsNullOrEmpty(textBox11.Text) ? textBox11.Text : "Generic cost currency"
            });

            DialogResult = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}