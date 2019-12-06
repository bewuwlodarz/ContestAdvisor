using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanceCon.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Required.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required."), Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string RepeatPassword { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string City { get; set; }
    }

}
