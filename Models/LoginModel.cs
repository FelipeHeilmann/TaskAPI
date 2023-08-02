using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email can not be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }
    }
}