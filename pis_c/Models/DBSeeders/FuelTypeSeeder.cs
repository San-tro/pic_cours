using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class FuelTypeSeeder
    {
        public static FuelType[] Create()
        {
            return new FuelType[]
            {
                new FuelType() {Name = "Бензин"},
                new FuelType() {Name = "Дизель"},
                new FuelType() {Name = "Электричество"},
                new FuelType() {Name = "Газ"}
            };
        }
    }
}
