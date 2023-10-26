using System.ComponentModel.DataAnnotations;

namespace Coursework.Models.Account
{
    public class RegisterModel {
        [Required(ErrorMessage = "Введіть логін")]
        [MinLength(5, ErrorMessage = "Логін має містити мінімум 5 символів")]
        public string Login { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введіть e-mail")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
		[Required(ErrorMessage = "Введіть пароль")]
		[MinLength(6, ErrorMessage = "Пароль має містити мінімум 6 символів")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Повторіть пароль")]
		[Compare("Password", ErrorMessage = "Паролі не співпадають")]
		public string PasswordConfirm { get; set; }
	}
}
