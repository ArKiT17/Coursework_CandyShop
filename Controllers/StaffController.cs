using Coursework.DBHelper;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.Controllers {
	public class StaffController : Controller {
		private readonly StaffDB _staffDB;

		public StaffController(AppDbContext db) {
			_staffDB = new StaffDB(db);
		}

		[HttpGet]
		public async Task<IActionResult> Staff() {
			return View(await _staffDB.GetAll());
		}
	}
}
