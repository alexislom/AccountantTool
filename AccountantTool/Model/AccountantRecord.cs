using System.Collections.Generic;

namespace AccountantTool.Model
{
    public class AccountantRecord
    {
        public int Id { get; private set; }

        public Company Company { get; set; }

        public Requisites Requisites { get; set; }

        public ContactPerson ContactPerson { get; set; }

        public License License { get; set; }

        public ICollection<Product> Product { get; set; }

        public Contract Contract { get; set; }

        public AdditionalInfo AdditionalInfo { get; set; }
    }
}