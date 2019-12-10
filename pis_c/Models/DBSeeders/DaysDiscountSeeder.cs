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
                new DaysDiscount() {MinDaysAmmount = 10, Percent = 5},
                new DaysDiscount() {MinDaysAmmount = 15, Percent = 7},
                new DaysDiscount() {MinDaysAmmount = 20, Percent = 10}
            };
        }
    }
}
