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

		public IQueryable<Cart> GetAllOfOneClient(int clientId) {
			return _db.Cart.Where(x => x.ClientId == clientId);
		}

		public async Task<Cart> GetAsync(int id) {
			return await _db.Cart.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<bool> IncrementCountAsync(Cart cart) {
			Cart cartItem = await GetAsync(cart.Id);
			cartItem.Count++;
			return true;
		}

		public async Task<bool> DecrementCountAsync(Cart cart) {
			Cart cartItem = await GetAsync(cart.Id);
			if (cartItem.Count == 1)
				DeleteAsync(cartItem);
			else
				cartItem.Count--;
			return true;
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
			_db.Cart.RemoveRange(GetAllOfOneClient(clientId));
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
