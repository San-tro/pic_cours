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
                new FuelType() {Id = 1, Name = "Бензин"},
                new FuelType() {Id = 2, Name = "Дизель"},
                new FuelType() {Id = 3, Name = "Электричество"},
                new FuelType() {Id = 4, Name = "Газ"}
            };
        }
    }
}
