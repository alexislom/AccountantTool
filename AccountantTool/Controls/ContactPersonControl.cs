using System.Collections.Generic;
using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ContactPersonControl : UserControl
    {
        public List<ContactPerson> Model { get; private set; }

        public ContactPersonControl(List<ContactPerson> model)
        {
            Model = model;
            InitializeComponent();

            if (Model != null)
            {
                foreach (var contactPerson in Model)
                {
                    ContactsListView.Items.Add(new ListViewItem(new[]
                    {
                        contactPerson?.Position,
                        contactPerson?.FullName,
                        contactPerson?.ContactPhone,
                        contactPerson?.Email
                    }));
                }
            }
        }

        private void AddContactPersonBtn_Click(object sender, System.EventArgs e)
        {
            ContactsListView.Items.Add(new ListViewItem(new[]
            {
                "Position",
                "FIO",
                "Contact phone",
                "email"
            }));
        }

        private void RemoveContactPersonBtn_Click(object sender, System.EventArgs e)
        {
            ContactsListView.Items.Remove(ContactsListView.SelectedItem);
        }

        private void OkContactPersonsBtn_Click(object sender, System.EventArgs e)
        {
            if (ContactsListView.Items.Count != 0)
            {
                Model.Clear();

                foreach (ListViewItem item in ContactsListView.Items)
                {
                    var subItem = item.SubItems;
                    Model.Add(new ContactPerson
                    {
                        Position = subItem[0]?.Text,
                        FullName = subItem[1]?.Text,
                        ContactPhone = subItem[2]?.Text,
                        Email = subItem[3]?.Text
                    });
                }
            }
        }
    }
}