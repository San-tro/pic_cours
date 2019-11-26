using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class Order
    {
        public int Id { get; set; }

        public string Address { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime ConfirmationDateTime { get; set; }
        public double Cost { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int OrdersDiscountId { get; set; }
        public OrdersDiscount OrdersDiscount { get; set; }

        public int DaysDiscountId { get; set; }
        public DaysDiscount DaysDiscount { get; set; }
    }
}
