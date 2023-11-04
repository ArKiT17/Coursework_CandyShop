using Coursework.DBHelper;
using Microsoft.AspNetCore.Authorization;
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

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Items() {
			return View(await _itemDB.GetAllAsync());
		}

		[HttpPost]  //update
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Items(Item item) {
			await _itemDB.EditAsync(item);
			//ViewBag.Method = "put";
			return RedirectToAction("Items", "Admin");
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Staff() {
			return View(await _staffDB.GetAllAsync());
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Users() {
			return View(await _userDB.GetAllAsync());
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> News() {
			return View();
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> ModalItem(int id) {
			return PartialView("ModalItem", await _itemDB.GetAsync(id));
		}
	}
}
