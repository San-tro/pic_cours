using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class OrdersDiscountSeeder
    {
        public static OrdersDiscount[] Create()
        {
            return new OrdersDiscount[] {
                new OrdersDiscount() { MinDaysAmmount = 10 ,  Percentage = 5},
                new OrdersDiscount() {MinDaysAmmount = 16,  Percentage = 7},
                new OrdersDiscount() {MinDaysAmmount = 21, Percentage = 10 }
            };
        }
    }
}
