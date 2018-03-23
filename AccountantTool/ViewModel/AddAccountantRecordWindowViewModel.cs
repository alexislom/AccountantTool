namespace AccountantTool.ViewModel
{
    public class AddAccountantRecordWindowViewModel
    {
        public MainWindowViewModel Model { get; private set; }

        public AddAccountantRecordWindowViewModel(MainWindowViewModel model)
        {
            Model = model;
        }
    }
}