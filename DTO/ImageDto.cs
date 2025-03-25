using System;

namespace DealsManagement.DTO;

public class ImageDto
{
    public int Id { get; set; }
    public string? Image { get; set; } // for to store the path
    public IFormFile? ImageFile { get; set; } // for file upload

}
