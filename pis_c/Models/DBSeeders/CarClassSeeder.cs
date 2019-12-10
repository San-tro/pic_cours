using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class CarClassSeeder
    {
        public static CarClass[] Create()
        {
            return new CarClass[]
            {
                new CarClass {Id = 1, Name = "A"},
                new CarClass {Id = 2, Name = "B"},
                new CarClass {Id = 3, Name = "C"},
                new CarClass {Id = 4, Name = "D"},
                new CarClass {Id = 5, Name = "E"}
            };
        }
    }
}
