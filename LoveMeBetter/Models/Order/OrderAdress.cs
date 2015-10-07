namespace LoveMeBetter.Models.Order
{
    public class OrderAdress
    {
        public int Id { get; set; }

        public RegionEnum Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }
    }
}