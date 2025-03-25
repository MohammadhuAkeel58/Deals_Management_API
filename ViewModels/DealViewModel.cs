using System;

namespace DealsManagement.ViewModels;

public class DealViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public string? Image { get; set; }
    public string? Video { get; set; }    // From VideoInfo.Path
    public string? VideoAltText { get; set; }
    public List<HotelViewModel>? Hotels { get; set; } = new List<HotelViewModel>();
}
