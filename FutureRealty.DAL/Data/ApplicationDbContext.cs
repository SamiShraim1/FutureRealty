using FutureRealty.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FutureRealty.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}

