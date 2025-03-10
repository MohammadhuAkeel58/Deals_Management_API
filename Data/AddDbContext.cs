using DealsManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DealsManagement.Data;


public class AddDbContext : DbContext
{
    public DbSet<Deal> Deals { get; set; }
    public DbSet<Hotel> Hotels { get; set; }


    public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
    {
    }

}