using WebApplication45.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication45 {
	public class Startup {
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services) {
			services.AddDbContext<AppDbContext>(options => {
				options.UseSqlServer(Configuration.GetConnectionString("Default"));
			});
			services.AddControllersWithViews();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
