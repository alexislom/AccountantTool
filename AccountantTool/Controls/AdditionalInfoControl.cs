using System.Windows.Forms;
using AccountantTool.Model;

namespace AccountantTool.Controls
{
    public partial class AdditionalInfoControl : UserControl
    {
        public AdditionalInfo Model { get; private set; }

        public AdditionalInfoControl(AdditionalInfo model)
        {
            Model = model;
            InitializeComponent();
            txtNotes.Text = Model.Notes;
        }
    }
}