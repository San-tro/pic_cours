using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class OrdersDiscount
    {
        public int Id { get; set; }
        public int MinDaysAmmount { get; set; }
        public double Percentage { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
