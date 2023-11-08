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

		[HttpPost]  // add + update
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Items(Item item) {
			if (await _itemDB.GetAsync(item.Id) != null)
				await _itemDB.EditAsync(item);
			else
				await _itemDB.CreateAsync(item);
			return RedirectToAction("Items", "Admin");
		}

		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Items(int id) {
			if (await _itemDB.GetAsync(id) != null)
				await _itemDB.DeleteAsync(id);
			return Ok();
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> ModalItem(int id) {
			if (id != -1)
				return PartialView("ModalItem", await _itemDB.GetAsync(id));
			else
				return PartialView("ModalItem", new Item());
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Staff() {
			return View(await _staffDB.GetAllAsync());
		}

		[HttpPost]  // add + update
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Staff(Staff staff) {
			if (await _staffDB.GetAsync(staff.Id) != null)
				await _staffDB.EditAsync(staff);
			else
				await _staffDB.CreateAsync(staff);
			return RedirectToAction("Staff", "Admin");
		}

		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Staff(int id) {
			if (await _staffDB.GetAsync(id) != null)
				await _staffDB.DeleteAsync(id);
			return Ok();
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> ModalStaff(int id) {
			if (id != -1)
				return PartialView("ModalStaff", await _staffDB.GetAsync(id));
			else
				return PartialView("ModalStaff", new Staff());
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
		public IActionResult ModalDelete(int id) {
			return PartialView("ModalDelete", id);
		}
	}
}
