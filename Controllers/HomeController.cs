using Coursework.DBHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication45.Models;

namespace WebApplication45.Controllers
{
    public class HomeController : Controller {
		[HttpGet]
		public IActionResult Main() {
			return View();
		}
	}
}
