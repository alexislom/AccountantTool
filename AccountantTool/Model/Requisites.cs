using System.Collections.Generic;

namespace AccountantTool.Model
{
    public class Requisites
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public List<KeyValuePair<string, string>> Phones { get; set; }

        public string Email { get; set; }

        public string Site { get; set; }

        public string OtherRequisites { get; set; }

        public List<KeyValuePair<string, string>> Other { get; set; }
    }
}