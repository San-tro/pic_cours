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
                new OrdersDiscount() {Id = 1, MinDaysAmmount = 10 ,  Percentage = 5},
                new OrdersDiscount() {Id = 2, MinDaysAmmount = 16,  Percentage = 7},
                new OrdersDiscount() {Id = 3, MinDaysAmmount = 21, Percentage = 10 }
            };
        }
    }
}
