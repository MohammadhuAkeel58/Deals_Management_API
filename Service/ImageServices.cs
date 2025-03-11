using System;
using Microsoft.AspNetCore.Http;

namespace DealsManagement.Service;

public class ImageServices : IImageService
{
    private readonly IWebHostEnvironment webHostEnvironment;

    public ImageServices(IWebHostEnvironment webHostEnvironment)
    {
        this.webHostEnvironment = webHostEnvironment;
    }
    public async Task<string?> SaveImageAsync(IFormFile? imageFile, string folderPath)
    {
        if (imageFile == null || imageFile.Length == 0)
            return null;
        folderPath = folderPath.TrimStart('/');
        // Validate file (optional but recommended)
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var extension = Path.GetExtension(imageFile.FileName).ToLower();
        if (!allowedExtensions.Contains(extension))
            throw new ArgumentException("Invalid image format");

        if (imageFile.Length > 5 * 1024 * 1024) // 5MB limit
            throw new ArgumentException("Image file size exceeds 5MB.");


        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);
        Directory.CreateDirectory(uploadsFolder);

        // Generate a unique file name
        string uniqueFileName = $"{Guid.NewGuid()}{extension}";
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        // Save the file to the server
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fileStream);
        }


        return $"/{folderPath}/{uniqueFileName}";
    }


}

