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
                new Brand() { Name = "Toyota"},
                new Brand() { Name = "Bmw"},
                new Brand() {Name = "Audi"},
                new Brand() {Name = "Kia"},
                new Brand() {Name = "Hyundai"},
                new Brand() {Name = "Lada"},
            };
        }
    }
}
