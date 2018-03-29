using AccountantTool.ViewModel.MainComponents;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    public class Company : ViewModelBase
    {
        public int Id { get; set; }

        public string LongName { get; set; }

        public string ShortName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}