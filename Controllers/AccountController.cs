using Coursework.DBHelper;
using Coursework.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Claims;

namespace Coursework.Controllers {
	public class AccountController : Controller {
		private readonly UserDB _userDB;

		public AccountController(AppDbContext db) {
			_userDB = new UserDB(db);
		}

		[HttpGet]
		public IActionResult Register() {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model) {
			if (ModelState.IsValid) {
				User user = await _userDB.GetAsync(model.Login);
				if (user != null) {
					ViewBag.LoginIsNotAvailable = "Користувач з таким логіном вже існує";
                    return View(model);
				}
				user = new User() {
					Login = model.Login,
					Email = model.Email,
					Role = Role.User,
					Password = HasherPassword.HashPassword(model.Password)
				};
				await _userDB.CreateAsync(user);

				await Authorise(user);
				return RedirectToAction("Main", "Home");
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Login() {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model) {
			if (ModelState.IsValid) {
				User user = await _userDB.GetAsync(model.Login);
				if (user == null) {
					ViewBag.LoginErrorMessage = "Користувача не знайдено";
                    return View(model);
				}
				if (user.Password != HasherPassword.HashPassword(model.Password)) {
					ViewBag.LoginErrorMessage = "Неправильний пароль";
                    return View(model);
				}
				await Authorise(user);
				return RedirectToAction("Main", "Home");
			}
			return View(model);
		}

		public async Task<IActionResult> LogOut() {
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Main", "Home");
		}

		private async Task<bool> Authorise(User user) {
			var claims = new List<Claim> {
					new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
					new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
				};
			var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie",
				ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity));
			return true;
		}
	}
}
