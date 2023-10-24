using System.ComponentModel.DataAnnotations;

namespace Coursework.Models.Account
{
    public enum Role {
        [Display(Name = "Користувач")]
        User = 0,
        [Display(Name = "Адміністратор")]
        Admin = 1
    }
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
