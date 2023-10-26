using Microsoft.EntityFrameworkCore;
using Coursework.Models.Account;

namespace Coursework.DBHelper {
	public class UserDB {
		private readonly AppDbContext _db;
		public UserDB(AppDbContext db) {
			_db = db;
		}

		public async Task<bool> CreateAsync(User user) {	// додати ViewModel для створення
			await _db.User.AddAsync(user);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<User> GetAsync(int id) {
			return await _db.User.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<User> GetAsync(string login) {
			return await _db.User.FirstOrDefaultAsync(x => (x.Login == login) || (x.Email == login));
		}

        public async Task<List<User>> GetAllAsync() {
			return await _db.User.ToListAsync();
		}

		//public bool Edit(User user) {

		//}

		public async Task<bool> DeleteAsync(int id) {
			_db.User.Remove(await GetAsync(id));
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
