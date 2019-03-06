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
                textBox1.Text,
                textBox2.Text,
                richTextBox3.Text,
                textBox4.Text,
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                textBox9.Text,
                textBox10.Text,
                textBox11.Text
            });

            DialogResult = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}