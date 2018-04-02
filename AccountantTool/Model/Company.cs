using System;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    public class Company
    {
        public Guid ParentId { get; set; }

        public string LongName { get; set; }

        public string ShortName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}