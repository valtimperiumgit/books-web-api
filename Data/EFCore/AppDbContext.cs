using Books.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.EFCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasKey(e => e.Id);
    }
    
    public DbSet<Book?> Books { get; set; }
}