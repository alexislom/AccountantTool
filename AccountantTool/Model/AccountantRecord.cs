using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    [Serializable]
    public class AccountantRecord
    {
        public Guid Id { get; set; }

        public Company Company { get; set; }

        public Requisites Requisites { get; set; }

        public List<ContactPerson> ContactPersons { get; set; }

        public List<License> License { get; set; }

        public List<Product> Products { get; set; }

        public List<Contract> Contracts { get; set; }

        public AdditionalInfo AdditionalInfo { get; set; }

        public AccountantRecord()
        {
            Company = new Company { ParentId = Id };
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}