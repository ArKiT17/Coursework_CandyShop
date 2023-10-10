using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication45.Models;

namespace WebApplication45.Controllers
{
    public class HomeController : Controller {
		private readonly AppDbContext db;
		private readonly Client client;
		public HomeController(AppDbContext db) {
			this.db = db;
			this.client = null;
		}
		public IActionResult Index() {
			return View();
		}
		public async Task<IActionResult> Menu() {
			return View(await db.Item.ToListAsync());
		}
		public async Task<IActionResult> Staff() {
			return View(await db.Staff.ToListAsync());
		}
		//public async Task<IActionResult> Cart(bool logedIn) {
		//	if (logedIn)
		//		return View(false);
		//	else
		//		return View()
		//}
	}
}
