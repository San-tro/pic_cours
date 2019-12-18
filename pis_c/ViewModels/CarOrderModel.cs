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

        [Required(ErrorMessage = "Введите дату окончания аренды")]
        public DateTime FinishDate { get; set; }

        [Required(ErrorMessage = "Введите время окончания аренды")]
        public DateTime FinishTime { get; set; }

        public DateTime StartDateTime
        {
            get => new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute, 0);
        }

        public DateTime FinishDateTime
        {
            get => new DateTime(FinishDate.Year, FinishDate.Month, FinishDate.Day, FinishTime.Hour, FinishTime.Minute, 0);
        }

        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        public int OrderId { get; set; }

        public int CarId { get; set; }
    }
}
