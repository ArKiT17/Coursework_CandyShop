using Microsoft.EntityFrameworkCore;

namespace WebApplication45.Models {
	public class AppDbContext : DbContext {
		public AppDbContext() { }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Item> Item { get; set; }
		public DbSet<Staff> Staff { get; set; }
		public DbSet<Client> Client { get; set; }
		public DbSet<Cart> Cart { get; set; }
	}
}
