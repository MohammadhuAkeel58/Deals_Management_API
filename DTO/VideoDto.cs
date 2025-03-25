using System;

namespace DealsManagement.DTO;

public class VideoDto
{
    public int Id { get; set; }
    public IFormFile? VideoFile { get; set; }
    public string? AltText { get; set; }
}
