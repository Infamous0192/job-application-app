using JobApplication.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Api.Models
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Job> Jobs => Set<Job>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>().HasData(new User
      {
        ID = 1,
        Username = "admin",
        Name = "Admin",
        Password = BCrypt.Net.BCrypt.HashPassword("asdqwe123"),
        Role = Role.Admin,
      });

      modelBuilder.Entity<Company>().HasData(new Company
      {
        ID = 1,
        Name = "Bebekabal",
        Description = "Bukan Perusahaan Abal-abal",
        Address = "Jl. Pemurus Komp. Pemurus Persada No. 27",
        UserID = 1
      });
    }
  }
}