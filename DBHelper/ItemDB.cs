using Microsoft.EntityFrameworkCore;
using WebApplication45.Models;

namespace Coursework.DBHelper {
	public class ItemDB {
		private readonly AppDbContext _db;

		public ItemDB(AppDbContext db) {
			_db = db;
		}

		public async Task<bool> CreateAsync(Item item) {
			await _db.Item.AddAsync(item);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<Item> Get(int id) {
			return await _db.Item.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Item>> GetAll() {
			return await _db.Item.ToListAsync();
		}

		//public bool Edit(Item item) {

		//}

		public async Task<bool> DeleteAsync(int id) {
			_db.Item.Remove(await Get(id));
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
