using System.ComponentModel.DataAnnotations;

namespace Coursework.Models.Account {
	public class LoginModel {
		[Required(ErrorMessage = "Введіть логін")]
		[MinLength(5, ErrorMessage = "Логін має містити мінімум 5 символів")]
		public string Login { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Введіть пароль")]
		[Display(Name = "Пароль")]
		public string Password { get; set; }
	}
}
