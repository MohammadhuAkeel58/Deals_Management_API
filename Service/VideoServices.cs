using System;
using System.IO;
using System.Threading.Tasks;
using DealsManagement.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace DealsManagement.Service;

public class VideoServices : IVideoService
{
    private readonly IWebHostEnvironment webHostEnvironment;

    public VideoServices(IWebHostEnvironment webHostEnvironment)
    {
        this.webHostEnvironment = webHostEnvironment;
    }

    public async Task<VideoInfo?> SaveVideoAsync(IFormFile? videoFile, string folderPath, string? altText)
    {
        if (videoFile == null || videoFile.Length == 0)
            return null;

        folderPath = folderPath.TrimStart('/');

        var allowedExtensions = new[] { ".mp4", ".avi", ".mov" };
        var extension = Path.GetExtension(videoFile.FileName).ToLower();

        if (!allowedExtensions.Contains(extension))
            throw new ArgumentException("Invalid video format");

        if (videoFile.Length > 200 * 1024 * 1024)
            throw new ArgumentException("Video file size exceeds 200MB.");

        try
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);
            Directory.CreateDirectory(uploadsFolder);

            var originalFileName = Path.GetFileNameWithoutExtension(videoFile.FileName);
            string uniqueFileName = $"{originalFileName}/{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await videoFile.CopyToAsync(fileStream);
            }

            return new VideoInfo
            {
                Path = $"/{folderPath}/{uniqueFileName}",
                AltText = altText
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving video: {ex.Message}");
            throw;
        }
    }
}