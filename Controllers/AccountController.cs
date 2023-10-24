﻿using Coursework.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.Controllers {
	public class AccountController : Controller {
		[HttpGet]
		public IActionResult Register() {
			return View();
		}

		//[HttpPost]
		//public async Task<IActionResult> Register(RegisterModel model) {
		//	if (ModelState.IsValid) {
		//		var response = await 
		//	}
		//}
		// GET: AccountController/Details/5
		public ActionResult Details(int id) {
			return View();
		}

		// GET: AccountController/Create
		public ActionResult Create() {
			return View();
		}

		// POST: AccountController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: AccountController/Edit/5
		public ActionResult Edit(int id) {
			return View();
		}

		// POST: AccountController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}

		// GET: AccountController/Delete/5
		public ActionResult Delete(int id) {
			return View();
		}

		// POST: AccountController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			}
			catch {
				return View();
			}
		}
	}
}