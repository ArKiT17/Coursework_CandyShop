using Coursework.DBHelper;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.Controllers {
	public class CartController : Controller {
		private readonly CartDB _cartDB;

		public CartController(AppDbContext db) {
			_cartDB = new CartDB(db);
		}

		[HttpGet]
		public IActionResult Cart() {
			if(!User.Identity.IsAuthenticated) {
				return RedirectToAction("Login", "Account");
			}
			return View(_cartDB.GetAllOfOneClient(0));
		}
	}
}
