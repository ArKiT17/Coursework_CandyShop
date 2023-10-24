using Coursework.DBHelper;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.Controllers {
	public class ItemController : Controller {
		private readonly ItemDB _itemDB;

		public ItemController(AppDbContext db) {
			_itemDB = new ItemDB(db);
		}

		[HttpGet]
		public async Task<IActionResult> Menu() {
			return View(await _itemDB.GetAll());
		}
	}
}
