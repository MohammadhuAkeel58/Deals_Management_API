using System;

namespace DealsManagement.Service;

public interface IImageService
{

    Task<string?> SaveImageAsync(IFormFile? imageFile, string folderPath);


}
