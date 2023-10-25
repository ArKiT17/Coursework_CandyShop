using Microsoft.EntityFrameworkCore;
using Coursework.DBHelper;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApplication45
{
    public class Startup {
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services) {
			services.AddDbContext<AppDbContext>(options => {
				options.UseSqlServer(Configuration.GetConnectionString("Default"));
			});
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options => {
					options.LoginPath = new PathString("/Account/Login");
					options.AccessDeniedPath = new PathString("/Account/Login");
				});
			services.AddControllersWithViews();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Main}/{id?}");
			});
		}
	}
}
