namespace InSell.Models
{
    public class Company : IBasePersistable
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Industry { get; set; }

        public string Revenue { get; set; }

        public string RevenueUnit { get; set; }

        public string RevenueCurrency { get; set; }

        public string Website { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string Type => "Company";
    }
}
