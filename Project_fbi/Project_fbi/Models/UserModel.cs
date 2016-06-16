using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_fbi.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Будь ласка, введіть свій емейл")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Ви ввели некоректний email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть пароль")]
        public string Password { get; set; }

    }
}