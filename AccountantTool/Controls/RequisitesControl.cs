using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AccountantTool.Controls.Interfaces;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class RequisitesControl : UserControl, INotifyControlDataSave
    {
        #region Properties
        public Requisites Model { get; }
        public bool IsDirty { get; set; }
        #endregion Properties

        public RequisitesControl(Requisites model)
        {
            Model = model;
            InitializeComponent();

            if (Model.Address != null)
            {
                textRequisitesIndex.Text = Model.Address?.Index;
                textRequisitesCountry.Text = Model.Address?.Country;
                textRequisitesRegion.Text = Model.Address?.Region;
                textRequisitesDistrict.Text = Model.Address?.District;
                textRequisitesCity.Text = Model.Address?.City;
                textRequisitesStreet.Text = Model.Address?.Street;
                textRequisitesHouse.Text = Model.Address?.House;
                textRequisitesFlat.Text = Model.Address?.Flat;
            }
            textRequisitesSite.Text = Model?.Site;
            textRequisitesEmail.Text = Model?.Email;

            EventSubscriptions();

            if (Model?.DepartmentPhones != null)
            {
                foreach (var phone in Model.DepartmentPhones)
                {
                    DepartmentsListView.Items.Add(new ListViewItem(new[]
                    {
                        phone.Key,
                        phone.Value
                    }));
                }
            }

            if (Model?.OtherRequisites != null)
            {
                foreach (var other in Model.OtherRequisites)
                {
                    OtherRequisitesListView.Items.Add(new ListViewItem(new[]
                    {
                        other.Key,
                        other.Value
                    }));
                }
            }

            IsDirty = false;
        }

        private void EventSubscriptions()
        {
            textRequisitesIndex.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesCountry.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesRegion.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesDistrict.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesCity.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesStreet.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesHouse.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesFlat.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesSite.TextChanged += (sender, args) => IsDirty = true;
            textRequisitesEmail.TextChanged += (sender, args) => IsDirty = true;

            DepartmentsListView.EditTextBox.TextChanged += (sender, args) => IsDirty = true;
            OtherRequisitesListView.EditTextBox.TextChanged += (sender, args) => IsDirty = true;
        }

        #region Department phones List view

        private void AddDepartmentBtn_Click(object sender, EventArgs e)
        {
            DepartmentsListView.Items.Add(new ListViewItem(new[]
            {
                "Department",
                "+375171234567"
            }));

            IsDirty = true;
        }

        private void RemoveDepartmentBtn_Click(object sender, EventArgs e)
        {
            DepartmentsListView.Items.Remove(DepartmentsListView.SelectedItem);

            IsDirty = true;
        }

        #endregion Department phones List view

        #region Other requisites list view

        private void AddOtherRequisiteBtn_Click(object sender, EventArgs e)
        {
            OtherRequisitesListView.Items.Add(new ListViewItem(new[]
            {
                "Requisite",
                "123456789"
            }));

            IsDirty = true;
        }

        private void RemoveOtherRequisiteBtn_Click(object sender, EventArgs e)
        {
            OtherRequisitesListView.Items.Remove(OtherRequisitesListView.SelectedItem);

            IsDirty = true;
        }

        #endregion Other requisites list view

        private void OkRequisitesBtn_Click(object sender, EventArgs e)
        {
            DoClose();
        }

        public void DoClose()
        {
            Model.Address = new Address
            {
                Index = textRequisitesIndex?.Text,
                Country = textRequisitesCountry?.Text,
                Region = textRequisitesRegion?.Text,
                District = textRequisitesDistrict?.Text,
                City = textRequisitesCity?.Text,
                Street = textRequisitesStreet?.Text,
                House = textRequisitesHouse?.Text,
                Flat = textRequisitesFlat?.Text
            };
            Model.Site = textRequisitesSite?.Text;
            Model.Email = textRequisitesEmail?.Text;

            if (DepartmentsListView.Items.Count != 0)
            {
                Model.DepartmentPhones = new List<KeyValuePair<string, string>>(DepartmentsListView.Items.Count);

                foreach (ListViewItem item in DepartmentsListView.Items)
                {
                    var subItem = item.SubItems;
                    Model.DepartmentPhones.Add(new KeyValuePair<string, string>(subItem[0]?.Text, subItem[1]?.Text));
                }
            }

            if (OtherRequisitesListView.Items.Count != 0)
            {
                Model.OtherRequisites = new List<KeyValuePair<string, string>>(OtherRequisitesListView.Items.Count);

                foreach (ListViewItem item in OtherRequisitesListView.Items)
                {
                    var subItem = item.SubItems;
                    Model.OtherRequisites.Add(new KeyValuePair<string, string>(subItem[0]?.Text, subItem[1]?.Text));
                }
            }

            IsDirty = false;
        }
    }
}