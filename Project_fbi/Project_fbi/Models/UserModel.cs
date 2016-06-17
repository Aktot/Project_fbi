using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_fbi.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Будь ласка, введіть своє ім'я")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть своє прізвище")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Будь ласка, введіть свій телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть свій емейл")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Ви ввели некоректний email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть пароль")]
        public string Password { get; set; }

    }
}