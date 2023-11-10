using Coursework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApplication45.Models;

namespace Coursework.DBHelper {
	public class CartDB {
		private readonly AppDbContext _db;
		public CartDB(AppDbContext db) {
			_db = db;
		}

		public async Task<bool> CreateAsync(Cart cart) {
			await _db.Cart.AddAsync(cart);
			await _db.SaveChangesAsync();
			return true;
		}

		public IQueryable<CartViewModel> GetAllOfOneClient(int clientId) {
			return from cart in _db.Cart
				   join item in _db.Item on cart.ItemId equals item.Id
				   where cart.ClientId == clientId
				   select new CartViewModel {
					   Id = cart.Id,
					   ClientId = cart.ClientId,
					   ImagePath = item.ImagePath,
					   ItemName = item.Name,
					   ItemPrice = item.Price,
					   Count = cart.Count,
				   };
		}

		public async Task<Cart> GetAsync(int id) {
			return await _db.Cart.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<bool> IncrementCountAsync(int cartId) {
			Cart cartItem = await GetAsync(cartId);
			cartItem.Count++;
			await EditAsync(cartItem);
			return true;
		}

		public async Task<bool> DecrementCountAsync(int cartId) {
			Cart cartItem = await GetAsync(cartId);
			if (cartItem.Count == 1)
				await DeleteAsync(cartItem);
			else {
				cartItem.Count--;
				await EditAsync(cartItem);
			}
			return true;
		}

		private async Task<Cart> EditAsync(Cart cart) {
			Cart oldCart = await GetAsync(cart.Id);
			oldCart.Count = cart.Count;
			_db.Cart.Update(oldCart);
			await _db.SaveChangesAsync();
			return oldCart;
		}

		public async Task<bool> DeleteAsync(int id) {
			_db.Cart.Remove(await GetAsync(id));
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteAsync(Cart cart) {
			_db.Cart.Remove(cart);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteAllOfOneClientAsync(int clientId) {
			_db.Cart.RemoveRange(_db.Cart.Where(x => x.ClientId == clientId));
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
