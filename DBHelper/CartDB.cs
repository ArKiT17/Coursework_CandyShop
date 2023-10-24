using Microsoft.EntityFrameworkCore;
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

		public async Task<Cart> Get(int id) {
			return await _db.Cart.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Cart>> GetAll() {
			return await _db.Cart.ToListAsync();
		}

		//public bool Edit(Cart cart) {

		//}

		public async Task<bool> DeleteAsync(Cart cart) {
			_db.Cart.Remove(cart);
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
