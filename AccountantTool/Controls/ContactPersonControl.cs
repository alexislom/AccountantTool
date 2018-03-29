using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class ContactPersonControl : UserControl
    {
        public ContactPerson Model { get; private set; }

        public ContactPersonControl(ContactPerson model)
        {
            Model = model;
            InitializeComponent();

            //PositionColumnHeader.Text = Model.Position;
            //FullNameColumnHeader.Text = $"{Model.Surname} {Model.Name} {Model.Patronymic}";
            //PhoneColumnHeader.Text = Model.ContactPhone;
            //EmailColumnHeader.Text = Model.Email;
        }
    }
}