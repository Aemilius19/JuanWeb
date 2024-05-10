using JuanWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace JuanWeb.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
