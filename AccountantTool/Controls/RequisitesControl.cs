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
        }
    }
}