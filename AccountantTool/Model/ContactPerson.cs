using System;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    [Serializable]
    public class ContactPerson
    {
        public string Position { get; set; }

        public string FullName { get; set; }

        public string ContactPhone { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}