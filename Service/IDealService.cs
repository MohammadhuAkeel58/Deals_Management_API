using System;
using DealsManagement.DTO;
using DealsManagement.ViewModels;


namespace DealsManagement.Service;

public interface IDealService
{
    Task<List<DealViewModel>> GetAllDealsAsync();
    Task<DealViewModel> GetDealByIdAsync(int id);
    Task<DealViewModel> CreateDealAsync(DealDto dealDto);
    Task<HotelViewModel> CreateHotelAsync(HotelDto hotelDto);
    Task<DealViewModel> UpdateDealAsync(int id, DealDto dealDto);
    Task<DealViewModel> UpdateImageAsync(int id, ImageDto imageDto);
    Task<DealViewModel> UpdateVideoAsync(int id, VideoDto videoDto);
    Task<bool> DeleteDealAsync(int id);

}

