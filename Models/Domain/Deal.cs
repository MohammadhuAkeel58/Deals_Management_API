namespace DealsManagement.Models.Domain
{

    public class Deal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }

        public VideoInfo? Video { get; set; }

        public ICollection<Hotel>? Hotels { get; set; } = new List<Hotel>();
    }

}