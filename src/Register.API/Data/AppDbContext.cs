using Microsoft.EntityFrameworkCore;
using Register.API.Entities;

namespace Register.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}