using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class DaysDiscount
    {
        public int MinDaysAmmount { get; set; }
        public double Percent { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
