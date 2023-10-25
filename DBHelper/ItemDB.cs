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

		public async Task<Item> GetAsync(int id) {
			return await _db.Item.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Item>> GetAll() {
			return await _db.Item.ToListAsync();
		}

		public async Task<Item> EditAsync(Item item) {
			Item oldItem = await GetAsync(item.Id);
			oldItem.ImagePath = item.ImagePath;
			oldItem.Name = item.Name;
			oldItem.Price = item.Price;
			_db.Item.Update(oldItem);
			await _db.SaveChangesAsync();
			return oldItem;
		}

		public async Task<bool> DeleteAsync(int id) {
			_db.Item.Remove(await GetAsync(id));
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
