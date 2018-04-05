using Newtonsoft.Json;

namespace AccountantTool.Model
{
    public class Address
    {
        public int Id { get; set; }

        public string Index { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Flat { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}