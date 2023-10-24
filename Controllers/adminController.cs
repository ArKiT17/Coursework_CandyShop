using Microsoft.AspNetCore.Mvc;
using WebApplication45.Models;

namespace Coursework.Controllers {
	public class adminController : Controller {
		public IActionResult Index() {
			return View();
		}
	}
}
