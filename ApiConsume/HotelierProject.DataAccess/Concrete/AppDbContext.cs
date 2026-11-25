using HotelierProject.DataAccess.Extensions;
using HotelierProject.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelierProject.DataAccess.Concrete;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplySoftDeleteQueryFilter();
    }
    
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Subscribe> Subscribes { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    
}