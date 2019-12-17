using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.ViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Пожалуйста, укажите e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите фамилию")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введеите отчество")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введеите ИНН")]
        public string Inn { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введеите номер водительских прав")]
        public string DriverLicense { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введеите серию и номер паспорта")]
        public string Passport { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Пожалуйста, введите дату рождения")]
        public DateTime Birthdate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Пожалуйста, введите номер телефона")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пожалуйста, ввдеите подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение не совпадают")]
        public string PasswordConfirmation { get; set; }
    }
}
