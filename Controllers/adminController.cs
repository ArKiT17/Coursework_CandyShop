using Microsoft.AspNetCore.Mvc;

namespace Coursework.Controllers {
	public class adminController : Controller {
		public IActionResult Index() {
			return View();
		}
	}
}
