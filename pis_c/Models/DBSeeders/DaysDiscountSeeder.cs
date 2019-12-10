using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class DaysDiscountSeeder
    {
        public static DaysDiscount[] Create()
        {
            return new DaysDiscount[]
            {
                new DaysDiscount() {Id = 1, MinDaysAmmount = 10, Percent = 5},
                new DaysDiscount() {Id = 2, MinDaysAmmount = 15, Percent = 7},
                new DaysDiscount() {Id = 3, MinDaysAmmount = 20, Percent = 10}
            };
        }
    }
}
