using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.ViewModels
{
    public class BrandViewModel
    {
        [Required(ErrorMessage = "Введите название марки")]
        public string Name { get; set; }
    }
}
