using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Address { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? ConfirmationDateTime { get; set; }
        public bool UserConfirmed { get; set; }
        public double Cost { get; set; }
        public DateTime StartDateTime { get; set; }
        public int Days { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? OrdersDiscountId { get; set; }
        public OrdersDiscount OrdersDiscount { get; set; }

        public int? DaysDiscountId { get; set; }
        public DaysDiscount DaysDiscount { get; set; }
    }
}
