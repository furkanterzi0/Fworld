using System.ComponentModel.DataAnnotations;

namespace webui.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "is required field")]
        [StringLength(20,MinimumLength = 3,ErrorMessage ="must be 3-20 characters long")]
        public string ?Name { get; set; }

        [Required(ErrorMessage = "is required field")]
        [StringLength(20,MinimumLength = 3,ErrorMessage ="must be 3-20 characters long")]
        public string ?Surname { get; set; }

        public string ?Email { get; set; }
        
        [Required(ErrorMessage = "is required field")]
        [StringLength(20,MinimumLength = 4,ErrorMessage ="must be 4-20 characters long")]
        public string ?Username { get; set; }

        [Required(ErrorMessage = "is required field")]
        [StringLength(20,MinimumLength = 6,ErrorMessage ="must be 6-20 characters long")]
        public string ?Password { get; set; }
    }
}