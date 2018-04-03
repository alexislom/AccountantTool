using System;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    [Serializable]
    public class AdditionalInfo
    {
        public int Id { get; set; }

        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}