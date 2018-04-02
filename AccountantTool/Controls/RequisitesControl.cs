using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class RequisitesControl : UserControl
    {
        public Requisites Model { get; private set; }

        public RequisitesControl(Requisites model)
        {
            Model = model;
            InitializeComponent();

            textRequisitesIndex.Text = Model?.Address.Index.ToString();
            textRequisitesCountry.Text = Model?.Address.Country;
            textRequisitesRegion.Text = Model?.Address.Region;
            textRequisitesDistrict.Text = Model?.Address.District;
            textRequisitesCity.Text = Model?.Address.City;
            textRequisitesHouse.Text = Model?.Address.House;
            textRequisitesFlat.Text = Model?.Address.Flat;
            textRequisitesEmail.Text = Model?.Email;
            textOtherRequisites.Text = Model?.OtherRequisites;

            if (Model?.Phones != null)
            {
                foreach (var phone in Model.Phones)
                {
                    DepartmentsListView.Items.Add(new ListViewItem(new[]
                    {
                        phone.Key,
                        phone.Value
                    }));
                }
            }

            if (Model?.Other != null)
            {
                foreach (var other in Model.Other)
                {
                    OtherRequisitesListView.Items.Add(new ListViewItem(new[]
                    {
                        other.Key,
                        other.Value
                    }));
                }
            }
        }
    }
}