using System;
using DealsManagement.Models.Domain;

namespace DealsManagement.Service;

public interface IVideoService
{

    Task<VideoInfo?> SaveVideoAsync(IFormFile? videoFile, string folderPath, string? altText);

}
