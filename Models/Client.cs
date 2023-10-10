using System.ComponentModel.DataAnnotations;

namespace WebApplication45.Models {
	public class Client {
		[Key]
		public int Id { get; set; }
		[Required]
		public string Login { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
