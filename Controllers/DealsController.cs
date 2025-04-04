using System.Data;
using DealsManagement.Data;
using DealsManagement.DTO;
using DealsManagement.Models.Domain;
using DealsManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly IDealService dealService;


        public DealsController(IDealService dealService)
        {

            this.dealService = dealService;


        }

        [HttpGet]
        public async Task<IActionResult> GetDeals()
        {
            try
            {
                var deals = await dealService.GetAllDealsAsync();
                return Ok(deals);
            }
            catch (Exception)
            {

                throw new Exception("Error in getting deals");
            }

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDealsById(int id)
        {
            try
            {
                var deal = await dealService.GetDealByIdAsync(id);
                if (deal == null)
                {
                    return NotFound();
                }
                return Ok(deal);
            }
            catch (Exception)
            {

                throw new Exception("Error in getting deal by id");
            }

        }



        [HttpPost]
        public async Task<IActionResult> CreateDeal([FromForm] DealDto dealDto)
        {
            try
            {
                var createDeal = await dealService.CreateDealAsync(dealDto);
                return Ok(createDeal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDeal([FromRoute] int id, [FromBody] DealDto dealDto)
        {
            try
            {
                var updateDeal = await dealService.UpdateDealAsync(id, dealDto);
                if (updateDeal == null)
                {
                    return NotFound();
                }
                return Ok(updateDeal);
            }
            catch (Exception)
            {

                throw new Exception("Error in updating deal");
            }

        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDeal([FromRoute] int id)
        {
            try
            {
                var deal = await dealService.DeleteDealAsync(id);
                if (!deal)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                throw new Exception("Error in deleting deal");
            }

        }




        [HttpPost]
        [Route("/api/hotel")]

        public async Task<IActionResult> CreateHotel([FromBody] HotelDto hotelDto)
        {
            try
            {
                var hotel = await dealService.CreateHotelAsync(hotelDto);
                return Ok(hotel);
            }
            catch (Exception)
            {

                throw new Exception("Error in creating hotel");

            }


        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateImage([FromRoute] int id, [FromForm] ImageDto imageDto)
        {
            try
            {
                var updateDeal = await dealService.UpdateImageAsync(id, imageDto);
                if (updateDeal == null)
                {
                    return NotFound();
                }
                return Ok(updateDeal);
            }
            catch (Exception)
            {

                throw new Exception("Error in updating deal");
            }

        }

        [HttpPut]
        [Route("video/{id}")]
        public async Task<IActionResult> UpdateVideo([FromRoute] int id, [FromForm] VideoDto videoDto)
        {
            try
            {
                var updateDeal = await dealService.UpdateVideoAsync(id, videoDto);
                if (updateDeal == null)
                {
                    return NotFound();
                }
                return Ok(updateDeal);
            }
            catch (Exception)
            {

                throw new Exception("Error in updating deal");
            }

        }



    }






}




