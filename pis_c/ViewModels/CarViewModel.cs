using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.ViewModels
{
    public class CarViewModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите стоимость")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите гос номер")]
        public string StateNum { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Пожалуйста, введите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите год")]
        public int Year { get; set; }

        public bool DriverAirbag { get; set; }
        public bool PassangerAirbag { get; set; }
        public bool Abs { get; set; }
        public bool Asc { get; set; }
        public bool Esp { get; set; }
        public bool Climate { get; set; }
        public bool Ac { get; set; }
        public bool Cruise { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите количество мест")]
        public int SeatsAmmount { get; set; }
        
        [Required(ErrorMessage = "Пожалуйста, введите обьем двигателя")]
        public double EngineVol { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите мощность двигателя")]
        public int Power { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пробег")]
        public int Kilometrage { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите класс авто")]
        public int CarClassId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите модель")]
        public int ModelId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите тип топлива")]
        public int FuelTypeId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите тип кузова")]
        public int BodyTypeId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите тип привода")]
        public int DriveTypeId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите тип КПП")]
        public int GearBoxId { get; set; }

        
        [Required(ErrorMessage = "Пожалуйста, добавьте фото автомобиля")]
        public IFormFile Photo { get; set; }
    }
}
