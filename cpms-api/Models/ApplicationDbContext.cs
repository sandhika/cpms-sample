using cpms.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cpms.Api;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
          modelBuilder.Entity<User>()
                .HasMany<Project>()
                .WithOne();
    }

    public DbSet<Project> Project { get; set; }
    public DbSet<User> Users { get; set; }
}