using System.Collections.Generic;
using Newtonsoft.Json;

namespace AccountantTool.Helpers
{
    public class ListWrapper<T>
    {
        public List<T> Context { get; set; }

        public ListWrapper(List<T> context) => Context = context;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}