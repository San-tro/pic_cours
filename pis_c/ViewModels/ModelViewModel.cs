using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.ViewModels
{
    public class ModelViewModel
    {
        [Required(ErrorMessage = "Выберите марку")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Введите название модели")]
        public string Name { get; set; }
    }
}
