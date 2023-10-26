using System.ComponentModel.DataAnnotations;

namespace Coursework.Models.Account {
	public class LoginModel {
		[Required(ErrorMessage = "Введіть логін або e-mail")]
		public string Login { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Введіть пароль")]
		[Display(Name = "Пароль")]
		public string Password { get; set; }
	}
}
