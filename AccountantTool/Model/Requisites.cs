using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    [Serializable]
    public class Requisites
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public List<KeyValuePair<string, string>> DepartmentPhones { get; set; }

        public string Email { get; set; }

        public string Site { get; set; }

        public List<KeyValuePair<string, string>> OtherRequisites { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}