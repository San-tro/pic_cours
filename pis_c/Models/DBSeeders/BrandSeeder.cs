using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class BrandSeeder
    {
        public static Brand[] Create()
        {
            return new Brand[] {
                new Brand() {Id = 1, Name = "Toyota"},
                new Brand() {Id = 2, Name = "Bmw"},
                new Brand() {Id = 3, Name = "Audi"},
                new Brand() {Id = 4, Name = "Kia"},
                new Brand() {Id = 5, Name = "Hyundai"},
                new Brand() {Id = 6, Name = "Lada"},
            };
        }
    }
}
