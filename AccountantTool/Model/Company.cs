using AccountantTool.ViewModel.MainComponents;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    public class Company : ViewModelBase
    {
        public int Id { get; set; }

        public string LongName { get; set; }

        public string ShortName { get; set; }

        //private string _longName;
        //public string LongName
        //{
        //    get => _longName;
        //    set
        //    {
        //        _longName = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string _sortName;
        //public string ShortName
        //{
        //    get => _sortName;
        //    set
        //    {
        //        _sortName = value;
        //        OnPropertyChanged();
        //    }
        //}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}