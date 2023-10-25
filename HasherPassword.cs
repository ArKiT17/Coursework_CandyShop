using System.Security.Cryptography;
using System.Text;

namespace Coursework {
	public static class HasherPassword {
		public static string HashPassword(string password) {
			using (SHA256 sha256 = SHA256.Create()) {
				var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				var hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
				return hash;
			}
		}
	}
}
