using Microsoft.EntityFrameworkCore;
using Coursework.Models.Account;
using AspNetCore;

namespace Coursework.DBHelper {
	public class UserDB {
		private readonly AppDbContext _db;
		public UserDB(AppDbContext db) {
			_db = db;
		}

		public async Task<bool> CreateAsync(User user) {
			await _db.User.AddAsync(user);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<User> Get(int id) {
			return await _db.User.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<User>> GetAll() {
			return await _db.User.ToListAsync();
		}

		//public bool Edit(User user) {

		//}

		public async Task<bool> DeleteAsync(int id) {
			_db.User.Remove(await Get(id));
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
