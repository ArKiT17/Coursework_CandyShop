using Coursework.DBHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.Controllers {
	public class CartController : Controller {
		private readonly CartDB _cartDB;

		public CartController(AppDbContext db) {
			_cartDB = new CartDB(db);
		}

		[HttpGet]
		[Authorize]
		public IActionResult Cart() {
			return View(_cartDB.GetAllOfOneClient(0));
		}
	}
}
