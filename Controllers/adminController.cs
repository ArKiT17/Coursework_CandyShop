using Microsoft.AspNetCore.Mvc;
using WebApplication45.Models;

namespace Coursework.Controllers {
	public class AdminController : Controller {
		public IActionResult Panel() {
			return View();
		}
	}
}
