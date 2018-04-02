namespace AccountantTool.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double CostFromSeller { get; set; }

        public double CostForCustomer { get; set; }

        public string Count { get; set; }
    }
}