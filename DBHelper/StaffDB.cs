using Microsoft.EntityFrameworkCore;
using WebApplication45.Models;

namespace Coursework.DBHelper {
	public class StaffDB {
		private readonly AppDbContext _db;
		public StaffDB(AppDbContext db) {
			_db = db;
		}

		public async Task<bool> CreateAsync(Staff person) {
			await _db.Staff.AddAsync(person);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<Staff> Get(int id) {
			return await _db.Staff.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Staff>> GetAll() {
			return await _db.Staff.ToListAsync();
		}

		//public bool Edit(Staff person) {

		//}

		public async Task<bool> DeleteAsync(int id) {
			_db.Staff.Remove(await Get(id));
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
