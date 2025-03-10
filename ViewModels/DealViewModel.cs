using System;

namespace DealsManagement.ViewModels;

public class DealViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public string? Image { get; set; }
    public List<HotelViewModel>? Hotels { get; set; } = new List<HotelViewModel>();
}
