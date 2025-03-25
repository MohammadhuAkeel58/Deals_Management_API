
namespace DealsManagement.Models.Domain
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }


        public int DealId { get; set; }


        public Deal? Deal { get; set; }
    }
}
