using Microsoft.AspNetCore.Mvc;
using WebApplication45.Models;

namespace Coursework.Controllers {
	public class AdminController : Controller {
		public IActionResult Panel() {
			isAdmin();
			return View();
		}

		public async Task<IActionResult> Items() {
			isAdmin();
			return View();
		}

		public async Task<IActionResult> Staff() {
			isAdmin();
			return View();
		}

		public async Task<IActionResult> Users() {
			isAdmin();
			return View();
		}

		public async Task<IActionResult> News() {
			isAdmin();
			return View();
		}

		private bool isAdmin() {
			if (!User.IsInRole("Admin")) {
				RedirectToAction("Main", "Home");
				return false;
			}
			return true;
		}
	}
}
