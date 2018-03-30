using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ContactPersonControl : UserControl
    {
        public List<ContactPerson> Model { get; private set; }

        public ContactPersonControl(List<ContactPerson> model)
        {
            Model = model; //model.ToList();
            InitializeComponent();

            if (Model != null)
            {
                foreach (var contactPerson in Model)
                {
                    ContactsListView.Items.Add(new ListViewItem(new[]
                    {
                        contactPerson?.Position,
                        $"{contactPerson?.Surname} {contactPerson?.Name} {contactPerson?.Patronymic}",
                        contactPerson?.ContactPhone,
                        contactPerson?.Email
                    }));
                }
            }
        }
    }
}