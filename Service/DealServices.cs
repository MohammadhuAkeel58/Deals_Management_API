using System;
using DealsManagement.Data;
using DealsManagement.DTO;
using DealsManagement.Models.Domain;
using DealsManagement.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DealsManagement.Service;

public class DealServices : IDealService
{
    private readonly AddDbContext context;

    public DealServices(AddDbContext context)
    {
        this.context = context;
    }






    public async Task<DealViewModel> CreateDealAsync(DealDto dealDto)
    {
        try
        {
            var deal = new Deal
            {
                Name = dealDto.Name,
                Slug = dealDto.Slug,
                Title = dealDto.Title,
                Image = dealDto.Image,
                Hotels = dealDto.Hotels?.Select(x => new Hotel
                {
                    Name = x.Name,
                    Location = x.Location,
                    Description = x.Description
                }).ToList()
            };

            context.Deals.Add(deal);
            await context.SaveChangesAsync();

            return new DealViewModel
            {
                Id = deal.Id,
                Name = deal.Name,
                Slug = deal.Slug,
                Title = deal.Title,
                Image = deal.Image,
                Hotels = deal.Hotels.Select(x => new HotelViewModel
                {
                    Name = x.Name,
                    Location = x.Location,
                    Description = x.Description
                }).ToList()

            };

        }
        catch (Exception)
        {

            throw new Exception("Error creating deal");
        }

    }







    public async Task<List<DealViewModel>> GetAllDealsAsync()
    {
        try
        {
            var deals = await context.Deals.Include(x => x.Hotels).ToListAsync();
            return deals.Select(deal => new DealViewModel
            {
                Id = deal.Id,
                Name = deal.Name,
                Slug = deal.Slug,
                Title = deal.Title,
                Image = deal.Image,
                Hotels = deal.Hotels?.Select(h => new HotelViewModel
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Location = h.Location,
                    Description = h.Description
                }).ToList()
            }).ToList();
        }
        catch (Exception)
        {

            throw new Exception("Error getting deals");
        }

    }




    public async Task<DealViewModel> GetDealByIdAsync(int id)
    {
        try
        {
            var deal = await context.Deals.Include(x => x.Hotels).FirstOrDefaultAsync(x => x.Id == id);
            if (deal == null) return null;

            return new DealViewModel
            {
                Id = deal.Id,
                Name = deal.Name,
                Slug = deal.Slug,
                Title = deal.Title,
                Image = deal.Image,
                Hotels = deal.Hotels?.Select(h => new HotelViewModel
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Location = h.Location,
                    Description = h.Description
                }).ToList()


            };
        }
        catch (Exception)
        {

            throw new Exception("Error getting deal");
        }

    }







    public async Task<DealViewModel> UpdateDealAsync(int id, DealDto dealDto)
    {

        try
        {
            var deal = await context.Deals.Include(d => d.Hotels).FirstOrDefaultAsync(x => x.Id == id);
            if (deal == null) return null;

            deal.Name = dealDto.Name;
            deal.Slug = dealDto.Slug;
            deal.Title = dealDto.Title;
            deal.Image = dealDto.Image;
            deal.Hotels = dealDto.Hotels?.Select(x => new Hotel
            {
                Name = x.Name,
                Location = x.Location,
                Description = x.Description
            }).ToList();


            await context.SaveChangesAsync();

            return new DealViewModel
            {
                Id = deal.Id,
                Name = deal.Name,
                Slug = deal.Slug,
                Title = deal.Title,
                Image = deal.Image,
                Hotels = deal.Hotels.Select(x => new HotelViewModel
                {
                    Name = x.Name,
                    Location = x.Location,
                    Description = x.Description
                }).ToList()
            };
        }
        catch (Exception)
        {

            throw new Exception("Error updating deal");
        }

    }






    public async Task<bool> DeleteDealAsync(int id)
    {
        try
        {
            var deal = await context.Deals.FindAsync(id);
            if (deal == null) return false;

            context.Deals.Remove(deal);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw new Exception("Error deleting deal");
        }

    }

    public async Task<HotelViewModel> CreateHotelAsync(HotelDto hotelDto)
    {
        try
        {
            var existDeal = await context.Deals.FirstOrDefaultAsync(x => x.Id == hotelDto.DealId);
            if (existDeal == null)
            {
                return null;
            }
            var hotel = new Hotel
            {
                Name = hotelDto.Name,
                Location = hotelDto.Location,
                Description = hotelDto.Description,
                DealId = hotelDto.DealId
            };

            context.Hotels.AddAsync(hotel);
            await context.SaveChangesAsync();

            return new HotelViewModel
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                Location = hotel.Location,
                Description = hotel.Description
            };
        }
        catch (Exception)
        {

            throw new Exception("Error creating hotel");
        }

    }




}
