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

		public async Task<Staff> GetAsync(int id) {
			return await _db.Staff.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Staff>> GetAllAsync() {
			return await _db.Staff.ToListAsync();
		}

		public int GetLastId() {
			return _db.Item.Max(item => item.Id);
		}

		public async Task<Staff> EditAsync(Staff person) {
			Staff oldPerson = await GetAsync(person.Id);
			oldPerson.ImagePath = person.ImagePath;
			oldPerson.Name = person.Name;
			oldPerson.Description = person.Description;
			_db.Staff.Update(oldPerson);
			await _db.SaveChangesAsync();
			return oldPerson;
		}

		public async Task<bool> DeleteAsync(int id) {
			_db.Staff.Remove(await GetAsync(id));
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
