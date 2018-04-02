using System.Collections.Generic;

namespace AccountantTool.Model
{
    public class Requisites
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public List<KeyValuePair<string, string>> DepartmentPhones { get; set; }

        public string Email { get; set; }

        public string Site { get; set; }

        public List<KeyValuePair<string, string>> OtherRequisites { get; set; }
    }
}