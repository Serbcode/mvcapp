using Microsoft.EntityFrameworkCore;

namespace mvcapp.Models;

public class ApiDbContext : DbContext
{

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {           
    }

    public DbSet<Blog> Blogs {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {                
        modelBuilder.Entity<Blog>().HasData(FakeDataFactory.Blogs); // Roles have made first
    }
}