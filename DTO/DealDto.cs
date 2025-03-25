using System;
using DealsManagement.Models.Domain;

namespace DealsManagement.DTO;

public class DealDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public string? Image { get; set; } // for to store the path
    public IFormFile? ImageFile { get; set; }
    public IFormFile? VideoFile { get; set; }
    public string? VideoAltText { get; set; }


    public ICollection<HotelDto>? Hotels { get; set; } = new List<HotelDto>();
}


