using System;
using Newtonsoft.Json;

namespace AccountantTool.Model
{
    [Serializable]
    public class Product
    {
        public string NumberOfContract { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double CostFromSeller { get; set; }

        public string CostFromSellerCurrency { get; set; }

        public double CostForCustomer { get; set; }

        public string CostForCustomerCurrency { get; set; }

        public string RateCurrency { get; set; }

        public string Count { get; set; }

        public string GenericCost { get; set; }

        public string GenericCostCurrency { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}