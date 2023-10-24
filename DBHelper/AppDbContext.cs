using Coursework.Models.Account;
using Microsoft.EntityFrameworkCore;
using WebApplication45.Models;

namespace Coursework.DBHelper
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Item> Item { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
