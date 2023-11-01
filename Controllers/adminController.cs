using Coursework.DBHelper;
using Microsoft.AspNetCore.Mvc;
using WebApplication45.Models;

namespace Coursework.Controllers {
	public class AdminController : Controller {
		private readonly ItemDB _itemDB;
		private readonly StaffDB _staffDB;
		private readonly UserDB _userDB;

		public AdminController(AppDbContext db) {
			_itemDB = new ItemDB(db);
			_staffDB = new StaffDB(db);
			_userDB = new UserDB(db);
		}

		public async Task<IActionResult> Items() {
			if (!User.IsInRole("Admin"))
				return RedirectToAction("Main", "Home");
			return View(await _itemDB.GetAllAsync());
		}

		public async Task<IActionResult> Staff() {
			if (!User.IsInRole("Admin"))
				return RedirectToAction("Main", "Home");
			return View(await _staffDB.GetAllAsync());
		}

		public async Task<IActionResult> Users() {
			if (!User.IsInRole("Admin"))
				return RedirectToAction("Main", "Home");
			return View(await _userDB.GetAllAsync());
		}

		public async Task<IActionResult> News() {
			if (!User.IsInRole("Admin"))
				return RedirectToAction("Main", "Home");
			return View();
		}

		//private bool isAdmin() {
		//	if (!User.IsInRole("Admin")) {
		//		RedirectToAction("Main", "Home");
		//		return false;
		//	}
		//	return true;
		//}
	}
}
