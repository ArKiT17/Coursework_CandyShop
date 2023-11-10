using System.ComponentModel.DataAnnotations;

namespace Coursework.Models {
	public class CartViewModel {
		public int Id { get; set; }
		public int ClientId { get; set; }
		public string ImagePath { get; set; }
		public string ItemName { get; set; }
		public float ItemPrice { get; set; }
		public int Count { get; set; }
	}
}
