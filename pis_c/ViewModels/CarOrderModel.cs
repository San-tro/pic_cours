using System;
using System.ComponentModel.DataAnnotations;

namespace pis_c.ViewModels
{
    public class CarOrderModel
    {
        [Required(ErrorMessage = "Введите дату начала аренды"), ]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Введите время начала аренды")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Введите количество дней")]
        public int Days { get; set; }

        public DateTime StartDateTime
        {
            get => new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute, 0);
        }


        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        public int OrderId { get; set; }

        public int CarId { get; set; }
    }
}
