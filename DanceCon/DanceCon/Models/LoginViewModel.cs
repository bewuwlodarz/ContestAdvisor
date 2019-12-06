using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanceCon.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Required.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Password { get; set; }

    }
}
