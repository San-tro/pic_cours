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
                new OrdersDiscount() {Id = 1, MinOrdersAmmount = 0 ,  Percentage = 0},
                new OrdersDiscount() {Id = 2, MinOrdersAmmount = 10 ,  Percentage = 5},
                new OrdersDiscount() {Id = 3, MinOrdersAmmount = 16,  Percentage = 7},
                new OrdersDiscount() {Id = 4, MinOrdersAmmount = 21, Percentage = 10 }
            };
        }
    }
}
