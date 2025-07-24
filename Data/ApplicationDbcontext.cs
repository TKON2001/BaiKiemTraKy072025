using Microsoft.EntityFrameworkCore;
using DemoMvc.Models;

namespace DemoMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<CA2> CA2 { get; set; }
    }
}