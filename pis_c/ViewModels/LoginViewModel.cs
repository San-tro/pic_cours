using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите логин")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пожалйста, введите пароль")]
        public string Password { get; set; }
    }
}
