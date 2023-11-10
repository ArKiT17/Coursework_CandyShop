using System.ComponentModel.DataAnnotations;

namespace WebApplication45.Models {
	public class Cart {
		[Key]
		public int Id { get; set; }
		[Required]
		public int ClientId { get; set; }
		[Required]
		public int ItemId { get; set; }
		[Required]
		public int Count { get; set; }
	}
}
