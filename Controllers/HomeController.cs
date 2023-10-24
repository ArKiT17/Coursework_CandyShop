using Coursework.DBHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication45.Models;

namespace WebApplication45.Controllers
{
    public class HomeController : Controller {
		public IActionResult Index() {
			return View();
		}
		//public async Task<IActionResult> Menu() {
		//	return View(await db.Item.ToListAsync());
		//}
		//public async Task<IActionResult> Staff() {
		//	return View(await db.Staff.ToListAsync());
		//}
		//public async Task<IActionResult> Cart(bool logedIn) {
		//	if (logedIn)
		//		return View(false);
		//	else
		//		return View(true);
		//}

		//[HttpPost]
		//public async Task<IActionResult> Login([FromForm] Client client) {
		//	if ()
		//}
	}
}
