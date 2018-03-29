using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ContactPersonControl : UserControl
    {
        public List<ContactPerson> Model { get; private set; }

        public ContactPersonControl(ICollection<ContactPerson> model)
        {
            Model = model.ToList();
            InitializeComponent();

            //PositionColumnHeader.Text = Model.Position;
            //FullNameColumnHeader.Text = $"{Model.Surname} {Model.Name} {Model.Patronymic}";
            //PhoneColumnHeader.Text = Model.ContactPhone;
            //EmailColumnHeader.Text = Model.Email;
        }
    }
}