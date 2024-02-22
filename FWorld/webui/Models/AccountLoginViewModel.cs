using System.ComponentModel.DataAnnotations;

namespace webui.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string ?username { get; set; }
        [Required]
        public string ?password { get; set; }
        public string? returnUrl { get; set; }
        public string ?remember { get; set; }
    }
}