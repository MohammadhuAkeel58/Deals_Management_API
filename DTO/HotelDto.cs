using System;

namespace DealsManagement.DTO;

public class HotelDto
{
    public int HotelId { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    public int DealId { get; set; }
}
