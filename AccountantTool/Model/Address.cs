namespace AccountantTool.Model
{
    public class Address
    {
        public int Id { get; set; }

        public int Index { get; set; } = 220000;

        public string Region { get; set; }

        public string Country { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string House { get; set; }

        public string Flat { get; set; }
    }
}