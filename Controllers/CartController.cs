using Coursework.DBHelper;
using Coursework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using WebApplication45.Models;
using System.Text;

namespace Coursework.Controllers {
	public class CartController : Controller {
		private readonly CartDB _cartDB;
		private readonly UserDB _userDB;

		public CartController(AppDbContext db) {
			_cartDB = new CartDB(db);
			_userDB = new UserDB(db);
		}

		[HttpGet]
		[Authorize]
		public IActionResult Cart() {
			var items = _cartDB.GetAllOfOneClient(int.Parse(User.FindFirst("id").Value));
			return View(items.ToList());
		}

		[HttpPost]  // make order
		[Authorize]
		public async Task<IActionResult> Cart(int userId) {
			string smtpServer = "smtp.gmail.com";
			int smtpPort = 587;
			string smtpUsername = "xxblazexxmax01@gmail.com";
			string smtpPassword = Password.password;
			using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort)) {
				smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
				smtpClient.EnableSsl = true;
				var user = await _userDB.GetAsync(userId);
				var userCart = _cartDB.GetAllOfOneClient(userId);
				var message = "<!DOCTYPE html><html><head><style>h1 {font-size: 1.5em;font-family: 'Balsamiq Sans', cursive;text-align: center;}h2 {font-family: 'Balsamiq Sans', cursive;font-weight: normal;word-wrap: break-word;margin-top: 15px;text-align: center;}h3 {text-align: center;}hr {height: 2px;border: none;margin: 20px 0;background-color: rgb(162, 251, 144);}.main {width: 50%;margin: 10px auto;border: 3px solid rgb(162, 251, 144);border-radius: 15px;background-color: linen;padding: 30px;box-shadow: 0 4px 8px 0 rgb(162, 251, 144);}.element > * {margin: 0 auto;}.element-info {margin: 25px;margin: 0 auto;}.element-image {width: 200px;border-radius: 15px;display: block;}.element-price {margin: 0 auto;}.element-btn {background-color: #ddd;border: none;color: #333;width: 40px;height: 40px;font-size: 25px;cursor: pointer;}.count-item {display: flex;}.item-numerator {padding-top: 3px;display: block;min-width: 50px;font-size: 30px;text-align: center;background-color: white;}.decrement-count {border-radius: 50px 0 0 50px;}.increment-count {border-radius: 0 50px 50px 0;}.cart-footer {display: flex;justify-content: space-between;}.order-button {float: right;padding: 10px 20px;background-color: #42C029FF;color: #fff;cursor: pointer;border: none;border-radius: 8px;margin-bottom: 5px;font-family: 'Balsamiq Sans', cursive;font-size: 1.15em;}.order-button:hover {text-decoration: underline;background-color: #236516;}</style></head><body><div class=\"main\"><h2>Ваше замовлення прийнято.</h2><h2>З Вами зв'яжуться для уточнення даних для доставки</h2>";
				float fullprice = 0;
				foreach (var cart in userCart) {
					message += $"<div class=\"element\"><img src=\"{cart.ImagePath}\" class=\"element-image\"><div class=\"element-info\"><h1>{cart.ItemName}</h1><h2>{cart.ItemPrice} грн Х {cart.Count} шт</h2></div><div class=\"element-price\"><h2 class=\"price\">Разом: {cart.ItemPrice * cart.Count} грн</h2></div></div><hr>";
					fullprice += (cart.ItemPrice * cart.Count);
				}
				message += $"<h2 class=\"cart-sum\">Всього: <span id=\"summ\">{fullprice}</span> грн</h2></div></body></html>";
				MailMessage mail = new MailMessage(smtpUsername, user.Email, "Замовлення з Майстерні Солодощів", message);
				mail.IsBodyHtml = true;
				try {
					smtpClient.Send(mail);
				}
				catch (Exception ex) {
					Console.WriteLine(ex.ToString());
				}
			}
			return PartialView("ModalSent");
		}

		[HttpPut]    // видалити один елемент, або всю корзину
		[Authorize]
		public async Task<IActionResult> Cart(int cartId, bool inc) {
			if (inc)
				await _cartDB.IncrementCountAsync(cartId);
			else
				await _cartDB.DecrementCountAsync(cartId);
			return Ok();
		}

		[HttpDelete]	// видалити один елемент, або всю корзину
		[Authorize]
		public async Task<IActionResult> Cart(int userId, int itemId = -2) {
			if (itemId == -2)
				await _cartDB.DeleteAllOfOneClientAsync(userId);
			else
				await _cartDB.DeleteAsync(itemId);
			return Ok();
		}

		[HttpGet]
		[Authorize]
		public IActionResult ModalDelete() {
			return PartialView("ModalDelete");
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddItem(string itemId, string userId) {
			var item = await _cartDB.GetByItemAsync(int.Parse(itemId));
			if (item == null)
				await _cartDB.CreateAsync(new Cart() { ItemId = int.Parse(itemId), ClientId = int.Parse(userId) });
			else
				await _cartDB.IncrementCountAsync(item.Id);
			return Ok();
		}
	}
}
